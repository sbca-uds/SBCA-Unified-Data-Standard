using System;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.InstallationHardware.HardwareMaterials;

namespace SBCA.UnifiedDataStandard.Component.InstallationHardware
{
    public class Hanger: IInstallationHardware
    {
        public Guid Guid { get; set; }

        public Guid MaterialGuid { get; set; }
        public HardwareMaterialType HardwareMaterialType => HardwareMaterialType.Hanger;

        [JsonIgnore]
        public HangerType HangerType { get; set; }

        [JsonIgnore] 
        public IInstallationHardwareMaterial InstallationHardwareMaterial => HangerType;

    }
}
