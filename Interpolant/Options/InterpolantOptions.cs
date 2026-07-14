namespace Interpolant.Options
{
    /// <summary>
    /// Defines custom options for an interpolator.
    /// </summary>
    public sealed class InterpolantOptions
    {
        /// <summary>
        /// Represents the <see cref="OutputOptions"/> for an interpolator. 
        /// </summary>
        public OutputOptions Output { get; set; }


        /// <summary>
        /// Represents the <see cref="InputOptions"/> for an interpolator.
        /// </summary>
        public InputOptions Input { get; set; }

        /// <summary>
        /// Represents the <see cref="InterpolationOptions"/> for an interpolator.
        /// </summary>
        public InterpolationOptions Interpolation { get; set; }
    }
}
