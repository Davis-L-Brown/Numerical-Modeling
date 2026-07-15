using System;
using System.IO;

namespace Interpolant.Configuration.Output
{
    /// <summary>
    /// Class responsible for resolving <see cref="OutputOptions"/>
    /// into a <see cref="OutputConfiguration"/>.
    /// </summary>
    internal static class OutputOptionsResolver
    {
        /// <summary>
        /// Resolve consumer facing <see cref="OutputOptions"/> object into 
        /// a resolved <see cref="OutputConfiguration"/> object.
        /// </summary>
        /// <returns>
        /// An <see cref="OutputConfiguration"/> object, created by
        /// validating and resolving <paramref name="options"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if 
        /// <list type="bullet">
        /// <item><paramref name="options"/> is null </item>
        /// <item>A directory path is null</item>
        /// </list>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if
        /// <list type="bullet">
        /// <item>A path is null or whitespace</item>
        /// <item>A path contains invalid characters</item>
        /// <item>There is an issue getting the full path</item>
        /// </list>
        /// </exception>
        /// <exception cref="IOException">
        /// A path points to a file instead of a directory.
        /// </exception>
        public static OutputConfiguration Resolve(
            OutputOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            // Validate the output path.
            var outputDirectory = "";
            if (string.IsNullOrWhiteSpace(options.OutputPath))
            {
#if DEBUG
                var currentDir = AppDomain.CurrentDomain.BaseDirectory;
                var outputDir = Path.Combine(currentDir, @"UnitTestData\Output");
                var workingDir = Path.Combine(outputDir, DateTime.UtcNow.ToString("yyyyMMdd"));
                Directory.CreateDirectory(workingDir);
#else
                throw new ArgumentNullException(
                    nameof(options.OutputPath),
                    $"The output path cannot be null or whitespace.");
#endif
            }
            else
            {
                outputDirectory = options.OutputPath;
            }

            string outputPath = ValidatePath(outputDirectory, "Output Directory");

            // Validate the log path
            string logPath = "";
            if (options.CreateLogs)
            {
                logPath = string.IsNullOrWhiteSpace(options.LogPath) ?
                    outputPath : options.LogPath;

                logPath = ValidatePath(logPath, "Log");
            }

            // Validate eval trace path
            string evaluationTracePath = "";
            if (options.CreateEvaluationTrace)
            {
                evaluationTracePath = string.IsNullOrWhiteSpace(options.EvaluationTracePath) ?
                    outputPath : options.EvaluationTracePath;

                evaluationTracePath = ValidatePath(evaluationTracePath, "Evaluation Trace");
            }

            // validate the image path
            string imagePath = "";
            if (options.CreateHullImages || options.CreateEvaluationImages)
            {
                imagePath = string.IsNullOrWhiteSpace(options.EvaluationTracePath) ?
                    Path.Combine(outputPath, "Images") :
                    options.ImagesPath;

                imagePath = ValidatePath(imagePath, "Image");
            }


            return new Resolved.OutputConfiguration(
                outputPath,
                options.CreateLogs, logPath,
                options.CreateEvaluationTrace, evaluationTracePath,
                options.CreateHullImages, options.CreateEvaluationImages,
                imagePath);
        }



        /// <summary>
        /// Validate that a path is valid.
        /// </summary>
        /// <param name="path">
        /// A string representation of the directory being validated.
        /// </param>
        /// <param name="name">
        /// Optional path identifier, for logging purposes.
        /// </param>
        /// <returns>
        /// If the path exists, the fully qualified path.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="path"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the path format is incorrect.
        /// </exception>
        /// <exception cref="IOException">
        /// Thrown if the path matches the path of an existing file.
        /// </exception>
        public static string ValidatePath(string path, string name = "")
        {
            // if there is no path
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            // if the path is "", whitespace, empty, etc...
            if (path.Length == 0 ||
                string.IsNullOrWhiteSpace(path))
                throw new ArgumentException(
                    $"The {name} path cannot be null or whitespace.",
                    nameof(path));

            // ASCII/Unicode characters 1 through 31
            if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new ArgumentException(
                    $"The {name} path contains invalid path characters.",
                    nameof(path));

            string fullPath;
            try
            {
                fullPath = Path.GetFullPath(path);
            }
            catch (Exception ex) when (
                ex is ArgumentException ||
                ex is NotSupportedException ||
                ex is PathTooLongException)
            {
                throw new ArgumentException(
                    $"The {name} path is not a valid path.",
                    nameof(path),
                    ex);
            }

            if (File.Exists(fullPath))
                throw new IOException(
                    $"The {name} path refers to an existing file, not a directory: {fullPath}");

            return fullPath;
        }
    }
}
