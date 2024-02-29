using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.NetworkFolder
{
    public class NetworkFolderConnectionTechnique : ConnectionTechnique, IConnectionTechnique
    {
        public bool Connect(string url, string login, string password)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public byte[] Download()
        {
            throw new NotImplementedException();
        }
    }
}
