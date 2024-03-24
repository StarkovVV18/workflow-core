using FluentFTP;
using FluentFTP.Helpers;
using Microsoft.Extensions.Hosting;
using SkatWorker.Application.Interfaces.Downloader;

namespace SkatWorker.Infrastructure.Services.DownloaderService.Downloader
{
    public class FtpDownloader : IDownloader
    {
        /// <summary>
        /// FTP клиент.
        /// </summary>
        private FtpClient _ftpClient;

        /// <summary>
        /// Результат скачивания.
        /// </summary>
        private IDownloadResult _downloadResult;

        /// <summary>
        /// Данные запроса.
        /// </summary>
        private IRequestData _requestData;

        public FtpDownloader()
        {
            _ftpClient = new FtpClient();
            _downloadResult = new DownloadResult();
        }

        public IDownloadResult Download(IRequestData requestData)
        {
            _requestData = requestData;

            _ftpClient.Host = _requestData.Host;
            _ftpClient.Credentials.UserName = _requestData.Login;
            _ftpClient.Credentials.Password = _requestData.Password;

            try
            {
                _ftpClient.Connect();

                string localPath = this.GetPathOnSaveFile();
                _ftpClient.DownloadFile(localPath, _requestData.PathToFile);

                _ftpClient.Disconnect();

                _downloadResult.Result = localPath;
            }
            catch (Exception ex)
            {
                _downloadResult.Result = ex.Message;
                _downloadResult.Error = true;
            }

            return _downloadResult;
        }

        private string GetPathOnSaveFile()
        {
            string tempPath = !string.IsNullOrEmpty(_requestData.SavePath) ? _requestData.SavePath : Path.GetTempPath();
            string tempFileName = Path.GetFileName(_requestData.SavePath);

            return Path.Combine(tempPath, tempFileName);
        }
    }
}
