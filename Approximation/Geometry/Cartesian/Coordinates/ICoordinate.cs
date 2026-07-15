namespace Approximation.Geometry.Cartesian.Coordinates
{
    /// <summary>
    /// Represents a coordinate in cartesian space.
    /// </summary>
    internal interface ICoordinate { }


    /// <summary>
    /// Represents a coordinate in 1D space.
    /// </summary>
    internal interface ICoordinate1D : ICoordinate
    {
        /// <summary>
        /// The X location of this cartesian coordinate.
        /// </summary>
        double X { get; }
    }


    /// <summary>
    /// Represents a coordinate in 2D space.
    /// </summary>
    internal interface ICoordinate2D : ICoordinate1D
    {
        /// <summary>
        /// The Y location of this cartesian coordinate.
        /// </summary>
        double Y { get; }
    }


    /// <summary>
    /// Represents a coordinate in 3D space.
    /// </summary>
    internal interface ICoordinate3D : ICoordinate2D
    {
        /// <summary>
        /// The Z location of this cartesian coordinate.
        /// </summary>
        double Z { get; }
    }
}
