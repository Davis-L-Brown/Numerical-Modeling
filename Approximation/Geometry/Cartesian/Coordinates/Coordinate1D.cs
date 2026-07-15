namespace Approximation.Geometry.Cartesian.Coordinates
{
    /// <summary>
    /// Represents a coordinate in 1D cartesian space. For more information,
    /// see <see cref="ICoordinate1D"/>.
    /// </summary>
    internal readonly struct Coordinate1D : ICoordinate1D
    {
        /// <inheritdoc/>
        public double X { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate1D"/> struct.
        /// </summary>
        public Coordinate1D(double x)
        {
            X = x;
        }
    }
}