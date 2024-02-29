using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod
{
    /// <summary>
    /// Бызовый класс реализации способа подключения.
    /// </summary>
    public abstract class ConnectionTechnique : IConnectionTechnique
    {
        /// <summary>
        /// Логин.
        /// </summary>
        protected string _login = string.Empty;

        /// <summary>
        /// Пароль.
        /// </summary>
        protected string _password = string.Empty;

        /// <summary>
        /// Адрес подключения.
        /// </summary>
        protected string _host = string.Empty;

        public abstract bool Connect(string url, string login, string password);

        public abstract void Disconnect();

        public abstract byte[] Download();
    }
}
