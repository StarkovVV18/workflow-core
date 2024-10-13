namespace SkatWorker.Application.Interfaces.Downloader
{
    public interface IDownloadResult
    {
        public string Result { get; set; }
        public string Status { get; set; }
        public bool Error { get; set; }
    }
}
