using SkatWorker.Libraries.HttpClient.Enums;
using SkatWorker.Libraries.HttpClient.Infastructure;
using SkatWorker.Libraries.HttpClient.Providers.Action;

namespace SkatWorker.Libraries.HttpClient.Builder
{
  /// <summary>
  /// Конструктор запроса.
  /// </summary>
  public partial class RequestBuilder
  {
    /// <summary>
    /// Адрес ресурса.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Отправляемый HTTP метод.
    /// </summary>
    public Enums.HttpMethod Method { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="url">Адрес ресурса.</param>
    /// <param name="method">Отправляемый HTTP метод.</param>
    public RequestBuilder(string url, Enums.HttpMethod method)
    {
      Url = url;
      Method = method;
    }

    /// <summary>
    /// Отправить запрос.
    /// </summary>
    public void Send()
    {
      if (this.ActionProvider == null)
      {
        this.ActionProvider = new DefaultActoinProvider(this.success, this.fail);
      }

      AppliedRequest request = new AppliedRequest
      {
        Url = Url,
        Method = Method,
        ActionProvider = ActionProvider,
        BodyProvider = BodyProvider,
        AuthenticationProvider= AuthenticationProvider,
        HeaderProvider = HeaderProvider
      };

      request.PrepareAndSend();
    }
  }
}
