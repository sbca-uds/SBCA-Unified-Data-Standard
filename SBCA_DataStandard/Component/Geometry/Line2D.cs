namespace SBCA.UnifiedDataStandard.Component.Geometry
{
    /// <summary>
    /// A two-dimensional line with direction.
    /// </summary>
    public class Line2D
    {
        /// <summary>
        /// The base point of the line.
        /// </summary>
        public Point2D BasePoint { get; set; }

        /// <summary>
        /// The direction of the line.
        /// </summary>
        public Direction2D Direction { get; set; }
    }
}
