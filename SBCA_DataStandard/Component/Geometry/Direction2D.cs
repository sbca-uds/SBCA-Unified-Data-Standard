namespace SBCA.UnifiedDataStandard.Component.Geometry
{
    /// <summary>
    /// A two-dimensional direction in a Cartesian coordinate system following the right-hand rule.
    /// </summary>
    public class Direction2D
    {
        /// <summary>
        /// The X component of the direction, with positive X meaning right.
        /// </summary>
        public double X { get; set; }
        
        /// <summary>
        /// The Y component of the direction, with positive Y meaning up.
        /// </summary>
        public double Y { get; set; }

        public Vector2D ToVector() => new Vector2D { X = X, Y = Y };

        public Vector2D ToNormalizedVector() => ToVector().Normalize();
    }
}
