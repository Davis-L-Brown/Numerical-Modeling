using Approximation.Geometry.Cartesian.Coordinates;
using MIConvexHull;

namespace Approximation.Geometry.Interpolation
{
    /// <summary>
    /// Represents a cartesian coordinate in 3D space.
    /// </summary>
    internal sealed class InterpolationVertex : ICoordinate3D, IVertex
    {
        private readonly double[] _position;

        /// <summary>
        /// The position of the vertex.
        /// </summary>
        /// <remarks>
        /// Coordinates are indexed.
        /// <list type="bullet">
        /// <item>0 = X</item>
        /// <item>1 = Y</item>
        /// <item>2 = Z</item>
        /// </list>
        /// </remarks>
        public double[] Position => _position;

        /// <summary>
        /// Get the X position of the vertex.
        /// </summary>
        public double X => _position[0];

        /// <summary>
        /// Get the Y position of the vertex.
        /// </summary>
        public double Y => _position[1];

        /// <summary>
        /// Get the Z position of the vertex.
        /// </summary>
        public double Z => _position[2];


        /// <summary>
        /// Create an instance of an interpolation vertex.
        /// </summary>
        /// <param name="x">X coordinate of the vertex.</param>
        /// <param name="y">Y coordinate of the vertex.</param>
        /// <param name="z">Z coordinate of the vertex.</param>
        public InterpolationVertex(double x, double y, double z)
        {
            _position = new double[] { x, y, z };
        }
    }
}
