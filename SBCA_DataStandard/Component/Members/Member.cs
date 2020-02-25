using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.Geometry;
using SBCA.UnifiedDataStandard.Component.Members.MemberMaterials;

namespace SBCA.UnifiedDataStandard.Component.Members
{
    /// <summary>
    /// A piece of wood that is used in a component.
    /// </summary>
    public class Member : IMember
    {
        public Guid Guid { get; set; }

        /// <summary>
        /// A <c>string</c> that uniquely identifies this member from other members in the component.
        /// </summary>
        public string Name { get; set; }

        public bool IsStructural { get; set; }

        /// <summary>
        /// A member type describing how this member is used in the component.
        /// </summary>
        public MemberType MemberType { get; set; }

        /// <summary>
        /// A reference to a material in the <c>MaterialTypeCollections</c> property of the component. 
        /// </summary>
        public Guid MaterialGuid { get; set; }

        [JsonIgnore]
        public Lumber Lumber { get; set; }

        [JsonIgnore] 
        public IMemberMaterial Material => Lumber;

        public string MaterialDescription { get; set; }

        public MemberMaterialType MaterialType => MemberMaterialType.Lumber;

        public bool FieldInstalled { get; set; }

        public double StockLength { get; set; }

        public MemberGeometryType MemberGeometryType => MemberGeometryType.Normal;

        /// <summary>
        /// The out-of-plane dimension of the member. Should correspond to the opposite dimension of the lumber as the
        /// width.
        /// </summary>
        public double Thickness { get; set; }

        /// <summary>
        /// The vertices that make up the base of the member in counter-clockwise order.
        /// </summary>
        public List<Point2D> BaseVertices { get; set; } = new List<Point2D>();

        /// <summary>
        /// The vertices that make up the end of the member in counter-clockwise order.
        /// </summary>
        public List<Point2D> EndVertices { get; set; } = new List<Point2D>();

        /// <summary>
        /// The faces of the bevel cuts that make up the base of the member. The vertices of each face begin with the
        /// bottom-most vertex that is closest to the XY plane and proceeds in counter-clockwise order. The cuts should
        /// be in order from closest to XY plane to further away.
        /// </summary>
        public List<Polygon3D> BaseBevelCuts { get; set; } = new List<Polygon3D>();
        
        /// <summary>
        /// The faces of the bevel cuts that make up the end of the member. The vertices of each face begin with the
        /// bottom-most vertex that is closest the XY plane and proceeds in counter-clockwise order. The cuts should
        /// be in order from closest to XY plane to further away.
        /// </summary>
        public List<Polygon3D> EndBevelCuts { get; set; } = new List<Polygon3D>();

        public Polygon2D Geometry2D()
        {
            return new Polygon2D
            {
                Vertices = BaseVertices.Concat(EndVertices).ToList(),
            };
        }

        public Polyhedron Geometry3D()
        {
            var baseVertices3D = BaseVertices.Select(baseVertex => baseVertex.ToPoint3D()).ToList();
            var endVertices3D = EndVertices.Select(endVertex => endVertex.ToPoint3D()).ToList();

            var zeroBaseVertices = BaseBevelCuts.Any()
                ? BaseBevelCuts.SelectMany(bevelCuts => bevelCuts.Vertices.Where(vertex => Math.Abs(vertex.Z) < 0.001))
                : baseVertices3D;
            var zeroEndVertices = EndBevelCuts.Any()
                ? EndBevelCuts.SelectMany(bevelCuts => bevelCuts.Vertices.Where(vertex => Math.Abs(vertex.Z) < 0.001))
                : endVertices3D;
            var zeroFace = new Polygon3D {Vertices = zeroBaseVertices.Concat(zeroEndVertices).ToList()};

            var thicknessVector = new Vector3D {X = 0, Y = 0, Z = Thickness};

            var baseFaces = BaseBevelCuts.Any()
                ? BaseBevelCuts
                : baseVertices3D.Zip(baseVertices3D.Skip(1), (baseVertex, endVertex) => new Polygon3D
                {
                    Vertices = new List<Point3D>
                    {
                        baseVertex,
                        endVertex,
                        endVertex + thicknessVector,
                        baseVertex + thicknessVector,
                    }
                }).ToList();

            var endFaces = EndBevelCuts.Any()
                ? EndBevelCuts
                : endVertices3D.Zip(endVertices3D.Skip(1), (baseVertex, endVertex) => new Polygon3D
                {
                    Vertices = new List<Point3D>
                    {
                        baseVertex,
                        endVertex,
                        endVertex + thicknessVector,
                        baseVertex + thicknessVector,
                    }
                });

            var baseToEndBaseVertices = BaseBevelCuts.Any()
                ? BaseBevelCuts.Select(cut => cut.Vertices[1]).Append(BaseBevelCuts.Last().Vertices[0])
                : new List<Point3D>
                {
                    baseVertices3D.Last() + thicknessVector,
                    baseVertices3D.Last(),
                };

            var baseToEndEndVertices = EndBevelCuts.Any()
                ? EndBevelCuts.Select(cut => cut.Vertices[3]).Append(EndBevelCuts.Last().Vertices[0])
                : new List<Point3D>
                {
                    endVertices3D.First(),
                    endVertices3D.First() + thicknessVector,
                };

            var baseToEndFace = new Polygon3D
            {
                Vertices = baseToEndBaseVertices.Concat(baseToEndEndVertices).ToList(),
            };

            var endToBaseEndVertices = EndBevelCuts.Any()
                ? EndBevelCuts.Select(cut => cut.Vertices[2]).Append(EndBevelCuts.Last().Vertices[1])
                : new List<Point3D>
                {
                    endVertices3D.Last() + thicknessVector,
                    endVertices3D.Last()
                };

            var endToBaseBaseVertices = BaseBevelCuts.Any()
                ? BaseBevelCuts.Select(cut => cut.Vertices[3]).Append(BaseBevelCuts.Last().Vertices[2])
                : new List<Point3D>
                {
                    baseVertices3D.First(),
                    baseVertices3D.First() + thicknessVector,
                };

            var endToBaseFace = new Polygon3D
            {
                Vertices = endToBaseEndVertices.Concat(endToBaseBaseVertices).ToList(),
            };

            var thicknessBaseVertices = BaseBevelCuts.Any()
                ? BaseBevelCuts.SelectMany(bevelCuts =>
                    bevelCuts.Vertices.Where(vertex => Math.Abs(vertex.Z - Thickness) < 0.001))
                : ((IEnumerable<Point3D>) baseVertices3D).Reverse().Select(vertex => vertex + thicknessVector);
            var thicknessEndVertices = EndBevelCuts.Any()
                ? EndBevelCuts.SelectMany(bevelCuts =>
                    bevelCuts.Vertices.Where(vertex => Math.Abs(vertex.Z - Thickness) < 0.001))
                : ((IEnumerable<Point3D>) endVertices3D).Reverse().Select(vertex => vertex + thicknessVector);
            var thicknessFace = new Polygon3D {Vertices = thicknessBaseVertices.Concat(thicknessEndVertices).ToList()};

            return new Polyhedron
            {
                Faces = baseFaces.Concat(endFaces).Prepend(zeroFace).Prepend(baseToEndFace).Prepend(endToBaseFace)
                    .Prepend(thicknessFace).ToList(),
            };
        }
    }
}
