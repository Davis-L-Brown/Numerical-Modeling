using Approximation.Geometry.Cartesian.Coordinates;
using System;

namespace Approximation.Geometry.Cartesian.LineSegment
{
    /// <summary>
    /// Represents a line segment in 1D cartesian space.
    /// </summary>
    /// <typeparam name="TCoordinate">
    /// Represents a coordinate in Cartesian space.
    /// <br/>
    /// Must be an inheritor of <see cref="ICoordinate1D"/>.
    /// </typeparam>
    internal readonly struct LineSegment1D<TCoordinate> : ILineSegment<TCoordinate>
        where TCoordinate : ICoordinate1D
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
        /// Create an instance of the <see cref="LineSegment1D{TCoordinate}"/> struct.
        /// </summary>
        public LineSegment1D(TCoordinate start, TCoordinate end)
        {
            StartPoint = start;
            EndPoint = end;
            Length = Math.Abs(end.X - start.X);
            LengthSquared = Length * Length;
        }
    }
}
