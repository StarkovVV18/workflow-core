using System.IO;

namespace SkatWorker.Libraries.HttpClient.Providers.Interfaces
{
  /// <summary>
  /// Провайдер тела запроса.
  /// </summary>
  public interface IBodyProvider
  {
    /// <summary>
    /// Тип отправляемого тела запроса.
    /// </summary>
    /// <returns></returns>
    public string ContentType();

    /// <summary>
    /// Добавить к запросу тело.
    /// </summary>
    /// <param name="requestStream">Поток HTTP запроса.</param>
    public void SetBody(Stream requestStream);

    /// <summary>
    /// Тело запроса.
    /// </summary>
    public byte[] Body { get; set; }

    /// <summary>
    /// Путь до загружаемого файла.
    /// </summary>
    public string PathToFile { get; set; }
  }
}
