using FlashCards.App.Interfaces;
using FlashCards.App.Models.Flashcards;
using FlashCards.App.Utils;
using FlashCards.App.ViewModels.Flashcards;
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

        public async Task<FlashcardCollection> GetByID(int flashcardCollectionID)
        {
            var url = AppSettings.URL + "Flashcards/" + flashcardCollectionID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<FlashcardCollection>(response);

            return result;
        }

        public async Task<IEnumerable<FlashcardCollection>> GetAllFlashcards()
        {
            var url = AppSettings.URL + "Flashcards";
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<FlashcardCollection>>(response);

            return result;
        }

        public async Task<IEnumerable<FlashcardCollectionAvailable>> GetAvailablesByFlashcardCollectiion(int flashcardCollectionID)
        {
            var url = AppSettings.URL + "Flashcards/CardRating/" + flashcardCollectionID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<FlashcardCollectionAvailable>>(response);

            return result;
        }

        public async Task<IEnumerable<FlashcardCollection>> GetFlashcardsByUser(int userID)
        {
            var url = AppSettings.URL + "Flashcards/Users/" + userID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<FlashcardCollection>>(response);

            return result;
        }

        public async Task<IEnumerable<FlashcardCollection>> GetFlashcardsByCategory(int categoryID)
        {
            var url = AppSettings.URL + "Flashcards/Categories/" + categoryID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<FlashcardCollection>>(response);

            return result;
        }

        public async Task<int> CreateFlashcardCollection(CreateOrEditFlashcardViewModel data)
        {
            var url = AppSettings.URL + "FlashCards";
            var response = await PostAsync(url, data);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<int>(response);

            return result;
        }

        public async Task EditFlashcardCollection(CreateOrEditFlashcardViewModel data)
        {
            var url = AppSettings.URL + "FlashCards";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task DeleteFlashcardCollection(int flashcardCollectionID)
        {
            var url = AppSettings.URL + "FlashCards/" + flashcardCollectionID;
            var response = await DeleteAsync(url);

            await HandlerErrorAsync(response);
        }

        public async Task<int> AddFlashcardItem(CreateOrEditFlashcardItemViewModel data)
        {
            var url = AppSettings.URL + "FlashCards/CardItem";
            var response = await PostAsync(url, data);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<int>(response);

            return result;
        }

        public async Task EditFlashcardItem(CreateOrEditFlashcardItemViewModel data)
        {
            var url = AppSettings.URL + "FlashCards/CardItem";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task DeletelashcardItem(DeleteFlashcardItemDto data)
        {
            var url = AppSettings.URL + "FlashCards/" + data.FlashcardCollectionID + "/CardItem/" + data.FlashcardItemID;
            var response = await DeleteAsync(url);

            await HandlerErrorAsync(response);
        }

        public async Task SendAvailable(CreateFlashcardAvailableViewModel data)
        {
            var url = AppSettings.URL + "FlashCards/CardRating";
            var response = await PostAsync(url, data);

            await HandlerErrorAsync(response);
        }
    }
}
