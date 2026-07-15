using System;

namespace Interpolant.Configuration.Interpolation.Kriging
{
    /// <summary>
    /// Defines a concrete instance of <see cref="IInterpolationOptions"/> for
    /// an interpolator object using Kriging interpolation. 
    /// </summary>
    public sealed class KrigingOptions : IInterpolationOptions
    {
        /// <inheritdoc/>
        public InterpolationMethod Method =>
            InterpolationMethod.Kriging;


        /// <summary>
        /// Create a new instance of <see cref="KrigingOptions"/>.
        /// </summary>
        public KrigingOptions()
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
