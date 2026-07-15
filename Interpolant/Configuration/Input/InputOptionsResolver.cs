using Interpolant.Configuration.Input.Enums;
using System;

namespace Interpolant.Configuration.Input
{
    /// <summary>
    /// Class responsible for resolving <see cref="InputOptions"/>
    /// into a <see cref="InputConfiguration"/>.
    /// </summary>
    internal static class InputOptionsResolver
    {
        /// <summary>
        /// Resolve consumer facing <see cref="InputOptions"/> object into 
        /// a resolved <see cref="InputConfiguration"/> object.
        /// </summary>
        /// <returns>
        /// An <see cref="InputConfiguration"/> object, created by
        /// validating and resolving <paramref name="options"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="options"/> is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="options"/> has a duplicate policy is not
        /// a valid <see cref="DuplicateCoordinatePolicy"/>.
        /// </exception>
        public static InputConfiguration Resolve(
            InputOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (!Enum.IsDefined(typeof(DuplicateCoordinatePolicy), options.DuplicatePolicy))
                throw new ArgumentOutOfRangeException(nameof(options.DuplicatePolicy));

            // TODO: expand this resolver as the input options expand

            return new Resolved.InputConfiguration(
                duplicatePolicy: options.DuplicatePolicy);
        }
    }
}
