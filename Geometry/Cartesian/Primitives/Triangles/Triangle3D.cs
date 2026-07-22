using Geometry.Cartesian.Points;
using Geometry.Cartesian.Primitives.LineSegments;
using Geometry.Cartesian.Primitives.Triangles.Exceptions;
using Geometry.Cartesian.Primitives.Triangles.Internal;
using Geometry.Cartesian.Primitives.Vectors;
using Geometry.Quantities.Angles;
using System;

namespace Geometry.Cartesian.Primitives.Triangles
{
    /// <summary>
    /// Defines a triangle in 3D cartesian space.
    /// </summary>
    /// <typeparam name="TVertex">
    /// A vertex in 3D cartesian space.
    /// <br/>
    /// Must be an inheritor of <see cref="IPoint3D"/>.
    /// </typeparam>
    public class Triangle3D<TVertex> : ITriangle<TVertex>
        where TVertex : IPoint3D
    {
        /// <inheritdoc/>
        public TVertex V1 { get; }

        /// <inheritdoc/>
        public TVertex V2 { get; }

        /// <inheritdoc/>
        public TVertex V3 { get; }


        /// <inheritdoc/>
        public Angle Theta1 { get; }

        /// <inheritdoc/>
        public Angle Theta2 { get; }

        /// <inheritdoc/>
        public Angle Theta3 { get; }


        /// <summary>
        /// Gets the edge opposite angle theta 1.
        /// </summary>
        public LineSegment3D<TVertex> E1 { get; }
        /// <inheritdoc/>
        ILineSegment<TVertex> ITriangle<TVertex>.E1 => E1;

        /// <summary>
        /// Gets the edge opposite angle theta 2.
        /// </summary>
        public LineSegment3D<TVertex> E2 { get; }
        /// <inheritdoc/>
        ILineSegment<TVertex> ITriangle<TVertex>.E2 => E2;

        /// <summary>
        /// Gets the edge opposite angle theta 3.
        /// </summary>
        public LineSegment3D<TVertex> E3 { get; }
        /// <inheritdoc/>
        ILineSegment<TVertex> ITriangle<TVertex>.E3 => E3;


        public IPoint3D Centroid { get; }
        /// <inheritdoc/>
        IPoint ITriangle<TVertex>.Centroid => Centroid;

        /// <inheritdoc/>
        public double Area { get; }


        /// <summary>
        /// Create a new instance of <see cref="Triangle3D{TVertex}"/>.
        /// </summary>
        public Triangle3D(
            TVertex v1, TVertex v2, TVertex v3,
            double relativeDegeneracyTolerance = TriangleValidator.DefaultDegeneracyTolerance)
        {
            // Assign the vertices
            V1 = v1 == null ? throw new ArgumentNullException(nameof(v1)) : v1;
            V2 = v2 == null ? throw new ArgumentNullException(nameof(v2)) : v2;
            V3 = v3 == null ? throw new ArgumentNullException(nameof(v3)) : v3;

            // Check for degeneracy using doubled area
            Vector3D v12 = Vector3D.FromPoints(V1, V2);
            Vector3D v13 = Vector3D.FromPoints(V1, V3);
            Vector3D v23 = Vector3D.FromPoints(V2, V3);

            // the magnitude of V12 x V13 is the area of the parallelogram
            // spanned by the vectors
            Vector3D doubledAreaVector = Vector3D.Cross(v12, v13);
            double doubledArea = doubledAreaVector.Magnitude;

            if (TriangleValidator.IsDegenerate(
                doubledArea,
                v12.MagnitudeSquared,
                v13.MagnitudeSquared,
                v23.MagnitudeSquared,
                relativeDegeneracyTolerance))
                throw new DegenerateTriangleException();



            // Calculate and assign area
            Area = doubledArea * 0.5;

            // Assign the edges
            E1 = new LineSegment3D<TVertex>(V2, V3);
            E2 = new LineSegment3D<TVertex>(V3, V1);
            E3 = new LineSegment3D<TVertex>(V1, V2);

            // Assgine the centroid 
            var cx = (V1.X + V2.X + V3.X) / 3;
            var cy = (V1.Y + V2.Y + V3.Y) / 3;
            var cz = (V1.Z + V2.Z + V3.Z) / 3;
            Centroid = new Point3D(cx, cy, cz);

            /************************************************************************
             * Get the angles using law of cosines
             * If you know the length of Edge A, B, and C, you can calculate θa via:
             * θa = cos^-1((Eb^2 + Ec^2 - Ea^2) / (2 * Eb * Ec))
             ************************************************************************/
            Theta1 = TriangleMath.GetInteriorAngle(E2.Length, E3.Length, E1.Length);
            Theta2 = TriangleMath.GetInteriorAngle(E3.Length, E1.Length, E2.Length);
            Theta3 = TriangleMath.GetInteriorAngle(E1.Length, E2.Length, E3.Length);
        }
    }



    /// <summary>
    /// Defines a triangle in 3D cartesian space.
    /// </summary>
    public class Triangle3D : Triangle3D<IPoint3D>
    {
        /// <summary>
        /// Create a new instance of <see cref="Triangle3D"/>.
        /// </summary>
        public Triangle3D(
            IPoint3D v1, IPoint3D v2, IPoint3D v3,
            double relativeDegeneracyTolerance = TriangleValidator.DefaultDegeneracyTolerance)
            : base (v1, v2, v3, relativeDegeneracyTolerance) { }
    }
}
