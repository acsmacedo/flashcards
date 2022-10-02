namespace FlashCards.App.Models.ErrorHandlers
{
    public class ErrorResponseData
    {
        public string Message { get; private set; }

        public ErrorResponseData(string message)
        {
            Message = message;
        }
    }
}
