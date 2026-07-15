using Approximation.Geometry.Cartesian.Coordinates;

namespace Approximation.Geometry.Cartesian.LineSegment
{
    /// <summary>
    /// Represents a line segment with a start point and an end point.
    /// </summary>
    /// <typeparam name="TCoordinate">
    /// A <see cref="ICoordinate"/> implementation, denoting what dimension the
    /// line segment exists in.
    /// </typeparam>
    internal interface ILineSegment<out TCoordinate>
        where TCoordinate : ICoordinate1D
    {
        /// <summary>
        /// The starting <see cref="ICoordinate"/>.
        /// </summary>
        TCoordinate StartPoint { get; }

        /// <summary>
        /// The ending <see cref="ICoordinate"/>.
        /// </summary>
        TCoordinate EndPoint { get; }

        /// <summary>
        /// The length of the line segment.
        /// </summary>
        double Length { get; }

        /// <summary>
        /// The length of the line segment, squared.
        /// </summary>
        double LengthSquared { get; }
    }
}
