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
        protected string _login = string.Empty;

        /// <summary>
        /// Пароль.
        /// </summary>
        protected string _password = string.Empty;

        /// <summary>
        /// Адрес подключения.
        /// </summary>
        protected string _address = string.Empty;
    }
}
