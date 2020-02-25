using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.Connectors.ConnectorMaterials;
using SBCA.UnifiedDataStandard.Component.Geometry;

namespace SBCA.UnifiedDataStandard.Component.Connectors
{
    public class ConnectorPlate : IConnector
    {
        /// <summary>
        /// Unique identifier for this ConnectorPlate.
        /// </summary>
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public Guid MaterialGuid { get; set; }

        public string MaterialDescription { get; set; } = "";

        [JsonIgnore]
        public ConnectorPlateType ConnectorPlateType { get; set; }

        [JsonIgnore]
        public IConnectorMaterial ConnectorMaterial => ConnectorPlateType;

        public ConnectorMaterialType ConnectorMaterialType => ConnectorMaterialType.SteelPlate;

        public bool FieldInstalled { get; set; }

        /// <summary>
        /// The point where the center of the plate touches the member(s) to which it is connected.
        /// </summary>
        public Point3D Center { get; set; }
        
        /// <summary>
        /// The direction that corresponds to the length of the connector plate. This will also be the direction of the
        /// teeth of the plate.
        /// </summary>
        public Direction3D LengthDirection { get; set; }
        
        /// <summary>
        /// The direction that corresponds to the width of the connector plate.
        /// </summary>
        public Direction3D WidthDirection { get; set; }
        
        /// <summary>
        /// The direction that corresponds to the thickness of the connector plate.
        /// </summary>
        public Direction3D ThicknessDirection { get; set; }

        public Polygon2D Geometry2D()
        {
            var normalizedThicknessDirection = ThicknessDirection.ToNormalizedVector();

            if (normalizedThicknessDirection.IsParallelTo(Vector3D.ZAxis))
            {
                var halfLengthVector = ConnectorPlateType.Length / 2 * LengthDirection.ToDirection2D().ToNormalizedVector();
                var halfWidthVector = ConnectorPlateType.Width / 2 * LengthDirection.ToDirection2D().ToNormalizedVector();
                var center2D = Center.ToPoint2D();
                return new Polygon2D
                {
                    Vertices = new List<Point2D>
                    {
                        center2D - halfLengthVector - halfWidthVector,
                        center2D - halfLengthVector + halfWidthVector,
                        center2D + halfLengthVector + halfWidthVector,
                        center2D + halfLengthVector - halfWidthVector,
                    },
                };
            }

            throw new Exception("Connector plate cannot be displayed as a 2D polygon.");
        }

        public Polyhedron Geometry3D()
        {
            var halfLengthVector = ConnectorPlateType.Length / 2 * LengthDirection.ToNormalizedVector();
            var halfWidthVector = ConnectorPlateType.Width / 2 * WidthDirection.ToNormalizedVector();
            var thicknessVector = ConnectorPlateType.Thickness * ThicknessDirection.ToNormalizedVector();
            
            return new Polyhedron
            {
                Faces = new List<Polygon3D>
                {
                    new Polygon3D
                    {
                        Vertices = new List<Point3D>
                        {
                           Center - halfLengthVector - halfWidthVector,
                           Center - halfLengthVector + halfWidthVector,
                           Center + halfLengthVector + halfWidthVector,
                           Center + halfLengthVector - halfWidthVector,
                        },
                    },
                    new Polygon3D
                    {
                        Vertices = new List<Point3D>
                        {
                            Center - halfLengthVector - halfWidthVector,
                            Center - halfLengthVector + halfWidthVector,
                            Center - halfLengthVector + halfWidthVector + thicknessVector,
                            Center - halfLengthVector - halfWidthVector + thicknessVector,
                        }
                    },
                    new Polygon3D
                    {
                        Vertices = new List<Point3D>
                        {
                            Center - halfLengthVector + halfWidthVector,
                            Center + halfLengthVector + halfWidthVector,
                            Center + halfLengthVector + halfWidthVector + thicknessVector,
                            Center - halfLengthVector + halfWidthVector + thicknessVector,
                        }
                    },
                    new Polygon3D
                    {
                        Vertices = new List<Point3D>
                        {
                            Center + halfLengthVector + halfWidthVector,
                            Center + halfLengthVector - halfWidthVector,
                            Center + halfLengthVector - halfWidthVector + thicknessVector,
                            Center + halfLengthVector + halfWidthVector + thicknessVector,
                        }
                    },
                    new Polygon3D
                    {
                        Vertices = new List<Point3D>
                        {
                            Center + halfLengthVector - halfWidthVector,
                            Center - halfLengthVector - halfWidthVector,
                            Center - halfLengthVector - halfWidthVector + thicknessVector,
                            Center + halfLengthVector - halfWidthVector + thicknessVector,
                        }
                    },
                    new Polygon3D
                    {
                        Vertices = new List<Point3D>
                        {
                            Center + halfLengthVector - halfWidthVector + thicknessVector,
                            Center + halfLengthVector + halfWidthVector + thicknessVector,
                            Center - halfLengthVector + halfWidthVector + thicknessVector,
                            Center - halfLengthVector - halfWidthVector + thicknessVector,
                        }
                    },
                },
            };
        }
    }
}
