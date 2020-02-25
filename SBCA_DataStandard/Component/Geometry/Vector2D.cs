using System;

namespace SBCA.UnifiedDataStandard.Component.Geometry
{
    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Magnitude() => Math.Sqrt(X * X + Y * Y);

        private const double Tolerance = 0.000001;

        public Vector2D Normalize()
        {
            var magnitude = Magnitude();
            return magnitude > Tolerance
                ? new Vector2D { X = X / magnitude, Y = Y / magnitude }
                : new Vector2D();
        }

        public Vector2D Reverse() => new Vector2D { X = -X, Y = -Y };

        public static Vector2D operator *(double scalar, Vector2D vector2D) =>
            new Vector2D {X = scalar * vector2D.X, Y = scalar * vector2D.Y};
    }
}
