using System;

namespace Approximation.Configuration.Interpolation.RadialBasis
{
    /// <summary>
    /// Defines a static class that validates and resolves an instance of 
    /// <see cref="RadialBasisOptions"/> into a 
    /// <see cref="RadialBasisConfiguration"/>.
    /// </summary>
    [Obsolete("Not yet implemented.", false)]
    internal class RadialBasisOptionsResolver
    {
        /// <summary>
        /// Validate and resolve <paramref name="options"/>.
        /// </summary>
        /// <param name="options">
        /// A <see cref="RadialBasisOptions"/> object that has not been validated
        /// or resolved.
        /// </param>
        /// <returns>
        /// A <see cref="RadialBasisConfiguration"/> object created by validating
        /// and resolving <paramref name="options"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="options"/> is null.
        /// </exception>
        public static RadialBasisConfiguration Resolve(RadialBasisOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            Validate(options);

            // TODO: fill out as radial basis is implemented.

            return new RadialBasisConfiguration();
        }

        /// <summary>
        /// Validate that the Radial basis options are valid.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void Validate(RadialBasisOptions options)
        {
            // TODO: fill out as radial basis is implemented.

            throw new NotImplementedException();
        }
    }
}
