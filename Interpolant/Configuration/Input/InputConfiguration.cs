using Interpolant.Configuration.Input.Enums;

namespace Interpolant.Configuration.Input
{
    /// <summary>
    /// Defines a resolved version of the consumer facing 
    /// <see cref="InputOptions"/>. 
    /// </summary>
    /// <remarks>
    /// <para>
    /// Resolved output options are guaranteed to have the required option
    /// fields validated and populated.
    /// </para>
    /// <para>
    /// Resolved output options are meant to be consumed by the concrete 
    /// interpolant class that will perform evaluation. 
    /// <br/>
    /// Because the options are
    /// resolved, there should be no need to verify options after the creation
    /// of the interpolant.
    /// </para>
    /// </remarks>
    internal sealed class InputConfiguration
    {
        /// <summary>
        /// Get the policy for duplicate inputed (x,y) coordinates.
        /// </summary>
        public DuplicateCoordinatePolicy DuplicatePolicy { get; }


        /// <summary>
        /// Create an instance of <see cref="InputConfiguration"/>.
        /// </summary>
        public InputConfiguration(DuplicateCoordinatePolicy duplicatePolicy)
        {
            DuplicatePolicy = duplicatePolicy;
        }
    }
}
