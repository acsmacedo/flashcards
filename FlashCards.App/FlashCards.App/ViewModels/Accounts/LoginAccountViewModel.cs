using FlashCards.App.Interfaces;
using FlashCards.App.Views.Account;
using System;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Accounts
{
    public class LoginAccountViewModel : BaseViewModel
    {
        private readonly IAccountService _service;
        public Command LoginCommand { get; }
        public Command GoToSignUpCommand { get; }

        public LoginAccountViewModel(IAccountService service)
        {
            _service = service;

            LoginCommand = new Command(Login);
            GoToSignUpCommand = new Command(GoToSignUp);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private bool _isInvalid => 
            string.IsNullOrEmpty(Email) || 
            string.IsNullOrEmpty(Password);

        private async void Login(object sender)
        {
            try
            {
                if (_isInvalid)
                {
                    DisplayError(message: "Preencha os campos de e-mail e senha.");
                    return;
                }

                await _service.Login(this);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }

        private void GoToSignUp(object sender)
        {
            Navigation.PushAsync(new CreateAccountPage());
        }
    }
}
