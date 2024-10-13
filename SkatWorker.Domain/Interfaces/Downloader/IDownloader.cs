namespace SkatWorker.Application.Interfaces.Downloader
{
    public interface IDownloader
    {
        IDownloadResult Download(IRequestData requestData);
    }
}
