using SkatWorker.Application.Interfaces.Downloader;

namespace SkatWorker.Infrastructure.Services.DownloaderService
{
    public class DownloaderService
    {
        private IDownloader _downloader;
        private IRequestData _requestData;

        public DownloaderService() {}

        public DownloaderService(IDownloader downloader, IRequestData requestData)
        {
            _downloader = downloader;
            _requestData = requestData;
        }

        public void SetDowloader(IDownloader downloader)
        {
            _downloader = downloader;
        }

        public void SetRequestData(IRequestData requestData)
        {
            _requestData = requestData;
        }

        public IDownloadResult Download()
        {
            return _downloader.Download(_requestData);
        }
    }
}
