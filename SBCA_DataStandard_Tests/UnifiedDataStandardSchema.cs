using Newtonsoft.Json;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;

namespace SBCA.UnifiedDataStandard.Tests
{
    public static class UnifiedDataStandardSchema
    {
        public static JSchemaGenerator SchemaGenerator
        {
            get
            {
                {
                    var returnGenerator = new JSchemaGenerator();
                    returnGenerator.GenerationProviders.Add(new StringEnumGenerationProvider());
                    returnGenerator.DefaultRequired = Required.Always;
                    returnGenerator.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    returnGenerator.SchemaPropertyOrderHandling = SchemaPropertyOrderHandling.Default;
                    return returnGenerator;
                }
            }
        }
    }
}
