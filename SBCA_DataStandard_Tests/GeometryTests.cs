using System;
using NUnit.Framework;
using SBCA.UnifiedDataStandard.Component.Geometry;

namespace SBCA.UnifiedDataStandard.Tests
{
    [TestFixture]
    public class GeometryTests
    {
        [Test]
        public void Points()
        {
            // Default Value Test
            var defaultPoint = new Point3D();
            var zeroPoint = new Point3D(){X = 0.0, Y = 0.0, Z = 0.0};

            Assert.AreEqual(defaultPoint.X, zeroPoint.X);
            Assert.AreEqual(defaultPoint.Y, zeroPoint.Y);
            Assert.AreEqual(defaultPoint.Z, zeroPoint.Z);

            // Constructor Test
            var pointNonZero = new Point3D(){X = 1.2, Y = 3.4, Z = 5.6};

            Assert.AreEqual(1.2, pointNonZero.X);
            Assert.AreEqual(3.4, pointNonZero.Y);
            Assert.AreEqual(5.6, pointNonZero.Z);
        }

        [Test]
        public void Vectors()
        {
            // Default Value Test
            var vectorDefault = new Vector3D();
            var vectorZero = new Vector3D(){X = 0.0, Y = 0.0, Z = 0.0};

            Assert.AreEqual(vectorDefault.X, vectorZero.X);
            Assert.AreEqual(vectorDefault.Y, vectorZero.Y);
            Assert.AreEqual(vectorDefault.Z, vectorZero.Z);

            // Constructor Test
            var vectorNonZero = new Vector3D() {X =1.2, Y =3.4, Z=5.6};

            Assert.AreEqual(1.2, vectorNonZero.X);
            Assert.AreEqual(3.4, vectorNonZero.Y);
            Assert.AreEqual(5.6, vectorNonZero.Z);
            Assert.AreEqual(Math.Sqrt(1.2 * 1.2 + 3.4 * 3.4 + 5.6 * 5.6), vectorNonZero.Magnitude());

            // Normalize Test
            var normalizedVector = vectorNonZero.Normalize();
            Assert.AreEqual(1.0, normalizedVector.Magnitude());
        }
    }
}
