namespace SkatWorker.Infrastructure.Models.Response
{
    public class NotFoundResponse
    {
        public string Message { get; set; }

        public NotFoundResponse(string message)
        {
            Message = message;
        }
    }
}
