using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Http
{
    public class HttpConnectionTechnique : ConnectionTechnique
    {
        public RequestType? _requestType { get; set; }

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
            if (_requestType == null)
                throw new InvalidOperationException();

            return null;
        }
    }
}
