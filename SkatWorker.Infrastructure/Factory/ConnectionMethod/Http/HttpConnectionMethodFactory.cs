using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Http
{
    public class HttpConnectionMethodFactory : IConnectionMethodFactory
    {
        public static IConnectionTechnique GetConnectionTechnique()
        {
            return new HttpConnectionTechnique();
        }

        public static IConnectionTechnique GetConnectionTechnique(Libraries.HttpClient.Enums.HttpMethod httpMethod)
        {
            return new HttpConnectionTechnique(httpMethod);
        }
    }
}
