namespace Interpolant.Configuration.Output
{
    /// <summary>
    /// Defines output options for an interpolator object.
    /// </summary>
    public sealed class OutputOptions
    {
        /// <summary>
        /// The path to the base directory for interpolator outputs.
        /// </summary>
        public string OutputPath { get; set; } = "";


        /// <summary>
        /// A flag denoting whether or not to log interpolation
        /// information/data.
        /// </summary>
        public bool CreateLogs { get; set; } = false;

        /// <summary>
        /// The path to the log directory.
        /// </summary>
        /// <remarks>
        /// If <see cref="CreateLogs"/> is true, but no path is provided,
        /// this will default to <see cref="OutputPath"/>.
        /// </remarks>
        public string LogPath { get; set; } = "";


        /// <summary>
        /// A flag denoting whether or not to create an evaluation
        /// trace log when evaluating query points.
        /// </summary>
        public bool CreateEvaluationTrace { get; set; } = false;

        /// <summary>
        /// The path to the evaluation trace directory.
        /// </summary>
        /// <remarks>
        /// If <see cref="CreateEvaluationTrace"/> is true, but no path is provided,
        /// this will default to <see cref="OutputPath"/>.
        /// </remarks>
        public string EvaluationTracePath { get; set; } = "";


        /// <summary>
        /// A flag denoting whether or not to create hull images.
        /// </summary>
        /// <remarks>
        /// If <see cref="CreateHullImages"/> is true, but no path is provided,
        /// this will default to <see cref="OutputPath"/>.
        /// </remarks>
        public bool CreateHullImages { get; set; } = false;

        /// <summary>
        /// A flag denoting whether or not to create 
        /// </summary>
        public bool CreateEvaluationImages { get; set; } = false;

        /// <summary>
        /// The path to the hull images directory.
        /// </summary>
        public string ImagesPath { get; set; } = "";
    }
}
