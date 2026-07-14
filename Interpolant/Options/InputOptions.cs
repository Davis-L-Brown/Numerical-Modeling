using Interpolant.Options.Enums;

namespace Interpolant.Options
{
    /// <summary>
    /// Defines input options for an interpolator.
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
        public DuplicateCoordinatePolicy DuplicatePolicy { get; set; }
    }
}
