using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Ftp
{
    public class FtpConnectionTechnique : ConnectionTechnique, IConnectionTechnique
    {
        public bool Connect(string url, string login, string password)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public string Download()
        {
            throw new NotImplementedException();
        }
    }
}
