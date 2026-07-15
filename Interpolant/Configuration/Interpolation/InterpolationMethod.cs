using System;

namespace Interpolant.Configuration.Interpolation
{
    /// <summary>
    /// Defines the interpolation method for query points inside of the 
    /// generated convex surface hull.
    /// </summary>
    public enum InterpolationMethod
    {
        /// <summary>
        /// Interpolates using the value of the nearest sample point.
        /// </summary>
        /// <remarks>
        /// Produces a discontinuous piecewise-constant surface.
        /// </remarks>
        [Obsolete("Not yet implemented.", false)]
        NearestNeighbor = 1,

        /// <summary>
        /// Interpolates using functions defined piecewise over the simplices of
        /// a simplicial mesh of the sample locations.
        /// </summary>
        /// <remarks>
        /// In a two-dimensional domain, the simplices are triangles. The local
        /// function, polynomial degree, and continuity constraints are determined
        /// by the selected simplicial interpolation scheme.
        /// </remarks>
        [Obsolete("Not yet implemented.", false)]
        Simplicial = 2,

        /// <summary>
        /// Interpolates using Sibson's natural neighbor coordinates derived
        /// from the Voronoi diagram.
        /// </summary>
        /// <remarks>
        /// Produces a smooth local interpolant without introducing new extrema.
        /// </remarks>
        [Obsolete("Not yet implemented.", false)]
        NaturalNeighbor = 3,

        /// <summary>
        /// Interpolates using a weighted sum of radial basis functions centered
        /// at the sample locations.
        /// </summary>
        /// <remarks>
        /// Produces a globally supported interpolant whose smoothness depends
        /// on the selected radial basis kernel.
        /// </remarks>
        [Obsolete("Not yet implemented.", false)]
        RadialBasisFunction = 4,

        /// <summary>
        /// Interpolates using Gaussian process regression based on a spatial
        /// covariance model.
        /// </summary>
        /// <remarks>
        /// Produces statistically optimal predictions under the assumed
        /// covariance model and can provide uncertainty estimates.
        /// </remarks>
        [Obsolete("Not yet implemented.", false)]
        Kriging = 5
    }
}
