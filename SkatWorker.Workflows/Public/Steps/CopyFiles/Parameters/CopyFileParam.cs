namespace SkatWorker.Workflows.Public.Steps.CopyFiles.Parameters
{
    /// <summary>
    /// Параметры шага CopyFile.
    /// </summary>
    public class CopyFileParam
    {
        /// <summary>
        /// Источник.
        /// </summary>
        public string SourcePath { get; set; }

        /// <summary>
        /// Назначение.
        /// </summary>
        public string DestinationPath { get; set; }
    }
}
