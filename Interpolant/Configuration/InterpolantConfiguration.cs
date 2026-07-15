using Interpolant.Configuration.Input;
using Interpolant.Configuration.Output;

namespace Interpolant.Configuration
{
    /// <summary>
    /// Defines a resolved verion of the consumer facing 
    /// <see cref="InterpolantOptions"/>.
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
    internal class InterpolantConfiguration
    {
        /// <summary>
        /// Get the resolved <see cref="InputConfiguration"/>.
        /// </summary>
        public InputConfiguration Input { get; }

        /// <summary>
        /// Get the resolved <see cref="OutputConfiguration"/>.
        /// </summary>
        public OutputConfiguration Output { get; }


        /// <summary>
        /// Create a new instance of <see cref="InterpolantConfiguration"/>,
        /// which is a resolved version of <see cref="InterpolantOptions"/>
        /// </summary>
        public InterpolantConfiguration(
            InputConfiguration input,
            OutputConfiguration output)
        {
            Input = input;
            Output = output;
        }
    }
}
