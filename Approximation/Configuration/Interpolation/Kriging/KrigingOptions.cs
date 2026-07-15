using System;

namespace Approximation.Configuration.Interpolation.Kriging
{
    /// <summary>
    /// Defines a concrete instance of <see cref="IInterpolationOptions"/> for
    /// an interpolator object using Kriging interpolation. 
    /// </summary>
    [Obsolete("Not yet implemented.", false)]
    public sealed class KrigingOptions : IInterpolationOptions
    {
        /// <inheritdoc/>
        public InterpolationMethod Method =>
            InterpolationMethod.Kriging;
    }
}
