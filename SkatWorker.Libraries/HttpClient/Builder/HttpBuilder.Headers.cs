using SkatWorker.Libraries.HttpClient.Providers.Headers;
using SkatWorker.Libraries.HttpClient.Providers.Interfaces;
using System.Collections.Generic;

namespace SkatWorker.Libraries.HttpClient.Builder
{
  /// <summary>
  /// Конструктор заголовков запроса.
  /// </summary>
  public partial class HttpBuilder
  {
    /// <summary>
    /// Провайдер заголовков запроса.
    /// </summary>
    public IHeaderProvider HeaderProvider { get; set; }

    /// <summary>
    /// Добавить заголовок к запросу.
    /// </summary>
    /// <param name="key">Имя заголовка.</param>
    /// <param name="value">Значение заголовока.</param>
    /// <returns>Конструктор запроса.</returns>
    public HttpBuilder Headers(string key, string value)
    {
      if (this.HeaderProvider == null)
      {
        this.HeaderProvider = new HeaderProvider();
      }

      this.HeaderProvider.SetHeaders(key, value);

      return this;
    }

    /// <summary>
    /// Добавить заголовки к запроса.
    /// </summary>
    /// <param name="headers">Словарь заголовоков.</param>
    /// <returns>Конструктор запроса.</returns>
    public HttpBuilder Headers(Dictionary<string, string> headers)
    {
      if (this.HeaderProvider == null)
      {
        this.HeaderProvider = new HeaderProvider();
      }

      this.HeaderProvider.SetHeaders(headers);

      return this;
    }
  }
}
