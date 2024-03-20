using System.Threading.Tasks;
using System.Threading;
using WorkflowCore.Models;

namespace WorkflowCore.Interface.Persistence
{
    public interface IDefinitionRepository
    {
        Task<Definition> CreateDefinition(Definition definition, CancellationToken cancellationToken = default);

        Task<Definition> GetDefinition(string id, CancellationToken cancellationToken = default);
    }
}
