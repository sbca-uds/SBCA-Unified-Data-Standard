using System;

namespace SBCA.UnifiedDataStandard.Component.Connectors.ConnectorMaterials
{
    public enum ConnectorMaterialType
    {
        SteelPlate,
        PlywoodGusset,
    }

    public interface IConnectorMaterial
    {
        Guid Guid { get; }
        ConnectorMaterialType MaterialType { get; }
        string Description { get; }
    }
}
