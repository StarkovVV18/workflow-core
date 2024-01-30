using SkatWorker.Workflows.WorkflowDSLReader.Inputs;
using SkatWorker.Workflows.WorkflowDSLReader.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorker.Workflows.WorkflowDSLReader
{
    /// <summary>
    /// WF для чтеняи определения из http запроса.
    /// </summary>
    public class WorkflowDSLReaderWeb : IWorkflow<FilesFromDirectory>
    {
        public string Id => "WorkflowDSLReaderWeb";

        public int Version => 1;

        public void Build(IWorkflowBuilder<FilesFromDirectory> builder)
        {
            builder
                .StartWith<LoadWorkflowWeb>()
                    .Input(step => step.Definitions, data => data.Definitions);
        }
    }
}
