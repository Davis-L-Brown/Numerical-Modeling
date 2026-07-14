using Interpolant.Extrapolation;

namespace Interpolant.Options
{
    public sealed class ExtrapolationOptions
    {
        /// <summary>
        /// The consumer selected <see cref="ExtrapolationMethod"/>.
        /// </summary>
        /// <remarks>
        /// Specifies the method family that the interpolator will use to 
        /// evaluate query points outside of the convex hull.
        /// <br/>
        /// For more information on the available extrapolation methods, view
        /// <see cref="ExtrapolationMethod"/>.
        /// </remarks>
        public ExtrapolationMethod Method { get; set; }
    }
}
