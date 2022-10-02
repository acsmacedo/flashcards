using System.Collections.Generic;

namespace FlashCards.App.Models.ErrorHandlers
{
    public class BadResponseData
    {
        public IEnumerable<string> Errors { get; private set; }

        public BadResponseData(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
