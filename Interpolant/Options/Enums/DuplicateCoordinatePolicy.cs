namespace Interpolant.Options.Enums
{
    /// <summary>
    /// Defines how the scattered interpolant should handle duplicate (x, y, z)
    /// coordinates upon construction.
    /// </summary>
    public enum DuplicateCoordinatePolicy
    {
        /// <summary>
        /// If duplicate coordinates are found, throw an exception.
        /// </summary>
        Throw,

        /// <summary>
        /// If duplicate coordinates are found, ignore the new z value and keep
        /// the existing z value.
        /// </summary>
        KeepFirst,

        /// <summary>
        /// If duplicate coordinates are found, replace the existing z value
        /// with the new z value.
        /// </summary>
        KeepLast,

        /// <summary>
        /// If duplicate coordinates are found, keep the smallest z value.
        /// </summary>
        Smallest,

        /// <summary>
        /// If duplicate coordinates are found, keep the largest z value.
        /// </summary>
        Largest,

        /// <summary>
        /// If duplicate coordinates are found, replace the existing z value
        /// with the average of the z values.
        /// </summary>
        AverageZ,

        /// <summary>
        /// If duplicate coordinates are found, replace the existing z value
        /// with the median of the z values.
        /// </summary>
        MedianZ
    }
}
