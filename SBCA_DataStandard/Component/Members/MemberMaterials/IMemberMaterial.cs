using System;

namespace SBCA.UnifiedDataStandard.Component.Members.MemberMaterials
{
    public enum MemberMaterialType
    {
        Lumber,
        Other,
    }

    public interface IMemberMaterial
    {
        Guid Guid { get; }
        MemberMaterialType MaterialType { get; }
        string Description { get; }
    }
}
