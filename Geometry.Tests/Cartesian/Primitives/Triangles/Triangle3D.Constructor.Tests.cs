using Geometry.Cartesian.Points;
using Geometry.Cartesian.Primitives.LineSegments;
using Geometry.Cartesian.Primitives.Triangles;
using Geometry.Cartesian.Primitives.Triangles.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Tests.Cartesian.Primitives.Triangles
{
    [TestClass]
    public sealed class Triangle3DTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowWhen_VerticesNull()
        {
            // need to test all of the points individually, and the constructor
            // verifies them in sequential order. 
            IPoint3D? p1 = null;
            IPoint3D? p2 = null;
            IPoint3D? p3 = null;

            // if A is null
            Assert.Throws<ArgumentNullException>(() => new Triangle3D(p1, p2, p3));

            // if B is null
            p1 = new Point3D(0, 0, 0);
            Assert.Throws<ArgumentNullException>(() => new Triangle3D(p1, p2, p3));

            // if C is null
            p2 = new Point3D(1, 0, 0);
            Assert.Throws<ArgumentNullException>(() => new Triangle3D(p1, p2, p3));
        }


        [TestMethod]
        public void Constructor_ShouldThrowWhen_VerticesAreCollinear()
        {
            IPoint3D A = new Point3D(0, 0, 0);
            IPoint3D B = new Point3D(1, 0, 0);
            IPoint3D C = new Point3D(2, 0, 0);

            Assert.Throws<DegenerateTriangleException>(() => new Triangle3D(A, B, C));

            A = new Point3D(0, 0, 0);
            B = new Point3D(0, 1, 0);
            C = new Point3D(0, 2, 0);
            Assert.Throws<DegenerateTriangleException>(() => new Triangle3D(A, B, C));

            A = new Point3D(0, 0, 0);
            B = new Point3D(0, 0, 1);
            C = new Point3D(0, 0, 2);
            Assert.Throws<DegenerateTriangleException>(() => new Triangle3D(A, B, C));

            A = new Point3D(0, 0, 0);
            B = new Point3D(1, 1, 1);
            C = new Point3D(2, 2, 2);
            Assert.Throws<DegenerateTriangleException>(() => new Triangle3D(A, B, C));
        }


        [TestMethod]
        public void Constructor_ShouldThrowWhen_VerticesAreDuplicates()
        {
            IPoint3D A = new Point3D(0, 0, 0);
            IPoint3D B = new Point3D(0, 0, 0);
            IPoint3D C = new Point3D(1, 1, 1);
            Assert.Throws<DegenerateTriangleException>(() => new Triangle3D(A, B, C));
        }


        [TestMethod]
        public void Constructor_ShouldCalculateArea()
        {

        }


        [TestMethod]
        public void Constructor_ShouldCalculateNegativeSignedAreaWhen_Clockwise()
        {

        }
    }
}
