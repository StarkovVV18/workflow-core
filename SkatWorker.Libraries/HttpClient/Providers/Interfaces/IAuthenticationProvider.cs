using SkatWorker.Libraries.HttpClient.Enums;

namespace SkatWorker.Libraries.HttpClient.Providers.Interfaces
{
  /// <summary>
  /// Провайдер аутентификации.
  /// </summary>
  public interface IAuthenticationProvider
  {
    /// <summary>
    /// Имя пользователя учетной записи.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Пароль учетной записи.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Токен для Bearer аутентификации.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Технология аутентификации.
    /// </summary>
    public AuthenticationTechnique AuthenticationTechnique { get; set; }

    /// <summary>
    /// Схема аутентификации.
    /// </summary>
    public AuthenticationScheme AuthenticationSchemes { get; set; }

    /// <summary>
    /// HTTP заголовок аутентификации.
    /// </summary>
    /// <returns></returns>
    public string GetHeader();

    /// <summary>
    /// Значение HTTP заголовока аутентификации.
    /// </summary>
    /// <returns></returns>
    public string GetValue();
  }
}