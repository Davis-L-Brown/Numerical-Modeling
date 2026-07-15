using System;

namespace Approximation.Configuration.Interpolation.Kriging
{
    /// <summary>
    /// Defines a resolved and validated <see cref="KrigingOptions"/> object.
    /// <br/>
    /// This object should be consumed by an 
    /// <see cref="InterpolantConfiguration"/> object.
    /// </summary>
    [Obsolete("Not yet implemented.", false)]
    internal sealed class KrigingConfiguration : IInterpolationConfiguration
    {
        /// <summary>
        /// Create a new instance of the <see cref="KrigingConfiguration"/> object.
        /// </summary>
        public KrigingConfiguration() { }
    }
}
