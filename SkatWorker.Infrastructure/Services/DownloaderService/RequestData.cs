using SkatWorker.Application.Interfaces.Downloader;

namespace SkatWorker.Infrastructure.Services.DownloaderService
{
    public class RequestData : IRequestData
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Токен авторизации.
        /// </summary>
        public string Token { get; set; }
        
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
    }
}
