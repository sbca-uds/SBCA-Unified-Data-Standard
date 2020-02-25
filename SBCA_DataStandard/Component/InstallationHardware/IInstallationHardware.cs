using System;
using SBCA.UnifiedDataStandard.Component.InstallationHardware.HardwareMaterials;

namespace SBCA.UnifiedDataStandard.Component.InstallationHardware
{
    public interface IInstallationHardware
    {
        Guid Guid { get; }
        Guid MaterialGuid { get; }
        IInstallationHardwareMaterial InstallationHardwareMaterial { get; }
        HardwareMaterialType HardwareMaterialType { get; }
    }
}
