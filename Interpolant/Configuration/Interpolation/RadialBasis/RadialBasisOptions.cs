using System;

namespace Interpolant.Configuration.Interpolation.RadialBasis
{
    /// <summary>
    /// Defines a concrete instance of <see cref="IInterpolationOptions"/> for
    /// an interpolator object using Radial Basis interpolation. 
    /// </summary>
    public sealed class RadialBasisOptions : IInterpolationOptions
    {
        /// <inheritdoc/>
        public InterpolationMethod Method =>
            InterpolationMethod.RadialBasisFunction;


        /// <summary>
        /// Create a new instance of <see cref="RadialBasisOptions"/>.
        /// </summary>
        [Obsolete("Not yet implemented.", false)]
        public RadialBasisOptions()
        {
            Validate();
        }


        /// <inheritdoc/>
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
