using System.Collections.Generic;

namespace SkatWorker.Libraries.HttpClient.Providers.Interfaces
{
  /// <summary>
  /// Провайдер заголовков запроса.
  /// </summary>
  public interface IHeaderProvider
  {
    /// <summary>
    /// Получить заголовки запроса.
    /// </summary>
    /// <returns></returns>
    public IDictionary<string, string> GetHeaders();

    /// <summary>
    /// Добавить заголовок запроса.
    /// </summary>
    /// <param name="key">Имя заголовка.</param>
    /// <param name="value">Значение заголовока.</param>
    public void SetHeaders(string key, string value);

    /// <summary>
    /// Добавить заголовки запроса.
    /// </summary>
    /// <param name="headers">Словарь заголовков.</param>
    public void SetHeaders(IDictionary<string, string> headers);
  }
}
