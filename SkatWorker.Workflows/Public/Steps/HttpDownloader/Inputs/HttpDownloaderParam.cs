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
        /// Путь до скачиваемого файла.
        /// </summary>
        public string PathToFile { get; set; }

        /// <summary>
        /// Путь сохранения файла.
        /// </summary>
        public string PathToSavedFile { get; set; }

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
