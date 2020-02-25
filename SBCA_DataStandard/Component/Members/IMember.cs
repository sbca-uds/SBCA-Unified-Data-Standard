using System;
using SBCA.UnifiedDataStandard.Component.Geometry;
using SBCA.UnifiedDataStandard.Component.Members.MemberMaterials;

namespace SBCA.UnifiedDataStandard.Component.Members
{
    public enum MemberGeometryType
    {
        Normal,
        Other,
    }

    public interface IMember
    {
        Guid Guid { get; }

        /// <summary>
        /// A <c>string</c> that uniquely identifies this member from other members in the component.
        /// </summary>
        string Name { get; }

        bool IsStructural { get; }
        Guid MaterialGuid { get; }
        IMemberMaterial Material { get; }

        /// <summary>
        /// A reference to a material in the <c>MaterialTypeCollections</c> property of the component. 
        /// </summary>
        MemberMaterialType MaterialType { get; }

        /// <summary>
        /// A member type describing how this member is used in the component.
        /// </summary>
        MemberType MemberType { get; }
        MemberGeometryType MemberGeometryType { get; }

        Polygon2D Geometry2D();
        Polyhedron Geometry3D();
    }
}
