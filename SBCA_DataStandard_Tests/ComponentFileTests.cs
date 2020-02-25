using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using SBCA.UnifiedDataStandard.Component;
using SBCA.UnifiedDataStandard.Component.Members.MemberMaterials;

namespace SBCA.UnifiedDataStandard.Tests
{
    [TestFixture]
    public class ComponentFileTests
    {
        [Test]
        public void Deserialize_ComponentFile()
        {
            var component = ComponentFile.Read(Resources.GetResourceAsString("Test.component"));
            Assert.IsTrue(component != null);
        }

        [Test]
        public void SerializeAndDeserializeComponentFile()
        {
            var component = TestModels.TestComponent;

            var jsonOutput = component.Write();

            var reparsedComponent = ComponentFile.Read(jsonOutput);

            Assert.AreEqual(component.Name, reparsedComponent.Name);
            Assert.AreEqual(component.NumberOfPlies, reparsedComponent.NumberOfPlies);
            Assert.AreEqual(component.DistanceUnit, reparsedComponent.DistanceUnit);
            Assert.AreEqual(component.AngleUnit, reparsedComponent.AngleUnit);
            Assert.AreEqual(component.ComponentUsage, reparsedComponent.ComponentUsage);

            var firstMember = component.Members.First();

            Assert.AreEqual("B1", firstMember.Name);
            Assert.AreEqual(MemberType.BottomChord, firstMember.MemberType);
            Assert.AreEqual("#2 SYP 2x4", firstMember.MaterialDescription);
            Assert.AreEqual(MemberMaterialType.Lumber, firstMember.MaterialType);
            Assert.AreEqual(120, firstMember.StockLength);

        }

        [Test]
        public void ComponentTestFileHasValidSchema()
        {
            var schemaJson = Resources.GetResourceAsString("ComponentSchema.json");
            var schema = JSchema.Parse(schemaJson);
            var componentJson = Resources.GetResourceAsString("Test.component");
            var componentJObject = JObject.Parse(componentJson);

            IList<string> messages; // debug and inspect this variable to see why invalid
            var valid = componentJObject.IsValid(schema, out messages);

            Assert.IsTrue(valid);
        }

        [Test]
        public void ComponentSchemaFileMatchesGeneratedSchema()
        {
            var schemaFromModel = UnifiedDataStandardSchema.SchemaGenerator.Generate(typeof(ComponentFile));
            var schemaJson = schemaFromModel.ToString(); // debug and inspect this variable to copy to Schema.json file in Resources
            var schemaFromFile = Resources.GetResourceAsString("ComponentSchema.json");

            Assert.AreEqual(schemaFromFile.ToString(), schemaFromModel.ToString());
        }

        [Test]
        [Ignore("Utility method for regenerating the .component json schema")]
        public void Overwrite_ComponentFile_Schema()
        {
            var schemaFromModel = UnifiedDataStandardSchema.SchemaGenerator.Generate(typeof(ComponentFile));
            var schemaJson = schemaFromModel.ToString();

            try
            {
                string outputFile = $@"{Resources.SchemaDirectory}\ComponentSchema.json";
                File.WriteAllText(outputFile, schemaJson);

                Assert.IsTrue(File.Exists(outputFile));
            }
            catch (Exception ex)
            {
                Assert.Fail("Writing the test model failed! " + ex.Message);
            }
        }

        [Test]
        [Ignore("Utility method for regenerating the .component example file")]
        public void Overwrite_ComponentFile_TestFile()
        {
            var component = TestModels.TestComponent;
            var jsonOutput = component.Write();

            try
            {
                string outputFile = $@"{Resources.SchemaDirectory}\Test.component";
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
