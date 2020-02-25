namespace SBCA.UnifiedDataStandard.Component.Geometry
{
    /// <summary>
    /// A three-dimensional direction in a Cartesian coordinate system following the right-hand rule.
    /// </summary>
    public class Direction3D
    {
        /// <summary>
        /// The X component of the direction, with positive X meaning right.
        /// </summary>
        public double X { get; set; }
        
        /// <summary>
        /// The Y component of the direction, with positive Y meaning up.
        /// </summary>
        public double Y { get; set; }
        
        /// <summary>
        /// The Z component of the direction, with positive Z meaning out.
        /// </summary>
        public double Z { get; set; }

        public Direction2D ToDirection2D() => new Direction2D { X = X, Y = Y };
        
        public Vector3D ToVector() => new Vector3D { X = X, Y = Y, Z = Z };

        public Vector3D ToNormalizedVector() => ToVector().Normalize();
    }
}
