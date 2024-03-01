using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Http
{
    public class HttpConnectionMethodFactory : IConnectionMethodFactory
    {
        public IConnectionTechnique GetConnectionTechnique()
        {
            return new HttpConnectionTechnique();
        }

        public IConnectionTechnique GetConnectionTechnique(Libraries.HttpClient.Enums.HttpMethod httpMethod)
        {
            return new HttpConnectionTechnique(httpMethod);
        }
    }
}
