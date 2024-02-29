using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Ftp
{
    public class FtpConnectionTechnique : ConnectionTechnique
    {
        public override bool Connect(string url, string login, string password)
        {
            throw new NotImplementedException();
        }

        public override void Disconnect()
        {
            throw new NotImplementedException();
        }

        public override byte[] Download()
        {
            throw new NotImplementedException();
        }
    }
}
