namespace SkatWorker.Application.Interfaces.Downloader
{
    public interface IRequestData
    {
        public string Token { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string FileName { get; set; }
        public string PathToFile { get; set; }
        public string SavePath { get; set; }
        public string FileExtension { get; set; }
    }
}
