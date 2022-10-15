using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using FlashCards.App.Models.ErrorHandlers;
using Newtonsoft.Json;

namespace FlashCards.App.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        protected async Task<HttpResponseMessage> PostAsync(string url, object viewModel)
        {
            var data = JsonConvert.SerializeObject(viewModel);
            var contentRequest = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, contentRequest);

            return response;
        }

        protected async Task<HttpResponseMessage> PutAsync(string url, object viewModel)
        {
            var data = JsonConvert.SerializeObject(viewModel);
            var contentRequest = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, contentRequest);

            return response;
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);

            return response;
        }

        protected async Task<HttpResponseMessage> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            return response;
        }

        protected static async Task<TItem> ReadAsync<TItem>(HttpResponseMessage response)
        {
            var contentResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TItem>(contentResponse);

            return result;
        }

        protected static async Task HandlerErrorAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    var contentError = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<ErrorResponseData>(contentError);

                    throw new Exception(error.Message);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var contentError = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<BadResponseData>(contentError);

                    throw new Exception(string.Join("\n", error.Errors));
                }

                throw new Exception("Ocorreu um erro inesperado, tente novamente mais tarde.");
            }
        }
    }
}
