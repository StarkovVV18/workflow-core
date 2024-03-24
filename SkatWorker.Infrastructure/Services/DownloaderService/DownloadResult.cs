using SkatWorker.Application.Interfaces.Downloader;

namespace SkatWorker.Infrastructure.Services.DownloaderService
{
    public class DownloadResult : IDownloadResult
    {
        public string Result { get; set; }
        public string Status { get; set; }
        public bool Error { get; set; }
    }
}
