using System;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.Connectors.ConnectorMaterials;
using SBCA.UnifiedDataStandard.Component.Geometry;

namespace SBCA.UnifiedDataStandard.Component.Connectors
{
    public interface IConnector
    {
        Guid Guid { get; }

        string Name { get; }

        Guid MaterialGuid { get; }
        [JsonIgnore]
        IConnectorMaterial ConnectorMaterial { get; }
        ConnectorMaterialType ConnectorMaterialType { get; }
        bool FieldInstalled { get; }

        Point3D Center { get; set; }
        Direction3D LengthDirection { get; set; }
        Direction3D WidthDirection { get; set; }
        Direction3D ThicknessDirection { get; set; }

        Polygon2D Geometry2D();
        Polyhedron Geometry3D();
    }
}
