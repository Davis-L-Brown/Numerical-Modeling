namespace Interpolant.Configuration.Input.Enums
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
        Throw = 1,

        /// <summary>
        /// If duplicate coordinates are found, ignore the new z value and keep
        /// the existing z value.
        /// </summary>
        KeepFirst = 2,

        /// <summary>
        /// If duplicate coordinates are found, replace the existing z value
        /// with the new z value.
        /// </summary>
        KeepLast = 3,

        /// <summary>
        /// If duplicate coordinates are found, keep the smallest z value.
        /// </summary>
        Smallest = 4,

        /// <summary>
        /// If duplicate coordinates are found, keep the largest z value.
        /// </summary>
        Largest = 5,

        /// <summary>
        /// If duplicate coordinates are found, replace the existing z value
        /// with the average of the z values.
        /// </summary>
        AverageZ = 6,

        /// <summary>
        /// If duplicate coordinates are found, replace the existing z value
        /// with the median of the z values.
        /// </summary>
        MedianZ = 7
    }
}
