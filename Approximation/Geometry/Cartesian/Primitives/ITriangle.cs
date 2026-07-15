using Approximation.Geometry.Cartesian.Coordinates;
using Approximation.Geometry.Cartesian.LineSegment;

namespace Approximation.Geometry.Cartesian.Primitives
{
    /// <summary>
    /// Represents a triangle.
    /// </summary>
    /// <remarks>
    /// Can only exist in 2D or higher.<br/>
    /// If a triangle is created from vertices in a higher dimensionality,
    /// data outside of the 2 dimensions required to create the triangle will
    /// not be retained in the triangle object.
    /// </remarks>
    /// <typeparam name="TVertex">
    /// Represents the vertices of the triangle.
    /// <br/>
    /// Must be an inheritor of <see cref="ICoordinate2D"/>.
    /// </typeparam>
    /// <typeparam name="TEdge">
    /// Represents the edge of the triangle.
    /// <br/>
    /// Must be an inheritor of <see cref="ILineSegment{TVertex}"/>.
    /// </typeparam>
    internal interface ITriangle<out TVertex, out TEdge>
        where TVertex : ICoordinate2D
        where TEdge : ILineSegment<TVertex>
    {
        /// <summary>
        /// Get vertex 1 (or A).
        /// </summary>
        TVertex V1 { get; }

        /// <summary>
        /// Get vertex 2 (or B).
        /// </summary>
        TVertex V2 { get; }

        /// <summary>
        /// Get vertex 3 (or C).
        /// </summary>
        TVertex V3 { get; }


        /// <summary>
        /// The angle corresponding to <see cref="V1"/>.
        /// </summary>
        double Theta1 { get; }

        /// <summary>
        /// The angle corresponding to <see cref="V2"/>.
        /// </summary>
        double Theta2 { get; }

        /// <summary>
        /// The angle corresponding to <see cref="V3"/>.
        /// </summary>
        double Theta3 { get; }


        /// <summary>
        /// The triangle edge opposite angle theta 1.
        /// </summary>
        TEdge E1 { get; }

        /// <summary>
        /// The triangle edge opposite angle theta 2.
        /// </summary>
        TEdge E2 { get; }

        /// <summary>
        /// The triangle edge opposite angle theta 3.
        /// </summary>
        TEdge E3 { get; }


        /// <summary>
        /// The center of the triangle.
        /// </summary>
        ICoordinate2D Centroid { get; }

        /// <summary>
        /// The area of the triangle.
        /// </summary>
        double Area { get; }
    }
}
