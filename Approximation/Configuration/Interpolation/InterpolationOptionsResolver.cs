using Approximation.Configuration.Interpolation.Kriging;
using Approximation.Configuration.Interpolation.RadialBasis;
using Approximation.Configuration.Interpolation.Simplicial;
using System;

namespace Approximation.Configuration.Interpolation
{
    /// <summary>
    /// Defines a static class that resolves 
    /// <see cref="IInterpolationOptions"/> into a concrete instance of 
    /// <see cref="IInterpolationConfiguration"/>.
    /// </summary>
    internal static class InterpolationOptionsResolver
    {
        /// <summary>
        /// Validate and resolve the interpolation options.<br/>
        /// </summary>
        /// <param name="options">
        /// The <see cref="IInterpolationOptions"/> object that needs to be
        /// validated and resolved.
        /// </param>
        /// <returns>
        /// A concrete implementation of <see cref="IInterpolationConfiguration"/>.
        /// This will be consumed by an <see cref="InterpolantConfiguration"/>
        /// object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the options passed in are null.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// Thrown if the interpolation method selected is not supported.
        /// This may because the method is not yet implemented, or because
        /// the selected method is not valid.
        /// </exception>
        public static IInterpolationConfiguration Resolve(IInterpolationOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            // try to resolve simplicial options
            if (options is SimplicialOptions simplicial)
            {
                return SimplicialOptionsResolver.Resolve(simplicial);
            }

            // try to resolve radial basis options
            if (options is RadialBasisOptions radialBasis)
            {
                return RadialBasisOptionsResolver.Resolve(radialBasis);
            }

            // try to resolve kriging options
            if (options is KrigingOptions kriging)
            {
                return KrigingOptionsResolver.Resolve(kriging);
            }


            throw new NotSupportedException(
                $"Interpolation options of type " +
                $"'{options.GetType().FullName}' are not supported.");
        }
    }
}