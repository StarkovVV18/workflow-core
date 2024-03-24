using SkatWorker.Workflows.Public.Steps.CopyFiles.Parameters;
using SkatWorker.Workflows.WorkflowDSLReader.Inputs;
using WorkflowCore.Interface;

namespace SkatWorker.Workflows.Workflows.CopyFiles
{
    public class CopyFile : IWorkflow<CopyFileParam>
    {
        public string Id => "CopyFile";

        public int Version => 1;

        public void Build(IWorkflowBuilder<CopyFileParam> builder)
        {
            builder.StartWith<SkatWorker.Workflows.Public.Steps.CopyFiles.CopyFile>()
                .Input(step => step.SourcePath, data => data.SourcePath)
                .Input(step => step.DestinationPath, data => data.DestinationPath);
        }
    }
}
