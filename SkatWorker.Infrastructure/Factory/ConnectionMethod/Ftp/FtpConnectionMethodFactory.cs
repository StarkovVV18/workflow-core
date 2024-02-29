using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Ftp
{
    public class FtpConnectionMethodFactory : ConnectionMethodFactory
    {
        public override IConnectionTechnique GetConnectionTechnique()
        {
            return new FtpConnectionTechnique();
        }
    }
}
