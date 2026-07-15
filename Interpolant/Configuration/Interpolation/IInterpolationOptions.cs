namespace Interpolant.Configuration.Interpolation
{
    /// <summary>
    /// Defines the interpolation options for an interpolator object.
    /// </summary>
    public interface IInterpolationOptions
    {
        /// <summary>
        /// Gets the consumer selected <see cref="InterpolationMethod"/>.
        /// </summary>
        /// <remarks>
        /// Specifies the method family that the interpolator will use to 
        /// evaluate query points inside of the convex hull.
        /// <br/>
        /// For more information on the available Interpolation methods, view
        /// <see cref="InterpolationMethod"/>.
        /// </remarks>
        InterpolationMethod Method { get; }


        /// <summary>
        /// Validate the interpolation options for the interpolator object.
        /// </summary>
        void Validate();
    }
}
