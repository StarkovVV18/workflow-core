using SkatWorker.Libraries.HttpClient.Infastructure;
using System;
using System.IO;
using System.Net;

namespace SkatWorker.Libraries.HttpClient.Providers.Interfaces
{
  /// <summary>
  /// Провайдер выполняемых методов.
  /// </summary>
  public interface IActionProvider
  {
    /// <summary>
    /// Функция, которая выполнится в случае успешного запроса.
    /// </summary>
   public Action<AppliedResponse> Success { get; }

    /// <summary>
    /// Функция, которая выполнится при возникновении ошибки.
    /// </summary>
    public Action<WebException> Fail { get; }
  }
}
