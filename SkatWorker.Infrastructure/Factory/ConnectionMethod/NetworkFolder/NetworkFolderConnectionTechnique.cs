using SkatWorker.Application.Interfaces.Factory.ConnectionMethod;

namespace SkatWorker.Infrastructure.Factory.ConnectionMethod.NetworkFolder
{
    public class NetworkFolderConnectionTechnique : IConnectionTechnique
    {
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
            throw new NotImplementedException();
        }
    }
}
