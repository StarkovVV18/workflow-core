using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.NetworkFolder
{
    internal class NetworkFolderConnectionMethodFactory : ConnectionMethodFactory
    {
        public override IConnectionTechnique GetConnectionTechnique()
        {
            return new NetworkFolderConnectionTechnique();
        }
    }
}
