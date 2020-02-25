using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SBCA.UnifiedDataStandard.Component;
using SBCA.UnifiedDataStandard.QualityControl;

namespace SBCA.UnifiedDataStandard.Tests
{
    [TestFixture]
    public class QualityControlFileTests
    {
        [Test]
        public void Deserialize_QualityControlFile()
        {
            var qc = ComponentFile.Read(Resources.GetResourceAsString("Test.qc"));
            Assert.IsTrue(qc != null);
        }


        [Test]
        public void SerializeAndDeserialize_QualityControlFile()
        {
            var qcFile = TestModels.TestQualityControlFile;

            var jsonOutput = qcFile.Write();

            var reparsedQc = QualityControlFile.Read(jsonOutput);

            Assert.AreEqual(qcFile.ComponentName, reparsedQc.ComponentName);
        }

        [Test]
        public void ValidJsonSchema_QualityControlTestFile()
        {
            var schemaJson = Resources.GetResourceAsString("QCSchema.json");
            var schema = JSchema.Parse(schemaJson);
            var qcJson = Resources.GetResourceAsString("Test.qc");
            var qcJObject = JObject.Parse(qcJson);

            IList<string> messages; // debug and inspect this variable to see why invalid
            var valid = qcJObject.IsValid(schema, out messages);

            Assert.IsTrue(valid);
        }

        [Test]
        public void QualityControlSchemaFileMatchesModel()
        {
            var schemaFromModel = UnifiedDataStandardSchema.SchemaGenerator.Generate(typeof(QualityControlFile));
            var schemaJson = schemaFromModel.ToString(); // debug and inspect this variable to copy to Schema.json file in Resources
            var schemaFromFile = Resources.GetResourceAsString("QCSchema.json");

            Assert.AreEqual(schemaFromFile.ToString(), schemaFromModel.ToString());
        }

        [Test]
        [Ignore("Utility method for regenerating the QualityControlFile json schema")]
        public void Overwrite_QualityControlFile_Schema()
        {
            var schemaFromModel = UnifiedDataStandardSchema.SchemaGenerator.Generate(typeof(QualityControlFile));
            var schemaJson = schemaFromModel.ToString();

            try
            {
                string outputFile = $@"{Resources.SchemaDirectory}\QCSchema.json";
                File.WriteAllText(outputFile, schemaJson);

                Assert.IsTrue(File.Exists(outputFile));
            }
            catch (Exception ex)
            {
                Assert.Fail("Writing the test model failed! " + ex.Message);
            }
        }

        [Test]
        [Ignore("Utility method for regenerating the .qc example file")]
        public void Overwrite_QualityControlFile_TestFile()
        {
            var component = TestModels.TestQualityControlFile;
            var jsonOutput = component.Write();

            try
            {
                string outputFile = $@"{Resources.SchemaDirectory}\Test.qc";
                File.WriteAllText(outputFile, jsonOutput);

                Assert.IsTrue(File.Exists(outputFile));
            }
            catch (Exception ex)
            {
                Assert.Fail("Writing the test model failed! " + ex.Message);
            }
        }
    }
}
