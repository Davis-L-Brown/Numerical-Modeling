using Approximation.Configuration.Extrapolation;
using Approximation.Configuration.Input;
using Approximation.Configuration.Interpolation;
using Approximation.Configuration.Interpolation.Simplicial;
using Approximation.Configuration.Output;

namespace Approximation.Configuration
{
    /// <summary>
    /// Defines custom options for an interpolator object.
    /// </summary>
    public sealed class InterpolantOptions
    {
        /// <summary>
        /// Represents the <see cref="InputOptions"/> for an interpolator object.
        /// </summary>
        public InputOptions Input { get; set; } = new InputOptions();

        /// <summary>
        /// Represents the <see cref="OutputOptions"/> for an interpolator object. 
        /// </summary>
        public OutputOptions Output { get; set; } = new OutputOptions();

        /// <summary>
        /// Represents the concrete <see cref="IInterpolationOptions"/> implementation 
        /// for an interpolator object.
        /// </summary>
        public IInterpolationOptions Interpolation { get; set; } = new SimplicialOptions();

        /// <summary>
        /// Represents the concrete <see cref="IExtrapolationOptions"/> implementation 
        /// for an interpolator object.
        /// </summary>
        public IExtrapolationOptions Extrapolation { get; set; }
    }
}
