using Microsoft.Extensions.Hosting;
using SkatWorker.Application.Interfaces.Downloader;
using SkatWorker.Libraries.HttpClient.Builder;
using SkatWorker.Libraries.HttpClient.Infastructure;
using System.Net;

namespace SkatWorker.Infrastructure.Services.DownloaderService.Downloader
{
    public class HttpDownloader : IDownloader
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        private Libraries.HttpClient.Enums.HttpMethod _httpMethod;

        /// <summary>
        /// Схема аутентификации.
        /// </summary>
        private Libraries.HttpClient.Enums.AuthenticationScheme _authenticationScheme;

        /// <summary>
        /// Результат скачивания.
        /// </summary>
        private IDownloadResult _downloadResult;

        /// <summary>
        /// Данные запроса.
        /// </summary>
        private IRequestData _requestData;

        public HttpDownloader(Libraries.HttpClient.Enums.HttpMethod httpMethod, Libraries.HttpClient.Enums.AuthenticationScheme authenticationScheme)
        {
            _httpMethod = httpMethod;
            _authenticationScheme = authenticationScheme;
            _downloadResult = new DownloadResult();
        }

        public IDownloadResult Download(IRequestData requestData)
        {
            if (_httpMethod == null)
            {
                _downloadResult.Result = "Не указан тип запроса.";
                _downloadResult.Error = true;

                return _downloadResult;
            }

            if (_authenticationScheme == null)
            {
                _downloadResult.Result = "Не указан способ аутентификации.";
                _downloadResult.Error = true;

                return _downloadResult;
            }

            _requestData = requestData;

            HttpBuilder httpBuilder = Libraries.HttpClient.HttpClient.CreateHttpClient(_requestData.Host, _httpMethod);

            this.SetAuthenticationScheme(httpBuilder);

            try
            {
                httpBuilder.OnSuccess(DownloadOnSuccess)
                                .OnFail(DownloadOnFail)
                                .Send();
            }
            catch (Exception ex)
            {
                _downloadResult.Result = ex.Message;
                _downloadResult.Error = true;
            }

            return _downloadResult;
        }

        private HttpBuilder SetAuthenticationScheme(HttpBuilder httpBuilder)
        {
            switch (_authenticationScheme)
            {
                case Libraries.HttpClient.Enums.AuthenticationScheme.Basic:
                    httpBuilder.Basic(_requestData.Login, _requestData.Password);
                    break;
                case Libraries.HttpClient.Enums.AuthenticationScheme.Bearer:
                    httpBuilder.Bearer(_requestData.Token);
                    break;
                case Libraries.HttpClient.Enums.AuthenticationScheme.NTLM:
                    httpBuilder.Ntlm(_requestData.Login, _requestData.Password);
                    break;
            }

            return httpBuilder;
        }

        private void DownloadOnSuccess(AppliedResponse response)
        {
            string fullPath = this.GetPathOnSaveFile(response.Headers);

            try
            {
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    response.Response.CopyTo(fileStream);

                _downloadResult.Result = fullPath;
            }
            catch (Exception ex)
            {
                _downloadResult.Result = ex.Message;
                _downloadResult.Error = true;
            }
        }

        private void DownloadOnFail(WebException exception)
        {
            _downloadResult.Result = exception.Message;
            _downloadResult.Error = true;
        }

        private string GetPathOnSaveFile(WebHeaderCollection headers)
        {
            string tempPath = !string.IsNullOrEmpty(_requestData.PathToSavedFile) ? _requestData.PathToSavedFile : Path.GetTempPath();

            var contentDisposition = headers.Get("Content-Disposition");
            var fileNameFromResponse = contentDisposition.Split("filename=")[1].Split(";")[0];
            
            return Path.Combine(tempPath, fileNameFromResponse);
        }
    }
}
