using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FlashCards.Api.Middlewares.Errors;

public class BadResponseData
{
    public IEnumerable<string> Errors { get; private set; }

    public BadResponseData(ModelStateDictionary modelState)
    {
        Errors = modelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage));
    }
}
