namespace SkatWorker.Workflows.Public.Steps.HttpDownloader.Inputs
{
    public class HttpDownloaderParam
    {
        /// <summary>
        /// Токен.
        /// </summary>
        public string Token { get; set; }

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

        /// <summary>
        /// Тип запроса.
        /// </summary>
        public Libraries.HttpClient.Enums.HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Способ аутентификации.
        /// </summary>
        public Libraries.HttpClient.Enums.AuthenticationScheme AuthenticationScheme { get; set; }
    }
}
