using SkatWorker.Application.Interfaces.Models;
using WorkflowCore.Models;

namespace SkatWorker.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис для работы с Workflow DSL.
    /// </summary>
    public interface IDefinitionService
    {
        /// <summary>
        /// Загрузить определение из храналища.
        /// </summary>
        void LoadDefinitionsFromStorage();

        /// <summary>
        /// Зарегистрировать определение.
        /// </summary>
        /// <param name="datasets">Список определений в json формате.</param>
        WorkflowDefinition RegisterNewDefinition(IEnumerable<IDefinitionModel> datasets);

        /// <summary>
        /// Зарегистрировать определение.
        /// </summary>
        /// <param name="pathDefinition">Путь до директории определений.</param>
        IEnumerable<WorkflowDefinition> RegisterNewDefinition(string pathDefinition);

        /// <summary>
        /// Обновить определение.
        /// </summary>
        /// <param name="definition">Определение.</param>
        void ReplaceVersion(string definition);

        /// <summary>
        /// Получить опеределение.
        /// </summary>
        /// <param name="id">Идентификатор определения.</param>
        /// <returns></returns>
        string GetDefinition(string id);
    }
}
