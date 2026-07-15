using Interpolant.Configuration.Input.Enums;

namespace Interpolant.Configuration.Input
{
    /// <summary>
    /// Defines input options for an interpolator object.
    /// </summary>
    public sealed class InputOptions
    {
        /// <summary>
        /// Gets the duplicate coordinate specified by the consumer.
        /// </summary>
        /// <remarks>
        /// Specifies how to handle duplicate input (x,y) coordinates
        /// passed into the interpolant.
        /// </remarks>
        public DuplicateCoordinatePolicy DuplicatePolicy { get; set; } = DuplicateCoordinatePolicy.AverageZ;
    }
}
