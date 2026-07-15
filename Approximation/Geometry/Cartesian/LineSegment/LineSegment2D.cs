using Approximation.Geometry.Cartesian.Coordinates;
using System;

namespace Approximation.Geometry.Cartesian.LineSegment
{
    /// <summary>
    /// Represents a line segment in 2D cartesian space.
    /// </summary>
    /// <typeparam name="TCoordinate">
    /// Represents a coordinate in Cartesian space.
    /// <br/>
    /// Must be an inheritor of <see cref="ICoordinate2D"/>.
    /// </typeparam>
    internal readonly struct LineSegment2D<TCoordinate> : ILineSegment<TCoordinate>
        where TCoordinate : ICoordinate2D
    {
        /// <inheritdoc/>
        public TCoordinate StartPoint { get; }

        /// <inheritdoc/>
        public TCoordinate EndPoint { get; }

        /// <inheritdoc/>
        public double Length { get; }

        /// <inheritdoc/>
        public double LengthSquared { get; }

        /// <summary>
        /// Create an instance of the <see cref="LineSegment2D{TCoordinate}"/> struct.
        /// </summary>
        public LineSegment2D(TCoordinate start, TCoordinate end)
        {
            StartPoint = start;
            EndPoint = end;
            Length = Math.Sqrt(
                (end.X - start.X) * (end.X - start.X) +
                (end.Y - start.Y) * (end.Y - start.Y));
            LengthSquared = Length * Length;
        }
    }
}
