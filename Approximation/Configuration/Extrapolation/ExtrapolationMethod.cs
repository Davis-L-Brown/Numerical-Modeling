using System;

namespace Approximation.Configuration.Extrapolation
{
    /// <summary>
    /// Defines the extrapolation method for query points outside of the
    /// generated convex surface hull.
    /// </summary>
    public enum ExtrapolationMethod
    {
        /// <summary>
        /// Does not assign a value outside of the convex hull.
        /// </summary>
        /// <remarks>
        /// Outside-hull queries return an undefined value, typically
        /// <see cref="Double.NaN"/>.
        /// </remarks>
        None = 1,


        /// <summary>
        /// Assigns a configured constant value to every query point outside
        /// the convex hull.
        /// </summary>
        /// <remarks>
        /// The assigned value is independent of the query location and the
        /// interpolated boundary values.
        /// </remarks>
        Constant = 2,

        /// <summary>
        /// Assigns the value of the nearest input sample location.
        /// </summary>
        /// <remarks>
        /// Produces a piecewise-constant extrapolation based on the Voronoi
        /// regions of the input sample locations.
        /// </remarks>
        [Obsolete("Not yet implemented.", true)]
        NearestNeighbor = 3,

        /// <summary>
        /// Continues the interpolated surface outward from the convex-hull
        /// boundary using a locally defined boundary model.
        /// </summary>
        /// <remarks>
        /// The selected boundary-continuation method determines how boundary
        /// values, adjacent triangles, gradients, or normal derivatives are
        /// used outside the hull.
        /// </remarks>
        [Obsolete("Not yet implemented.", true)]
        BoundaryContinuation = 4,

        /// <summary>
        /// Evaluates the selected interpolation model outside the convex hull
        /// when that model is mathematically defined over the wider domain.
        /// </summary>
        /// <remarks>
        /// This method is valid only for interpolation models that define an
        /// evaluable function outside the convex hull, such as many radial-basis
        /// and kriging models.
        /// </remarks>
        [Obsolete("Not yet implemented.", true)]
        ModelContinuation = 5
    }
}
