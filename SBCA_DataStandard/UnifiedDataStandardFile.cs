using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using SBCA.UnifiedDataStandard.Component;
using SBCA.UnifiedDataStandard.QualityControl;

namespace SBCA.UnifiedDataStandard
{
    public class UnifiedDataStandardFile
    {
        /// <summary>
        /// The Manifest contains the UDS version
        /// </summary>
        public Manifest Manifest { get; set; }
        public List<ComponentFile> ComponentFiles { get; set; } = new List<ComponentFile>();
        public List<QualityControlFile> QualityControlFiles { get; set; } = new List<QualityControlFile>();

        public byte[] Write()
        {
            var stream = new MemoryStream();
            var archive = new ZipArchive(stream, ZipArchiveMode.Create);

            AddFile("Manifest.json", Manifest.Write(), archive);

            foreach (var component in ComponentFiles)
            {
                AddFile($"{component.Name}.component", component.Write(), archive);
            }

            foreach (var qualityControlFile in QualityControlFiles)
            {
                AddFile($"{qualityControlFile.ComponentName}.qc", qualityControlFile.Write(), archive);
            }

            // The archive must first be disposed in order to write out end-of-file metadata and checksums.
            archive.Dispose();
            archive = null;

            return stream.ToArray();
        }

        public static UnifiedDataStandardFile Read(ZipArchive archive)
        {
            var newUDSFile = new UnifiedDataStandardFile();

            foreach (var zippedFile in archive.Entries.Where(entry => entry.Name.EndsWith(".component")))
            {

                var contents = new StreamReader(zippedFile.Open()).ReadToEnd();
                var component = ComponentFile.Read(contents);

                foreach (var member in component.Members)
                {
                    var matchingMaterial = component.Lumbers.Single(material => material.Guid == member.MaterialGuid);
                    member.Lumber = matchingMaterial;
                }

                foreach (var platePair in component.ConnectorPlatePairs)
                {
                    foreach (var plate in platePair.ConnectorPlates)
                    {
                        var matchingMaterial =
                            component.ConnectorPlateTypes.Single(material => material.Guid == plate.MaterialGuid);
                        plate.ConnectorPlateType = matchingMaterial;
                    }
                }

                foreach (var hanger in component.Hangers)
                {
                    var matchingMaterial =
                        component.HangerTypes.Single(material => material.Guid == hanger.MaterialGuid);
                    hanger.HangerType = matchingMaterial;
                }

                foreach (var bearing in component.Bearings)
                {
                    foreach (var guid in bearing.InstallationHardwareGuids)
                    {
                        var matchingHardware =
                            component.AllInstallationHardwares.Single(hardware => hardware.Guid == guid);
                        bearing.InstallationHardwares.Add(matchingHardware);
                    }
                }

                newUDSFile.ComponentFiles.Add(component);
            }

            foreach (var zippedFile in archive.Entries.Where(entry => entry.Name.EndsWith(".qc")))
            {
                var contents = new StreamReader(zippedFile.Open()).ReadToEnd();
                var qcFile = QualityControlFile.Read(contents);
                var matchingComponent = newUDSFile.ComponentFiles.Single(componentFile => componentFile.Name.Contains(qcFile.ComponentName));
                qcFile.Component = matchingComponent;

                foreach (var plateData in qcFile.PlateQualityControlDatas)
                {
                    plateData.ConnectorPlatePair = matchingComponent.ConnectorPlatePairs.Single(connectorSet => connectorSet.Guid == plateData.PlatePairGuid);
                    foreach (var contactArea in plateData.ContactAreas)
                    {
                        contactArea.Member = matchingComponent.Members.Single(member => member.Guid == contactArea.MemberGuid);
                    }
                }

                newUDSFile.QualityControlFiles.Add(qcFile);
            }

            return newUDSFile;
        }

        public void AddFile(string fileName, string fileContents, ZipArchive archive)
        {
            var fileData = Encoding.UTF8.GetBytes(fileContents);

            if (archive == null)
            {
                throw new Exception("ZipArchive has already been closed and the zip has been created.  Unable to add more files.");
            }

            using (var zipEntryStream = archive.CreateEntry(fileName).Open())
            {
                zipEntryStream.Write(fileData, 0, fileData.Length);
            }
        }
    }
}
