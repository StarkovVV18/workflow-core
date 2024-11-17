namespace SkatWorker.Application.Interfaces.Downloader
{
    public interface IRequestData
    {
        public string Token { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string PathToFile { get; set; }
        public string PathToSavedFile { get; set; }
    }
}
