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
    /// Defines a triangle in 2D cartesian space.
    /// </summary>
    /// <typeparam name="TVertex">
    /// A vertex in 2D cartesian space.
    /// <br/>
    /// Must be an inheritor of <see cref="IPoint2D"/>.
    /// </typeparam>
    public class Triangle2D<TVertex> : ITriangle<TVertex>
        where TVertex : IPoint2D
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
        public LineSegment2D<TVertex> E1 { get; }
        /// <inheritdoc/>
        ILineSegment<TVertex> ITriangle<TVertex>.E1 => E1;

        /// <summary>
        /// Gets the edge opposite angle theta 2.
        /// </summary>
        public LineSegment2D<TVertex> E2 { get; }
        /// <inheritdoc/>
        ILineSegment<TVertex> ITriangle<TVertex>.E2 => E2;

        /// <summary>
        /// Gets the edge opposite angle theta 3.
        /// </summary>
        public LineSegment2D<TVertex> E3 { get; }
        /// <inheritdoc/>
        ILineSegment<TVertex> ITriangle<TVertex>.E3 => E3;


        public IPoint2D Centroid { get; }
        /// <inheritdoc/>
        IPoint ITriangle<TVertex>.Centroid => Centroid;

        /// <summary>
        /// The signed area of the triangle.
        /// </summary>
        public double SignedArea { get; }

        /// <inheritdoc/>
        public double Area { get; }


        /// <summary>
        /// Create a new instance of <see cref="Triangle2D{TVertex}"/>.
        /// </summary>
        public Triangle2D(
            TVertex v1, TVertex v2, TVertex v3,
            double relativeDegeneracyTolerance = TriangleValidator.DefaultDegeneracyTolerance)
        {
            // Assign the vertices
            V1 = v1 == null ? throw new ArgumentNullException(nameof(v1)) : v1;
            V2 = v2 == null ? throw new ArgumentNullException(nameof(v2)) : v2;
            V3 = v3 == null ? throw new ArgumentNullException(nameof(v3)) : v3;

            // Check for degeneracy using doubled area
            Vector2D v12 = Vector2D.FromPoints(V1, V2);
            Vector2D v13 = Vector2D.FromPoints(V1, V3);
            Vector2D v23 = Vector2D.FromPoints(V2, V3);

            // use V12 & V13 to calculate cross product
            // because they have the same origin
            double signedDoubledArea = Vector2D.Cross(v12, v13);
            double doubledArea = Math.Abs(signedDoubledArea);

            if (TriangleValidator.IsDegenerate(
                doubledArea,
                v12.MagnitudeSquared,
                v13.MagnitudeSquared,
                v23.MagnitudeSquared,
                relativeDegeneracyTolerance))
                throw new DegenerateTriangleException();

            // Calculate and assinge signed area
            SignedArea = 0.5 * signedDoubledArea;

            // Assign area
            Area = Math.Abs(SignedArea);

            // Assign the edges
            E1 = new LineSegment2D<TVertex>(V2, V3);
            E2 = new LineSegment2D<TVertex>(V3, V1);
            E3 = new LineSegment2D<TVertex>(V1, V2);

            // Assgin the centroid 
            var cx = (V1.X + V2.X + V3.X) / 3;
            var cy = (V1.Y + V2.Y + V3.Y) / 3;
            Centroid = new Point2D(cx, cy);

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
    /// Defines a triangle in 2D cartesian space.
    /// </summary>
    public class Triangle2D : Triangle2D<IPoint2D>
    {
        /// <summary>
        /// Create a new instance of <see cref="Triangle2D"/>.
        /// </summary>
        public Triangle2D(
            IPoint2D v1, IPoint2D v2, IPoint2D v3,
            double relativeDegeneracyTolerance = TriangleValidator.DefaultDegeneracyTolerance)
            : base(v1, v2, v3, relativeDegeneracyTolerance) { }
    }
}
