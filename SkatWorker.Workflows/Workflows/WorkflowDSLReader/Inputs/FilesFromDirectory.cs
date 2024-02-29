using SkatWorker.Application.Interfaces.Models;

namespace SkatWorker.Workflows.WorkflowDSLReader.Inputs
{
    /// <summary>
    /// Класс для передачи данных в шаг GetFilesFromDirectory и LoadWorkflow.
    /// </summary>
    public class FilesFromDirectory
    {
        /// <summary>
        /// Путь до директории.
        /// </summary>
        public string PathToFolder { get; set; }

        /// <summary>
        /// Список файлов директории.
        /// </summary>
        public string[] Files { get; set; }

        /// <summary>
        /// Список определений.
        /// </summary>
        public IEnumerable<IDefinitionModel> Definitions { get; set;}
    }
}
