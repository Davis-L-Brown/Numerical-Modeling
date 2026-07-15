namespace Interpolant.Configuration.Output
{
    /// <summary>
    /// Defines a resolved version of the consumer facing 
    /// <see cref="OutputOptions"/>. 
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
    internal sealed class OutputConfiguration
    {
        /// <summary>
        /// Get the file path to the base output directory.
        /// </summary>
        public string OutputPath { get; }

        /// <summary>
        /// Get the flag denoting whether or not to create interpolant logs.
        /// </summary>
        public bool CreateLogs { get; }

        /// <summary>
        /// Get the file path to the output log directory.
        /// </summary>
        public string LogPath { get; }

        /// <summary>
        /// Get the flag denoting whether or not to create an evaluation trace.
        /// </summary>
        public bool CreateEvaluationTrace { get; }

        /// <summary>
        /// Get the file path to the output evaluation trace directory.
        /// </summary>
        public string EvaluationTracePath { get; }

        /// <summary>
        /// Get the flag denoting whether or not to create hull images.
        /// </summary>
        public bool CreateHullImages { get; }

        /// <summary>
        /// Get the flag denoting whether or not to create evaluation trace
        /// images.
        /// </summary>
        public bool CreateEvaluationImages { get; }

        /// <summary>
        /// Get the file path to the output image directory.
        /// </summary>
        public string ImagesPath { get; }


        /// <summary>
        /// Create an instance of <see cref="OutputConfiguration"/>.
        /// </summary>
        /// <param name="outputPath">
        /// The base directory that all logs will be placed in.
        /// </param>
        /// <param name="createLogs">
        /// Get the flag denoting whether or not the interpolant should create S
        /// log files.
        /// <br/>
        /// <i>**Note - this selection does not affect evaluation trace 
        /// generation.</i>
        /// </param>
        /// <param name="logPath">
        /// An optional subdirectory where logs are stored.
        /// <br/>
        /// <i>**Note - if not defined, will default to 
        /// <paramref name="outputPath"/>.</i>
        /// </param>
        /// <param name="createEvalTrace">
        /// Get the flag denoting whether or not to create an evaluation trace.
        /// <br/>
        /// Evaluation traces are created when an evaluation of a query point
        /// is requested.
        /// </param>
        /// <param name="evalTracePath">
        /// An optional subdirectory in which evaluation traces will be stored.
        /// <br/>
        /// <i>**Note - if not defined, will default to 
        /// <paramref name="outputPath"/>.</i>
        /// </param>
        /// <param name="createHullImages">
        /// Get the flag denoting whether or not to create images of the hull.
        /// </param>
        /// <param name="createEvalImages">
        /// Get the flag denoting whether or not to create images of evaluation
        /// points.
        /// </param>
        /// <param name="imagesPath">
        /// An optional subdirectory in which images will be stored.
        /// <br/>
        /// <i>**Note - if not defined, will default to 
        /// <paramref name="outputPath"/>\images.</i>
        /// </param>
        public OutputConfiguration(
            string outputPath,
            bool createLogs, string logPath,
            bool createEvalTrace, string evalTracePath,
            bool createHullImages, bool createEvalImages,
            string imagesPath)
        {
            OutputPath = outputPath;
            CreateLogs = createLogs;
            LogPath = logPath;
            CreateEvaluationTrace = createEvalTrace;
            EvaluationTracePath = evalTracePath;
            CreateHullImages = createHullImages;
            CreateEvaluationImages = createEvalImages;
            ImagesPath = imagesPath;
        }
    }
}
