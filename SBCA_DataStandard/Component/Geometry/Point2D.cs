namespace SBCA.UnifiedDataStandard.Component.Geometry
{
    /// <summary>
    /// A two-dimensional point in a Cartesian coordinate system following the right-hand rule.
    /// </summary>
    public class Point2D
    {
        /// <summary>
        /// The X coordinate of the point, with positive X meaning right.
        /// </summary>
        public double X { get; set; }
        
        /// <summary>
        /// The Y coordinate of the point, with positive Y meaning up.
        /// </summary>
        public double Y { get; set; }

        public Point3D ToPoint3D() => new Point3D { X = X, Y = Y, Z = 0 };

        public static Point2D operator +(Point2D point2D, Vector2D vector2D) => new Point2D
            { X = point2D.X + vector2D.X, Y = point2D.Y + vector2D.Y };

        public static Point2D operator -(Point2D point2D, Vector2D vector2D) => new Point2D
            { X = point2D.X - vector2D.X, Y = point2D.Y - vector2D.Y };
    }
}
