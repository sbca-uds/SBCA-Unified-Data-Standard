using System;

namespace SBCA.UnifiedDataStandard.Component.Geometry
{
    public class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double Magnitude() => Math.Sqrt(X * X + Y * Y + Z * Z);

        private const double Tolerance = 0.000001;

        public Vector3D Normalize()
        {
            var magnitude = Magnitude();
            return magnitude > Tolerance
                ? new Vector3D { X = X / magnitude, Y = Y / magnitude, Z = Z / magnitude }
                : new Vector3D();
        }

        public Vector3D Reverse()
        {
            return new Vector3D { X = -X, Y = -Y, Z = -Z };
        }

        public bool EqualsWithinTolerance(Vector3D otherVector)
        {
            var thisNormalized = Normalize();
            var otherNormalized = otherVector.Normalize();
            return Math.Abs(thisNormalized.X - otherNormalized.X) < Tolerance &&
                   Math.Abs(thisNormalized.Y - otherNormalized.Y) < Tolerance &&
                   Math.Abs(thisNormalized.Z - otherNormalized.Z) < Tolerance;
        }

        public bool IsParallelTo(Vector3D otherVector)
        {
            return EqualsWithinTolerance(otherVector) || Reverse().EqualsWithinTolerance(otherVector);
        }

        public Vector2D ToVector2D() => new Vector2D { X = X, Y = Y };

        public static Vector3D operator *(double scalar, Vector3D vector3D) =>
            new Vector3D { X = scalar * vector3D.X, Y = scalar * vector3D.Y, Z = scalar * vector3D.Z };

        public static readonly Vector3D XAxis = new Vector3D { X = 1.0, Y = 0.0, Z = 0.0 };
        public static readonly Vector3D YAxis = new Vector3D { X = 0.0, Y = 1.0, Z = 0.0 };
        public static readonly Vector3D ZAxis = new Vector3D { X = 0.0, Y = 0.0, Z = 1.0 };
    }
}
