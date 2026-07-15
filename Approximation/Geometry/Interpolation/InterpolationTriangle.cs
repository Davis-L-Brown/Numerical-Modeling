using Approximation.Exceptions;
using Approximation.Geometry.Cartesian.Coordinates;
using Approximation.Geometry.Cartesian.LineSegment;
using Approximation.Geometry.Cartesian.Primitives;
using System;
using System.Diagnostics;

namespace Approximation.Geometry.Interpolation
{
    /// <summary>
    /// Defines a triangle used for triangulation methods EG: Delaunay Triangulation.
    /// </summary>
    internal class InterpolationTriangle : ITriangle<InterpolationVertex, LineSegment2D<InterpolationVertex>>
    {

        private const double RelativeDoubleAreaTolerance = 1e-12;

        /// <inheritdoc/>
        public InterpolationVertex V1 { get; }

        /// <inheritdoc/>
        public InterpolationVertex V2 { get; }

        /// <inheritdoc/>
        public InterpolationVertex V3 { get; }


        /// <inheritdoc/>
        public double Theta1 { get; }

        /// <inheritdoc/>
        public double Theta2 { get; }

        /// <inheritdoc/>
        public double Theta3 { get; }


        /// <inheritdoc/>
        public LineSegment2D<InterpolationVertex> E1 { get; }

        /// <inheritdoc/>
        public LineSegment2D<InterpolationVertex> E2 { get; }

        /// <inheritdoc/>
        public LineSegment2D<InterpolationVertex> E3 { get; }


        /// <inheritdoc/>
        public ICoordinate2D Centroid { get; }

        /// <inheritdoc/>
        public double Area => DoubleArea / 2.0;

        /// <summary>
        /// The signed double area of the triangle.
        /// </summary>
        /// <remarks>
        /// Found by taking the 2D cross product of the triangle.
        /// </remarks>
        public double SignedDoubleArea { get; }

        /// <summary>
        /// The absolute value of <see cref="SignedDoubleArea"/>.
        /// </summary>
        /// <remarks>
        /// | 2 * Area(triangle) |
        /// </remarks>
        public double DoubleArea => Math.Abs(SignedDoubleArea);

        // bounding box
        // public readonly double MinX, MaxX;
        // public readonly double MinY, MaxY;

        /// <summary>
        /// Gets the coefficient A in the planar equation z = Ax + By + C.
        /// </summary>
        public double A { get; }

        /// <summary>
        /// Gets the coefficient B in the planar equation z = Ax + By + C.
        /// </summary>
        public double B { get; }

        /// <summary>
        /// Gets the coefficient C in the planar equation z = Ax + By + C.
        /// </summary>
        public double C { get; }


        /// <summary>
        /// Create an instance of an interpolation triangle.
        /// </summary>
        /// <exception cref="DegenerateTriangleException">
        /// 
        /// </exception>
        public InterpolationTriangle(
            InterpolationVertex v1,
            InterpolationVertex v2,
            InterpolationVertex v3) :
            this(
                v1.X, v1.Y, v1.Z,
                v2.X, v2.Y, v2.Z,
                v3.X, v3.Y, v3.Z)
        { }


