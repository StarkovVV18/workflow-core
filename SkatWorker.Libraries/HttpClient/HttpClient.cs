using SkatWorker.Libraries.HttpClient.Builder;

namespace SkatWorker.Libraries.HttpClient
{
  /// <summary>
  /// Определяет базовые методы запроса.
  /// </summary>
  public static class HttpClient
  {
    /// <summary>
    /// Создать http клиент.
    /// </summary>
    /// <param name="url">Адрес ресурса.</param>
    /// <param name="method">Тип запроса.</param>
    /// <returns>Построитель запроса.</returns>
    public static HttpBuilder CreateHttpClient(string url, Enums.HttpMethod method)
    {
      return new HttpBuilder(url, method);
    }
  }
}
