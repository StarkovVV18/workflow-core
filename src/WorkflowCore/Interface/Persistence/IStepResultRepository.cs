using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WorkflowCore.Models;

namespace WorkflowCore.Interface.Persistence
{
    public interface IStepResultRepository
    {
        Task<StepResult> CreateStepResult(StepResult stepResult, CancellationToken cancellationToken = default);

        Task<StepResult> GetStepResult(string id, CancellationToken cancellationToken = default);

        Task<IEnumerable<StepResult>> GetStepResults(CancellationToken cancellationToken = default);

        Task<IEnumerable<StepResult>> GetStepResult(Func<StepResult, bool> expression, CancellationToken cancellationToken = default);

    }
}
