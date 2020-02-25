using System;
using System.Collections.Generic;
using SBCA.UnifiedDataStandard.Component.Geometry;

namespace SBCA.UnifiedDataStandard.Component.Bearings
{
    public interface IBearing
    {
        /// <summary>
        /// Unique identifier for this bearing.
        /// </summary>
        Guid Guid { get; }
        string Description { get; }
        List<Guid> InstallationHardwareGuids { get; }

        LineSegment2D Geometry2D();
        Polygon3D Geometry3D();
    }
}
