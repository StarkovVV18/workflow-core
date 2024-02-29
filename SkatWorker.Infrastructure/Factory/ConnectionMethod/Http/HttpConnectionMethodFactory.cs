using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Http
{
    public class HttpConnectionMethodFactory : ConnectionMethodFactory
    {
        public override IConnectionTechnique GetConnectionTechnique()
        {
            return new HttpConnectionTechnique();
        }
    }
}
