using SkatWorker.Application.Interfaces.Downloader;

namespace SkatWorker.Infrastructure.Services.DownloaderService
{
    public class RequestData : IRequestData
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string PathToFile { get; set; }
        public string SavePath { get; set; }
    }
}
