using Interpolant.Configuration.Interpolation.Kriging;
using Interpolant.Configuration.Interpolation.RadialBasis;
using Interpolant.Configuration.Interpolation.Simplicial;
using System;

namespace Interpolant.Configuration.Interpolation
{
    internal static class InterpolationOptionsResolver
    {

        public static IInterpolationOptions Resolve(IInterpolationOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));


            if (options is SimplicialOptions simplicial)
            {
                simplicial.Validate();
                return simplicial;
            }


            if (options is RadialBasisOptions radialBasis)
            {
                radialBasis.Validate();
                return radialBasis;
            }


            if (options is KrigingOptions kriging)
            {
                kriging.Validate();
                return kriging;
            }

            throw new NotSupportedException(
                $"Interpolation options of type " +
                $"'{options.GetType().FullName}' are not supported.");
        }
    }
}