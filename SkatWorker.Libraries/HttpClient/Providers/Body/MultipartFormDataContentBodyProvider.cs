using SkatWorker.Libraries.HttpClient.Providers.Interfaces;
using System;
using System.IO;
using System.Text;

namespace SkatWorker.Libraries.HttpClient.Providers.Body
{
  /// <summary>
  /// Form-data провайдер тела запроса.
  /// </summary>
  public class MultipartFormDataContentBodyProvider : IBodyProvider
  {
    /// <summary>
    /// Разделитель строк.
    /// </summary>
    private string boundary = string.Format("---------------------------{0}", DateTime.Now.Ticks.ToString("x"));

    /// <summary>
    /// Имя контрола формы.
    /// </summary>
    public string FormName { get; set; }

    /// <summary>
    /// <see cref="IBodyProvider.Body"/>
    /// </summary>
    public byte[] Body { get; set; }

    /// <summary>
    /// <see cref="IBodyProvider.PathToFile"/>
    /// </summary>
    public string PathToFile { get; set; }

    /// <summary>
    /// <see cref="IBodyProvider.SetBody(Stream)"/>
    /// </summary>
    public void SetBody(Stream requestStream)
    {
            string fileName = Path.GetFileName(this.PathToFile);
            this.Body = File.ReadAllBytes(this.PathToFile);

            //using (var rs = requestStream)
            //using (var writer = new StreamWriter(rs))
            //{
            //    writer.WriteAsync( // file header
            //        $"\r\n--{boundary}\r\nContent-Disposition: " +
            //        $"form-data; name=\"File\"; filename=\"{fileName}\"\r\n" +
            //        "Content-Type: application/pdf\r\n\r\n");

            //    writer.FlushAsync();
            //    using (var fileStream = File.OpenRead(this.PathToFile))
            //        fileStream.CopyToAsync(requestStream);

            //    writer.WriteAsync($"\r\n--{boundary}--\r\n");
            //}


            string header = string.Format("\r\n{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\" \r\nContent-Type: application/octet-stream\r\n\r\n", this.boundary, this.FormName, fileName);

            //requestStream.Write(Encoding.ASCII.GetBytes(header), 0, header.Length);
            //requestStream.Write(this.Body, 0, this.Body.Length);
            using (StreamWriter writer = new StreamWriter(requestStream))
            {
                writer.Write(header);
                writer.Flush();

                using (FileStream fileStream = File.OpenRead(this.PathToFile))
                {
                    fileStream.CopyToAsync(requestStream);
                }

                writer.Write($"\r\n{boundary}\r\n");
            }

            requestStream.Close();
        }

        /// <summary>
        /// <see cref="IBodyProvider.ContentType"/>
        /// </summary>
        public string ContentType()
    {
        return string.Format("\r\n{0}; boundary={1}\r\n", Enums.ContentType.MultipartFormData, this.boundary);
    }
  }
}
