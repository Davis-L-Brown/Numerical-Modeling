using System;

namespace Approximation.Configuration.Interpolation.RadialBasis
{
    /// <summary>
    /// Defines a concrete instance of <see cref="IInterpolationOptions"/> for
    /// an interpolator object using Radial Basis interpolation. 
    /// </summary>
    [Obsolete("Not yet implemented.", false)]
    public sealed class RadialBasisOptions : IInterpolationOptions
    {
        /// <inheritdoc/>
        public InterpolationMethod Method =>
            InterpolationMethod.RadialBasisFunction;
    }
}
