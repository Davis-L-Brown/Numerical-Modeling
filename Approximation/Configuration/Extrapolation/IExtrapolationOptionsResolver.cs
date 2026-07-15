using System;

namespace Approximation.Configuration.Extrapolation
{
    /// <summary>
    /// Defines a static class that resolves
    /// <see cref="IExtrapolationOptions"/> into a concrete instance of
    /// <see cref="IExtrapolationConfiguration"/>.
    /// </summary>
    internal static class IExtrapolationOptionsResolver
    {
        /// <summary>
        /// Validate and resolve the extrapolation options.<br/>
        /// </summary>
        /// <param name="options">
        /// The <see cref="IExtrapolationOptions"/> object that needs to be
        /// validated and resolved.
        /// </param>
        /// <returns>
        /// A concrete implementation of <see cref="IExtrapolationConfiguration"/>.
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
        public static IExtrapolationConfiguration Resolve(IExtrapolationOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));



            throw new NotSupportedException(
                $"Extrapolation options of type "+
                $"'{options.GetType().FullName}' are not supported.");
        }
    }
}