        /// <summary>
        /// Create an instance of an interpolation triangle.
        /// </summary>
        /// <exception cref="DegenerateTriangleException">
        /// 
        /// </exception>
        public InterpolationTriangle(
           double x1, double y1, double z1,
           double x2, double y2, double z2,
           double x3, double y3, double z3)
        {
            // Assign the vertices
            V1 = new InterpolationVertex(x1, y1, z1);
            V2 = new InterpolationVertex(x2, y2, z2);
            V3 = new InterpolationVertex(x3, y3, z3);

            // Get the edges
            E1 = new LineSegment2D<InterpolationVertex>(V2, V3);
            E2 = new LineSegment2D<InterpolationVertex>(V3, V1);
            E3 = new LineSegment2D<InterpolationVertex>(V1, V2);

            // centroid
            var cx = (x1 + x2 + x3) / 3;
            var cy = (y1 + y2 + y3) / 3;
            Centroid = new Coordinate2D(cx, cy);


            /***************************************************
             * Compute the signed double area of the triangle  *
             * by taking the 2D cross product of the triangle: *
             *       D = Cross (V2 - V1, V3 - V1)              *
             *     If D > 0 --> V1 -> V2 -> V3 is CCW          *
             *     If D < 0 --> V1 -> V2 -> V3 is CW           *
             *     If D = 0 --> Points are collinear           *
             ***************************************************/

            double dx12 = x2 - x1;
            double dy12 = y2 - y1;

            double dx13 = x3 - x1;
            double dy13 = y3 - y1;

            SignedDoubleArea = (dx12 * dy13) - (dy12 * dx13);


            /*****************************************************
             * Test to see if the triangle is collinear relative *
             *         to the coordinate scale.                  *
             * Reject collapsed or excessively thin triangles.
             *
             * Both DoubleArea and maxEdgeSquared have units of length²,
             * so this is a scale-relative geometric test:
             *
             *     DoubleArea / maxEdgeSquared <= tolerance
             *
             * This is approximately the triangle altitude divided by its
             * longest edge.      *
             *****************************************************/

            double maxEdgeSquared = Math.Max(
                E1.LengthSquared,
                Math.Max(E2.LengthSquared, E3.LengthSquared));

            if (maxEdgeSquared <= 0.0)
                throw new DegenerateTriangleException(
                    "Triangle vertices do not span an edge.");


            /***************************************************************
             * Use the double area and the relative double area tolerance
             * to determine if the triangle should be considered degenerate.
             * TODO: why?
             ****************************************************************/

            if (DoubleArea <= RelativeDoubleAreaTolerance * maxEdgeSquared)
                throw new DegenerateTriangleException(
                    "Triangle is degenerate or too thin for stable interpolation.");


            /************************************************************************
             * Get the angles using law of cosines
             * If you know the length of Edge A, B, and C, you can calculate θa via:
             * θa = cos^-1((Eb^2 + Ec^2 - Ea^2) / (2 * Eb * Ec))
             ************************************************************************/

            Theta1 = GetAngle(E2.Length, E3.Length, E1.Length);
            Theta2 = GetAngle(E3.Length, E1.Length, E2.Length);
            Theta3 = GetAngle(E1.Length, E2.Length, E3.Length);

#if DEBUG
            Debug.Assert(
                Math.Abs((Theta1 + Theta2 + Theta3) - Math.PI) <= 1e-12,
                "Triangle angles should sum to π radians.");
#else
            if (Theta1 + Theta2 + Theta3 != Math.PI)
                throw new InvalidOperationException(
                    "Triangle angle calculation failed. Calculated angle:" +
                    $"{Theta1 + Theta2 + Theta3}");
#endif


            /************************************************
             *    A, B, C are computed via Cramer's rule.   *
             *   We solve for the plane that passes exactly *
             *     through the three triangle vertices.     *
             *     z = A*x + B*y + C                        *
             *                                              *
             *    This is equivalent to solving the 3x3     *
             *            linear system:                    *
             *                                              *
             *         [x1 y1 1] [A]   [z1]                 *
             *         [x2 y2 1] [B] = [z2]                 *
             *         [x3 y3 1] [C]   [z3]                 *
             *                                              *
             * The denominator is SignedDoubleArea.         *
             * Reversing vertex order reverses both         *
             * denominator and numerators, leaving A, B,    *
             * and C unchanged.                             *
             ************************************************/

            A =
                (z1 * (y2 - y3) +
                 z2 * (y3 - y1) +
                 z3 * (y1 - y2)) / SignedDoubleArea;

            B =
                (z1 * (x3 - x2) +
                 z2 * (x1 - x3) +
                 z3 * (x2 - x1)) / SignedDoubleArea;

            C =
                (z1 * (x2 * y3 - x3 * y2) +
                 z2 * (x3 * y1 - x1 * y3) +
                 z3 * (x1 * y2 - x2 * y1)) / SignedDoubleArea;
        }



        /// <summary>
        /// Hepler used to get an angle in the triangle.
        /// </summary>
        /// <remarks>
        /// Uses the law of cosines to calculate the edge.
        /// </remarks>
        /// <param name="leftAdjacentLength">
        /// The length of the edge left-adjacent to the angle being calculated.
        /// </param>
        /// <param name="rightAdjacentLength">
        /// The length of the edge right-adjacent to the angle being calculated.
        /// </param>
        /// <param name="oppositeLength">
        /// The length of the edge opposite the angle being calculated.
        /// </param>
        /// <returns>
        /// The calculated angle.
        /// </returns>
        private static double GetAngle(
            double leftAdjacentLength,
            double rightAdjacentLength,
            double oppositeLength)
        {
            double cosine =
                ((leftAdjacentLength * leftAdjacentLength) +
                 (rightAdjacentLength * rightAdjacentLength) -
                 (oppositeLength * oppositeLength)) /
                (2.0 * leftAdjacentLength * rightAdjacentLength);

            cosine = Math.Min(1.0, Math.Max(-1.0, cosine));

            return Math.Acos(cosine);
        }
    }
}
