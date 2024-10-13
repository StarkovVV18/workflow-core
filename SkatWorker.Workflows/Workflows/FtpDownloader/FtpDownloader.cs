using SkatWorker.Workflows.Public.Steps.FtpDownloader.Inputs;
using SkatWorker.Workflows.Public.Steps.HttpDownloader.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace SkatWorker.Workflows.Workflows.FtpDownloader
{
    public class FtpDownloader : IWorkflow<FtpDownloaderParam>
    {
        public string Id => "FtpDownloader";

        public int Version => 1;

        public void Build(IWorkflowBuilder<FtpDownloaderParam> builder)
        {
            builder.StartWith<SkatWorker.Workflows.Public.Steps.FtpDownloader.FtpDownloader>()
                .Input(step => step.Host, data => data.Host)
                .Input(step => step.Login, data => data.Login)
                .Input(step => step.Password, data => data.Password)
                .Input(step => step.SavedFile, data => data.SavedFile);
        }

    }
}
