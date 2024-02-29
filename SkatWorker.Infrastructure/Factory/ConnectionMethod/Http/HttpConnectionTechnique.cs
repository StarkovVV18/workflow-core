using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Http
{
    public class HttpConnectionTechnique : ConnectionTechnique, IConnectionTechnique
    {
        public RequestType? _requestType { get; set; }

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
            if (_requestType == null)
                throw new InvalidOperationException();

            return null;
        }
    }
}
