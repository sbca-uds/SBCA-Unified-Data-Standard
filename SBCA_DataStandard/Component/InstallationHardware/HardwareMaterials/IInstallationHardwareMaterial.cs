namespace SBCA.UnifiedDataStandard.Component.InstallationHardware.HardwareMaterials
{
    public enum HardwareMaterialType
    {
        Hanger,
        Screw,
        Other,
    }

    public interface IInstallationHardwareMaterial
    {
        HardwareMaterialType MaterialType { get; }
    }
}
