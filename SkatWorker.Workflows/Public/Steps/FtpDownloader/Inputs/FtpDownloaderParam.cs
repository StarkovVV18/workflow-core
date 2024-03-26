namespace SkatWorker.Workflows.Public.Steps.FtpDownloader.Inputs
{
    public class FtpDownloaderParam
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// URL адрес.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Директория сохранения файла.
        /// </summary>
        public string SavedFile { get; set; }
    }
}
