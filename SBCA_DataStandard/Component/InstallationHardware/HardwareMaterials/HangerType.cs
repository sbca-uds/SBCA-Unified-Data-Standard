using System;
using static SBCA.UnifiedDataStandard.Component.InstallationHardware.HardwareMaterials.HangerEnums;

namespace SBCA.UnifiedDataStandard.Component.InstallationHardware.HardwareMaterials
{
    public class HangerType : IInstallationHardwareMaterial
    {
        public Guid Guid { get; set; }

        public HardwareMaterialType MaterialType => HardwareMaterialType.Hanger;

        public string Description { get; set; }

        public HangerManufacturer HangerManufacturer { get; set; }
    }
}
