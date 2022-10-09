using FlashCards.App.ViewModels.Accounts;
using System.Net.Http;
using System.Threading.Tasks;
using FlashCards.App.Models.Accounts;
using Xamarin.Forms;
using FlashCards.App.Interfaces;
using FlashCards.App.Utils;
using FlashCards.App.Views.Account;

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

            Application.Current.Properties["user_id"] = result.UserID;

            await Application.Current.SavePropertiesAsync();
        }

        public async Task SignUp(SignUpAccountViewModel viewModel)
        {
            var url = AppSettings.URL + "Accounts/SignUp";
            var response = await PostAsync(url, viewModel);

            await HandlerErrorAsync(response);

            var result = await ReadAsync<Account>(response);

            Application.Current.Properties["user_id"] = result.UserID;

            await Application.Current.SavePropertiesAsync();
        }

        public async Task Logout()
        {
            Application.Current.Properties.Remove("user_id");

            await Application.Current.SavePropertiesAsync();

            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
