namespace SBCA.UnifiedDataStandard.Component.Geometry
{
    public class Point3D
    {
        // Right hand rule, orthogonal coordinates
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point2D ToPoint2D() => new Point2D { X = X, Y = Y };
        
        public static Point3D operator +(Point3D point3D, Vector3D vector3D) => new Point3D
            { X = point3D.X + vector3D.X, Y = point3D.Y + vector3D.Y, Z = point3D.Z + vector3D.Z };

        public static Point3D operator -(Point3D point3D, Vector3D vector3D) => new Point3D
            { X = point3D.X - vector3D.X, Y = point3D.Y - vector3D.Y, Z = point3D.Z - vector3D.Z };
 
        public static readonly Point3D Origin = new Point3D { X = 0.0, Y = 0.0, Z = 0.0 };

    }
}
