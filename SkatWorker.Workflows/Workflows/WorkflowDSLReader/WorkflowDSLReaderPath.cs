using SkatWorker.Workflows.WorkflowDSLReader.Inputs;
using SkatWorker.Workflows.WorkflowDSLReader.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorker.Workflows.WorkflowDSLReader
{
    /// <summary>
    /// WF для чтеняи определения из директории.
    /// </summary>
    public class WorkflowDSLReaderPath : IWorkflow<FilesFromDirectory>
    {
        public string Id => "WorkflowDSLReaderPath";

        public int Version => 1;

        public void Build(IWorkflowBuilder<FilesFromDirectory> builder)
        {
            builder
                .StartWith<GetFilesFromDirectory>()
                    .Input(step => step.PathToFolder, data => data.PathToFolder)
                    .Output(data => data.Files, step => step.Files)
                .Then<LoadWorkflow>()
                    .Input(step => step.Files, data => data.Files);
        }
    }
}
