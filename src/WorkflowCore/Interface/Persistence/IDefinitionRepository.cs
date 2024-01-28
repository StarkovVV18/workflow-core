using System.Threading.Tasks;
using System.Threading;
using WorkflowCore.Models;

namespace WorkflowCore.Interface.Persistence
{
    public interface IDefinitionRepository
    {
        Task<string> CreateDefinition(string definition, CancellationToken cancellationToken = default);

        Task<string> GetDefinition(string id, CancellationToken cancellationToken = default);
    }
}
