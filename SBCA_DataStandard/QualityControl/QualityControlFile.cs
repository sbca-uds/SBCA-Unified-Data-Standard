using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component;
using SBCA.UnifiedDataStandard.Serialization;

namespace SBCA.UnifiedDataStandard.QualityControl
{
    public class QualityControlFile
    {
        public Guid Guid { get; set; }
        public Guid ComponentGuid { get; set; }
        public string ComponentName { get; set; }

        [JsonIgnore] 
        public ComponentFile Component { get; set; }

        public List<PlateQualityControlData> PlateQualityControlDatas { get; set; } = new List<PlateQualityControlData>();

        public string Write()
        {
            return JsonConvert.SerializeObject(this, JsonSerialization.SerializerSettings);
        }

        public static QualityControlFile Read(string fileContents)
        {
            return JsonConvert.DeserializeObject<QualityControlFile>(fileContents, JsonSerialization.SerializerSettings);
        }
    }
}
