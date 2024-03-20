using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod
{
    /// <summary>
    /// Бызовый класс реализации способа подключения.
    /// </summary>
    public abstract class ConnectionTechnique
    {
        /// <summary>
        /// Логин.
        /// </summary>
        protected string Login = string.Empty;

        /// <summary>
        /// Пароль.
        /// </summary>
        protected string Password = string.Empty;

        /// <summary>
        /// Адрес подключения.
        /// </summary>
        protected string Host = string.Empty;

        /// <summary>
        /// Имя файла.
        /// </summary>
        protected string FileName = string.Empty;

        /// <summary>
        /// Путь до файла.
        /// </summary>
        protected string PathToFile = string.Empty;
    }
}
