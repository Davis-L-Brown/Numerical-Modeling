using Geometry.Cartesian.Points;
using Geometry.Cartesian.Primitives.LineSegments;
using Geometry.Quantities.Angles;

namespace Geometry.Cartesian.Primitives.Triangles
{
    /// <summary>
    /// Represents a triangle.
    /// </summary>
    /// <remarks>
    /// Can only exist in 2D or higher.<br/>
    /// </remarks>
    /// <typeparam name="TVertex">
    /// Represents the vertices of the triangle.
    /// <br/>
    /// Should be an inheritor of <see cref="IPoint2D"/> or higher.
    /// </typeparam>
    public interface ITriangle<TVertex>
        where TVertex : IPoint 
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
        Angle Theta1 { get; }

        /// <summary>
        /// The angle corresponding to <see cref="V2"/>.
        /// </summary>
        Angle Theta2 { get; }

        /// <summary>
        /// The angle corresponding to <see cref="V3"/>.
        /// </summary>
        Angle Theta3 { get; }


        /// <summary>
        /// The triangle edge opposite angle theta 1.
        /// </summary>
        ILineSegment<TVertex> E1 { get; }

        /// <summary>
        /// The triangle edge opposite angle theta 2.
        /// </summary>
        ILineSegment<TVertex> E2 { get; }

        /// <summary>
        /// The triangle edge opposite angle theta 3.
        /// </summary>
        ILineSegment<TVertex> E3 { get; }


        /// <summary>
        /// The center of the triangle.
        /// </summary>
        IPoint Centroid { get; }

        /// <summary>
        /// The area of the triangle.
        /// </summary>
        double Area { get; }
    }
}
