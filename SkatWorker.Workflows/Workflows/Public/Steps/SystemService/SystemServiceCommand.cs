namespace SkatWorker.Workflows.Workflows.Public.Steps.SystemService
{
    /// <summary>
    /// Выполняемая команда со службой.
    /// </summary>
    public enum SystemServiceCommand
    {
        /// <summary>
        /// Запустить.
        /// </summary>
        Start,

        /// <summary>
        /// Остановить.
        /// </summary>
        Stop,

        /// <summary>
        /// Узнать состояние службы.
        /// </summary>
        Status
    }
}
