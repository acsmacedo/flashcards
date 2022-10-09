using FlashCards.App.Interfaces;
using FlashCards.App.Models.Categories;
using FlashCards.App.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlashCards.App.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var url = AppSettings.URL + "Categories";
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<IEnumerable<Category>>(response);

            return result;
        }
    }
}
