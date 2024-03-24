using SkatWorker.Workflows.Public.Steps.HttpDownloader;
using SkatWorker.Workflows.Public.Steps.HttpDownloader.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace SkatWorker.Workflows.Workflows.HttpDownloader
{
    public class HttpDownloader : IWorkflow<HttpDownloaderParam>
    {
        public string Id => "HttpDownloader";

        public int Version => 1;

        public void Build(IWorkflowBuilder<HttpDownloaderParam> builder)
        {
            builder.StartWith<SkatWorker.Workflows.Public.Steps.HttpDownloader.HttpDownloader>()
                .Input(step => step.Host, data => data.Host)
                .Input(step => step.HttpMethod, data => data.HttpMethod)
                .Input(step => step.Login, data => data.Login)
                .Input(step => step.Password, data => data.Password)
                .Input(step => step.Token, data => data.Token)
                .Input(step => step.SavedFile, data => data.SavedFile)
                .Input(step => step.FileName, data => data.FileName)
                .Input(step => step.AuthenticationScheme, data => data.AuthenticationScheme);

        }
    }
}
