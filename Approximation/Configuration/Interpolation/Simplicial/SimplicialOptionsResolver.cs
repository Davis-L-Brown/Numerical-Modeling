using System;

namespace Approximation.Configuration.Interpolation.Simplicial
{
    /// <summary>
    /// Defines a static class that validates and resolves an instance of 
    /// <see cref="SimplicialOptions"/> into a 
    /// <see cref="SimplicialConfiguration"/>.
    /// </summary>
    internal class SimplicialOptionsResolver
    {
        /// <summary>
        /// Validate and resolve <paramref name="options"/>.
        /// </summary>
        /// <param name="options">
        /// A <see cref="SimplicialOptions"/> object that has not been validated
        /// or resolved.
        /// </param>
        /// <returns>
        /// A <see cref="SimplicialConfiguration"/> object created by validating
        /// and resolving <paramref name="options"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="options"/> is null.
        /// </exception>
        public static SimplicialConfiguration Resolve(SimplicialOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            Validate(options);

            // TODO: fill out as simplicial is implemented.

            return new SimplicialConfiguration();
        }

        /// <summary>
        /// Validate that the simplicial options are valid.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void Validate(SimplicialOptions options)
        {
            if (!Enum.IsDefined(typeof(SimplicialOrder), options.Order))
            {
                throw new ArgumentOutOfRangeException(nameof(options.Order));
            }

            // TODO: fill out as simplicial is implemented.
        }

    }
}
