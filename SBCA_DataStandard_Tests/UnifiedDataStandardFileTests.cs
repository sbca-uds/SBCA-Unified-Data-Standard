using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace SBCA.UnifiedDataStandard.Tests
{
    [TestFixture]
    public class UnifiedDataStandardFileTests
    {
        [Test]
        public void Deserialize_UDS()
        {
            var stream = Resources.GetResourceAsStream("TestFile.uds");

            var zip = new ZipArchive(stream, ZipArchiveMode.Read);
            var uds = UnifiedDataStandardFile.Read(zip);
            Assert.IsTrue(uds != null);
        }

        [Test]
        public void Serialize_UDS()
        {
            var uds = TestModels.TestUnifiedDataStandardFile;
            var zip = uds.Write();
            var reparse = new ZipArchive(new MemoryStream(zip), ZipArchiveMode.Read);

            var reparsedUDs = UnifiedDataStandardFile.Read(reparse);

            Assert.IsTrue(reparsedUDs != null);
        }

        [Test]
        [Ignore("Utility method for regenerating the .component example file")]

        public void Overwrite_UDS_TestFile()
        {
            var uds = TestModels.TestUnifiedDataStandardFile;
            var zip = uds.Write();

            try
            {
                string outputFile = $@"{Resources.SchemaDirectory}\TestFile.uds";
                File.WriteAllBytes(outputFile, zip);

                Assert.IsTrue(File.Exists(outputFile));
            }
            catch (Exception ex)
            {
                Assert.Fail("Writing the test uds file failed! " + ex.Message);
            }
        }

        [Test]
        public void ValidSchema_UDSTestFile()
        {
            var udsStream = Resources.GetResourceAsStream("TestFile.uds");
            var udsArchive = new ZipArchive(udsStream, ZipArchiveMode.Read);

            Assert.IsTrue(udsArchive.Entries.Count > 0);
            Assert.IsTrue(udsArchive.Entries.Any(entry => entry.Name.EndsWith(".component")));

            var componentSchemaJson = Resources.GetResourceAsString("ComponentSchema.json");
            var componentSchema = JSchema.Parse(componentSchemaJson);
            foreach (var component in udsArchive.Entries.Where(entry => entry.Name.EndsWith(".component")))
            {
                var contents = new StreamReader(component.Open()).ReadToEnd();
                var componentJObject = JObject.Parse(contents);

                IList<string> messages; // debug and inspect this variable to see why invalid
                var valid = componentJObject.IsValid(componentSchema, out messages);

                Assert.IsTrue(valid);
            }
        }
    }
}
