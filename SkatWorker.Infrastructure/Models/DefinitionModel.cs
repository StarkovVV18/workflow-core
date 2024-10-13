using SkatWorker.Application.Interfaces.Models;

namespace SkatWorker.Infrastructure.Models
{
    public class DefinitionModel : IDefinitionModel
    {
        public string WorkflowId { get; set; }
        public string Value { get;  set; }
    }
}
