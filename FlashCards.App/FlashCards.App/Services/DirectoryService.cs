using FlashCards.App.Interfaces;
using FlashCards.App.Models.Directories;
using FlashCards.App.Utils;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlashCards.App.Services
{
    public class DirectoryService : BaseService, IDirectoryService
    {
        public DirectoryService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<int> CreateDirectory(CreateUserDirectoryDto data)
        {
            var url = AppSettings.URL + "Directories";
            var response = await PostAsync(url, data);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<int>(response);

            return result;
        }

        public async Task EditDirectory(EditUserDirectoryDto data)
        {
            var url = AppSettings.URL + "Directories";
            var response = await PutAsync(url, data);

            await HandlerErrorAsync(response);
        }

        public async Task DeleteDirectory(DeleteUserDirectoryDto data)
        {
            var url = AppSettings.URL + "Directories/" + data.ID;
            var response = await DeleteAsync(url);

            await HandlerErrorAsync(response);
        }

        public async Task<UserDirectory> GetUserDirectory(int userID, int? directoryID)
        {
            var url = AppSettings.URL + "Users/" + userID + "/Directories/" + directoryID;
            var response = await GetAsync(url);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<UserDirectory>(response);

            return result;
        }
    }
}
