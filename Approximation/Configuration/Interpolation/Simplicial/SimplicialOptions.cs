using System;

namespace Approximation.Configuration.Interpolation.Simplicial
{
    /// <summary>
    /// Defines a concrete instance of <see cref="IInterpolationOptions"/> for
    /// an interpolator object using simplicial interpolation. 
    /// </summary>
    public sealed class SimplicialOptions : IInterpolationOptions
    {
        /// <inheritdoc/>
        public InterpolationMethod Method =>
            InterpolationMethod.Simplicial;

        /// <summary>
        /// Get the <see cref="SimplicialOrder"/> specified by the consumer.
        /// </summary>
        public SimplicialOrder Order { get; }
    }
}
