using FlashCards.App.ViewModels.Accounts;
using System.Net.Http;
using System.Threading.Tasks;
using FlashCards.App.Models.Accounts;
using Xamarin.Forms;
using FlashCards.App.Interfaces;
using FlashCards.App.Utils;

namespace FlashCards.App.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IHttpClientFactory httpClientFactory): base(httpClientFactory)
        {     
        }

        public async Task ChangePassword(ChangePasswordAccountViewModel viewModel)
        {
            var url = AppSettings.URL + "Accounts/ChangePassword";
            var response = await PutAsync(url, viewModel);

            await HandlerErrorAsync(response);
        }

        public async Task Login(LoginAccountViewModel viewModel)
        {
            var url = AppSettings.URL + "Accounts/Login";
            var response = await PostAsync(url, viewModel);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<Account>(response);

            Application.Current.Properties["user_account"] = result;
        }

        public async Task SignUp(SignUpAccountViewModel viewModel)
        {
            var url = AppSettings.URL + "Accounts/SignUp";
            var response = await PostAsync(url, viewModel);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<Account>(response);

            Application.Current.Properties["user_account"] = result;
        }
    }
}
