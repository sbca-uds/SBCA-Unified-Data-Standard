using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.Bearings;
using SBCA.UnifiedDataStandard.Component.Connectors;
using SBCA.UnifiedDataStandard.Component.Connectors.ConnectorMaterials;
using SBCA.UnifiedDataStandard.Component.Geometry;
using SBCA.UnifiedDataStandard.Component.InstallationHardware;
using SBCA.UnifiedDataStandard.Component.InstallationHardware.HardwareMaterials;
using SBCA.UnifiedDataStandard.Component.Members;
using SBCA.UnifiedDataStandard.Component.Members.MemberMaterials;

namespace SBCA.UnifiedDataStandard.Component
{
    public interface IConsumableComponentFile
    {
        Guid Guid { get; }
        string Name { get; }
        string Version { get; }
        string CreationProgram { get; }
        string CreationProgramVersion { get; }
        DateTime CreationTimeStamp { get; }
        DistanceUnit DistanceUnit { get; }
        AngleUnit AngleUnit { get; }
        int NumberOfPlies { get; }
        bool PliesFieldInstalled { get; }

        ComponentUsage ComponentUsage { get; }
        List<IMember> AllMembers { get; }
        List<IConnectorSet> AllConnectorSets { get; }
        List<IBearing> AllBearings { get; }
        List<IInstallationHardware> AllInstallationHardwares { get; }
        List<IMemberMaterial> AllMemberMaterials { get; }
        List<IConnectorMaterial> AllConnectorMaterials { get; }
        List<IInstallationHardwareMaterial> AllInstallationHardwareMaterials { get; }
    }

    public partial class ComponentFile : IConsumableComponentFile
    {
        [JsonIgnore]
        public List<IMember> AllMembers => Members.ToList<IMember>();
        [JsonIgnore]
        public List<IConnectorSet> AllConnectorSets => ConnectorPlatePairs.ToList<IConnectorSet>();
        [JsonIgnore]
        public List<IBearing> AllBearings => Bearings.ToList<IBearing>();
        [JsonIgnore]
        public List<IInstallationHardware> AllInstallationHardwares => Hangers.ToList<IInstallationHardware>();
        [JsonIgnore]
        public List<IMemberMaterial> AllMemberMaterials => Lumbers.ToList<IMemberMaterial>();
        [JsonIgnore]
        public List<IConnectorMaterial> AllConnectorMaterials => ConnectorPlateTypes.ToList<IConnectorMaterial>();
        [JsonIgnore]
        public List<IInstallationHardwareMaterial> AllInstallationHardwareMaterials => HangerTypes.ToList<IInstallationHardwareMaterial>();

        public static IConsumableComponentFile ParseConsumableComponentFile(string FileContents)
        {
            return ComponentFile.Read(FileContents);
        }
    }
}
