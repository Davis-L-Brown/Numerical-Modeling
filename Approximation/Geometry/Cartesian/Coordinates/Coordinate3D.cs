namespace Approximation.Geometry.Cartesian.Coordinates
{
    /// <summary>
    /// Represents a coordinate in 3D cartesian space. For more information,
    /// see <see cref="ICoordinate3D"/>.
    /// </summary>
    internal readonly struct Coordinate3D : ICoordinate3D
    {
        /// <inheritdoc/>
        public double X { get; }

        /// <inheritdoc/>
        public double Y { get; }

        /// <inheritdoc/>
        public double Z { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate3D"/> struct.
        /// </summary>
        public Coordinate3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
