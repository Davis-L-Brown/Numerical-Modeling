using Approximation.Configuration.Input;
using Approximation.Configuration.Interpolation;
using Approximation.Configuration.Output;
using System;

namespace Approximation.Configuration
{
    /// <summary>
    /// Class responsible for resolving <see cref="InterpolantOptions"/>
    /// into a <see cref="InterpolantConfiguration"/>.
    /// </summary>
    internal static class InterpolantOptionsResolver
    {
        /// <summary>
        /// Resolve consumer facing <see cref="InterpolantOptions"/> into 
        /// resolved <see cref="InterpolantConfiguration"/>.
        /// </summary>
        /// <param name="options">
        /// The consumer facing interpolant options object.
        /// </param>
        /// <returns>
        /// A <see cref="InterpolantConfiguration"/> object, created by
        /// validating and resolving <paramref name="options"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="options"/> is null.
        /// </exception>
        public static InterpolantConfiguration Resolve(
            InterpolantOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var input = InputOptionsResolver.Resolve(options.Input);
            var output = OutputOptionsResolver.Resolve(options.Output);
            var interpolation = InterpolationOptionsResolver.Resolve(options.Interpolation);
            //var extrapolation = ExtrapolationOptionsResolver.Resolve(options.Extrapolation);

            //return new Resolved.InterpolantOptions(
            //    input,
            //    output,
            //    interpolation,
            //    extrapolation);

            return new InterpolantConfiguration(
                input, output, interpolation);
        }
    }
}
