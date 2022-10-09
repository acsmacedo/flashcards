using FlashCards.App.Interfaces;
using FlashCards.App.Models.Flashcards;
using FlashCards.App.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlashCards.App.Services
{
    public class FlashcardCollectionService : BaseService, IFlashcardCollectionService
    {
        public FlashcardCollectionService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IEnumerable<FlashcardCollection>> GetAllFlashcards()
        {
            var url = AppSettings.URL + "Flashcards/" + 3;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<FlashcardCollection>>(response);

            return result;
        }

        public async Task<IEnumerable<FlashcardCollection>> GetFlashcardsByCategory(int categoryID)
        {
            var url = AppSettings.URL + "Flashcards/Category/" + categoryID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<FlashcardCollection>>(response);

            return result;
        }
    }
}
