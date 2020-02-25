using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Serialization;

namespace SBCA.UnifiedDataStandard
{
    public class Manifest
    {
        public Version Version { get; set; } = new Version(0,1,2);

        public string Write()
        {
            return JsonConvert.SerializeObject(this, JsonSerialization.SerializerSettings);
        }
    }
}
