namespace SkatWorker.Application.Interfaces.Factory.ConnectionMethod
{
    /// <summary>
    /// Фабрика способов подключения.
    /// </summary>
    public interface IConnectionMethodFactory
    {
        /// <summary>
        /// Получить способов подключения.
        /// </summary>
        /// <returns></returns>
        static IConnectionTechnique GetConnectionTechnique();
    }
}
