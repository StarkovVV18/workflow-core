namespace SkatWorker.Application.Interfaces.Factory.ConnectionMethod
{
    /// <summary>
    /// Фабрика способов подключения.
    /// </summary>
    public interface IConnectionMethodFactory
    {
        /// <summary>
        /// Получить способ подключения.
        /// </summary>
        /// <returns>Способ подключения.</returns>
        IConnectionTechnique GetConnectionTechnique();
    }
}
