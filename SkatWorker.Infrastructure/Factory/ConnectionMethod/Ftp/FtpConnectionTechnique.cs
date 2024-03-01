using FluentFTP;
using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;
using System.Net;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.Ftp
{
    public class FtpConnectionTechnique : IConnectionTechnique
    {
        /// <summary>
        /// FTP клиент.
        /// </summary>
        private FtpClient _ftpClient = new FtpClient();

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
            _ftpClient.Host = Host;
            _ftpClient.Credentials.UserName = Login;
            _ftpClient.Credentials.Password = Password;

            _ftpClient.Connect();

            string localPath = this.GetPathOnSaveFile();
            _ftpClient.DownloadFile(localPath, SourcePathToFile);

            _ftpClient.Disconnect();

            _savedFile = localPath;
            return _savedFile;
        }

        private string GetPathOnSaveFile()
        {
            string tempPath = Path.GetTempPath();
            string tempFileName = !string.IsNullOrEmpty(this.FileExtension) ? $"{Guid.NewGuid().ToString()}.{this.FileExtension}" : Guid.NewGuid().ToString();

            if (!string.IsNullOrEmpty(this.FileName))
            {
                var fileName = !this.FileName.Contains(this.FileExtension) ? $"{this.FileName}.{this.FileExtension}" : this.FileName;
                return Path.Combine(tempPath, fileName);
            }

            return Path.Combine(tempPath, tempFileName);
        }
    }
}
