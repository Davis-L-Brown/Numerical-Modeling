using Geometry.Cartesian.Points;
using Geometry.Cartesian.Primitives.Triangles;
using Geometry.Cartesian.Primitives.Triangles.Exceptions;
using Geometry.Quantities.Angles;
using System.Security.Cryptography.X509Certificates;

namespace Geometry.Tests.Cartesian.Primitives.Triangles
{
    [TestClass]
    public sealed class Triangle2DTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowWhen_VerticesNull()
        {
            // need to test all of the points individually, and the constructor
            // verifies them in sequential order. 
            IPoint2D? p1 = null;
            IPoint2D? p2 = null;
            IPoint2D? p3 = null;

            // if A is null
            Assert.Throws<ArgumentNullException>(() => new Triangle2D(p1, p2, p3));

            // if B is null
            p1 = new Point2D(0, 0);
            Assert.Throws<ArgumentNullException>(() => new Triangle2D(p1, p2, p3));

            // if C is null
            p2 = new Point2D(1, 0);
            Assert.Throws<ArgumentNullException>(() => new Triangle2D(p1, p2, p3));
        }

        [TestMethod]
        public void Constructor_ShouldThrowWhen_VerticeAreCollinear()
        {
            IPoint2D p1 = new Point2D(0, 0);
            IPoint2D p2 = new Point2D(1, 0);
            IPoint2D p3 = new Point2D(2, 0);

            Assert.Throws<DegenerateTriangleException>(() =>
                new Triangle2D(p1, p2, p3));

            IPoint2D A = new Point2D(0, 0);
            IPoint2D B = new Point2D(0, 1);
            IPoint2D C = new Point2D(0, 3);

            Assert.Throws<DegenerateTriangleException>(() => new Triangle2D(A, B, C));

            IPoint2D X = new Point2D(0, 0);
            IPoint2D Y = new Point2D(1, 1);
            IPoint2D Z = new Point2D(2, 2);

            Assert.Throws<DegenerateTriangleException>(() => new Triangle2D(X, Y, Z));
        }

        [TestMethod]
        public void Constructor_ShouldThrowWhen_VerticesAreDuplicates()
        {
            IPoint2D A = new Point2D(0, 0);
            IPoint2D B = new Point2D(0, 0);
            IPoint2D C = new Point2D(1, 0);

            Assert.Throws<DegenerateTriangleException>(() =>
                new Triangle2D(A, B, C));
        }


        [TestMethod]
        public void Constructor_ShouldCalculateAngles()
        {
            IPoint2D A = new Point2D(0, 0);
            IPoint2D B = new Point2D(1, 0);
            IPoint2D C = new Point2D(0, 1);

            Triangle2D t = new Triangle2D(A, B, C);
            Assert.IsTrue( (Angle.Pi / 2).NearlyEquals(t.Theta1) );
            Assert.IsTrue( (Angle.Pi / 4).NearlyEquals(t.Theta2) );
            Assert.IsTrue( (Angle.Pi / 4).NearlyEquals(t.Theta3) );
        }


        [TestMethod]
        public void Constructor_ShouldCalculateArea()
        {
            IPoint2D A = new Point2D(0, 0);
            IPoint2D B = new Point2D(4, 0);
            IPoint2D C = new Point2D(0, 3);

            Triangle2D t = new Triangle2D(A, B, C);

            Assert.AreEqual(6.0, t.Area, 1e-12);
            Assert.AreEqual(6.0, t.SignedArea, 1e-12);
        }


        [TestMethod]
        public void Constructor_ShouldCalculateNegativeSignedAreaWhen_Clockwise()
        {
            IPoint2D A = new Point2D(0, 0);
            IPoint2D B = new Point2D(0, 3);
            IPoint2D C = new Point2D(4, 0);

            Triangle2D t = new Triangle2D(A, B, C);

            Assert.AreEqual(6.0, t.Area, 1e-12);
            Assert.AreEqual(-6.0, t.SignedArea, 1e-12);
        }
    }
}
