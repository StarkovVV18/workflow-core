namespace SkatWorker.Application.Interfaces.Factory.ConnectionMethod
{
    /// <summary>
    /// Способ подключения.
    /// </summary>
    public interface IConnectionTechnique
    {
        /// <summary>
        /// Логин.
        /// </summary>
        string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Адрес подключения.
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Имя файла.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Путь до файла в системе источнике.
        /// </summary>
        string SourcePathToFile { get; set; }

        /// <summary>
        /// Расширение файла.
        /// </summary>
        string FileExtension { get; set; }

        /// <summary>
        /// Подключиться.
        /// </summary>
        /// <returns>True, false.</returns>
        bool Connect();

        /// <summary>
        /// Отключиться.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Скачать файл с ресурса.
        /// </summary>
        /// <remarks>Скачанный файл сохраняется во временную папку.</remarks>
        string Download();
    }
}
