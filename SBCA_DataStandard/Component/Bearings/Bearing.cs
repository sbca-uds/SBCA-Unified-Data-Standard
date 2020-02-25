using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.Geometry;
using SBCA.UnifiedDataStandard.Component.InstallationHardware;

namespace SBCA.UnifiedDataStandard.Component.Bearings
{
    /// <summary>
    /// A surface that supports members in a truss.
    /// </summary>
    public class Bearing : IBearing
    {
        /// <summary>
        /// Unique identifier for this bearing.
        /// </summary>
        public Guid Guid { get; set; }

        public string Description { get; set; } = "";

        public List<Guid> InstallationHardwareGuids { get; set; } = new List<Guid>();

        [JsonIgnore]
        public List<IInstallationHardware> InstallationHardwares { get; set; } = new List<IInstallationHardware>();

        /// <summary>
        /// The in-plane dimension of the bearing.
        /// </summary>
        public double Width { get; set; }
        
        /// <summary>
        /// The out-of-plane dimension of the bearing. This should usually match the thickness of the members that are
        /// supported by the bearing. The bearing will extrude in the positive Z direction.
        /// </summary>
        public double Thickness { get; set; }
        
        /// <summary>
        /// The two-dimensional center of the bearing.
        /// </summary>
        public Point2D Center { get; set; }

        public LineSegment2D Geometry2D()
        {
            var halfWidth = Width / 2;
            var basePoint = new Point2D { X = Center.X - halfWidth, Y = Center.Y };
            var endPoint = new Point2D { X = Center.X + halfWidth, Y = Center.Y };
            return new LineSegment2D { BasePoint = basePoint, EndPoint = endPoint };
        }

        public Polygon3D Geometry3D()
        {
            var halfWidth = Width / 2;
            return new Polygon3D
            {
                Vertices = new List<Point3D>
                {
                    new Point3D { X = Center.X - halfWidth, Y = Center.Y, Z = 0 },
                    new Point3D { X = Center.X + halfWidth, Y = Center.Y, Z = 0 },
                    new Point3D { X = Center.X + halfWidth, Y = Center.Y, Z = Thickness },
                    new Point3D { X = Center.X - halfWidth, Y = Center.Y, Z = Thickness },
                },
            };
        }
    }
}
