namespace SBCA.UnifiedDataStandard.Component.Geometry
{
    /// <summary>
    /// A three-dimensional line with direction.
    /// </summary>
    public class Line3D
    {
        /// <summary>
        /// The base point of the line.
        /// </summary>
        public Point3D BasePoint { get; set; }

        /// <summary>
        /// The direction of the line.
        /// </summary>
        public Direction3D Direction { get; set; }
    }
}
