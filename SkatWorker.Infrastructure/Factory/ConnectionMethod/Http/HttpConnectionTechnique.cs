using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;
using SkatWorker.Libraries;
using SkatWorker.Libraries.HttpClient.Builder;
using SkatWorker.Libraries.HttpClient.Infastructure;
using System.Net;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Http
{
    public class HttpConnectionTechnique : IConnectionTechnique
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        private Libraries.HttpClient.Enums.HttpMethod? _httpMethod;
        
        /// <summary>
        /// Путь до скачанного файла.
        /// </summary>
        private string _savedFile;

        public string Login { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string FileName { get; set; }
        public string SourcePathToFile { get; set; }
        public string FileExtension { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public HttpConnectionTechnique() { }

        public HttpConnectionTechnique(Libraries.HttpClient.Enums.HttpMethod httpMethod)
        {
            _httpMethod = httpMethod;
        }

        public bool Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public string Download()
        {
            if (_httpMethod == null)
                throw new InvalidOperationException();

            HttpBuilder httpBuilder = Libraries.HttpClient.HttpClient.CreateHttpClient(Host, Libraries.HttpClient.Enums.HttpMethod.Get);
            httpBuilder.OnSuccess(DownloadOnSuccess)
                .OnFail(DownloadOnFail)
                .Send();

            return _savedFile;
        }

        private void DownloadOnSuccess(AppliedResponse response)
        {
            string fullPath = this.GetPathOnSaveFile(response.Headers);

            try
            {
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    response.Response.CopyTo(fileStream);

                _savedFile = fullPath;
            }
            // TODO: Обработать исключение.
            catch (Exception e) { }
        }

        private void DownloadOnFail(WebException exception)
        {
            throw new NotImplementedException();
        }

        private string GetPathOnSaveFile(WebHeaderCollection headers)
        {
            string tempPath = Path.GetTempPath();
            string tempFileName = !string.IsNullOrEmpty(this.FileExtension) ? $"{Guid.NewGuid().ToString()}.{this.FileExtension}" : Guid.NewGuid().ToString();

            var contentDisposition = headers.Get("Content-Disposition");
            var fileNameFromResponse = contentDisposition.Split("filename=")[1].Split(";")[0];

            if (!string.IsNullOrEmpty(this.FileName))
            {
                var fileName = !this.FileName.Contains(this.FileExtension) ? $"{this.FileName}.{this.FileExtension}" : this.FileName;
                return Path.Combine(tempPath, fileName);
            }

            if (!string.IsNullOrEmpty(fileNameFromResponse))
                return Path.Combine(tempPath, fileNameFromResponse);

            return Path.Combine(tempPath, tempFileName);
        }
    }
}
