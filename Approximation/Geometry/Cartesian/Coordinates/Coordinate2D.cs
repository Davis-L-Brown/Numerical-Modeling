namespace Approximation.Geometry.Cartesian.Coordinates
{
    /// <summary>
    /// Represents a coordinate in 2D cartesian space. For more information,
    /// see <see cref="ICoordinate2D"/>.
    /// </summary>
    internal readonly struct Coordinate2D : ICoordinate2D
    {
        /// <inheritdoc/>
        public double X { get; }

        /// <inheritdoc/>
        public double Y { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate2D"/> struct.
        /// </summary>
        public Coordinate2D(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
