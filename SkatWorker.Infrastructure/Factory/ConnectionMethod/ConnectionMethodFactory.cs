using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod
{
    public abstract class ConnectionMethodFactory : IConnectionMethodFactory
    {
        /// <summary>
        /// Получить способ подключения.
        /// </summary>
        /// <returns>Экземпляр способа подключения.</returns>
        public abstract IConnectionTechnique GetConnectionTechnique();
    }
}
