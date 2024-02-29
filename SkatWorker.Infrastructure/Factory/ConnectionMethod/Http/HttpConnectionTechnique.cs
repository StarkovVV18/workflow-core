using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;
using SkatWorker.Libraries;
using SkatWorker.Libraries.HttpClient.Builder;
using SkatWorker.Libraries.HttpClient.Infastructure;
using System.Net;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Http
{
    public class HttpConnectionTechnique : ConnectionTechnique
    {
        public HttpConnectionTechnique() { }

        public HttpConnectionTechnique(Libraries.HttpClient.Enums.HttpMethod httpMethod)
        {
            _httpMethod = httpMethod;
        }

        private Libraries.HttpClient.Enums.HttpMethod? _httpMethod;

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
            if (_httpMethod == null)
                throw new InvalidOperationException();

            HttpBuilder httpBuilder = Libraries.HttpClient.HttpClient.CreateHttpClient(_host, Libraries.HttpClient.Enums.HttpMethod.Get);
            httpBuilder.OnSuccess(HttpBuilderOnSuccess)
                .OnFail(HttpBuilderOnFail)
                .Send();

            return null;
        }

        private void HttpBuilderOnSuccess(AppliedResponse response)
        {
            throw new NotImplementedException();
        }

        private void HttpBuilderOnFail(WebException exception)
        {
            throw new NotImplementedException();
        }
    }
}
