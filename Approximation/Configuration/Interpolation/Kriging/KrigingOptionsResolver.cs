using System;

namespace Approximation.Configuration.Interpolation.Kriging
{
    /// <summary>
    /// Defines a static class that validates and resolves an instance of 
    /// <see cref="KrigingOptions"/> into a 
    /// <see cref="KrigingConfiguration"/>.
    /// </summary>
    [Obsolete("Not yet implemented.", false)]
    internal static class KrigingOptionsResolver
    {
        /// <summary>
        /// Validate and resolve <paramref name="options"/>.
        /// </summary>
        /// <param name="options">
        /// A <see cref="KrigingOptions"/> object that has not been validated
        /// or resolved.
        /// </param>
        /// <returns>
        /// A <see cref="KrigingConfiguration"/> object created by validating
        /// and resolving <paramref name="options"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="options"/> is null.
        /// </exception>
        public static KrigingConfiguration Resolve(KrigingOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            Validate(options);

            // TODO: fill out as kriging is implemented.

            return new KrigingConfiguration();
        }

        /// <summary>
        /// Validate that the Kriging options are valid.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void Validate(KrigingOptions options)
        {
            // TODO: fill out as kriging is implemented.

            throw new NotImplementedException();
        }
    }
}
