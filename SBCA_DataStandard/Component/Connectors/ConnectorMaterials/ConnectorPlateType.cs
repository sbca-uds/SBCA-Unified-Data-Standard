using System;

namespace SBCA.UnifiedDataStandard.Component.Connectors.ConnectorMaterials
{
    public enum StrengthGrade
    {
        Standard,
        HighStrength,
        SuperHighStrength
    }

    public enum PlateManufacturer
    {
        Alpine,
        CherokeeMetal,
        Eagle,
        MiTek,
        Simpson
    }

    public enum PlateGauge
    {
        Twenty,
        Eighteen,
        Sixteen,
    }

    public class ConnectorPlateType: IConnectorMaterial
    {
        public Guid Guid { get; set; }

        public ConnectorMaterialType MaterialType => ConnectorMaterialType.SteelPlate;

        public string Description { get; set; }

        public PlateManufacturer PlateManufacturer { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

        public double Thickness { get; set; }

        public PlateGauge PlateGauge { get; set; }

        public StrengthGrade StrengthGrade { get; set; }

        public bool Galvinized { get; set; }

        public double TeethPerSquareInch { get; set; }
    }
}
