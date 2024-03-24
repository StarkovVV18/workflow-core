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
        /// Имя файла с расширением.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Путь до скачанного файла.
        /// </summary>
        public string SavedFile { get; set; }
    }
}
