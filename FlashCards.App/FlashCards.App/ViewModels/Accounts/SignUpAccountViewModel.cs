using FlashCards.App.Interfaces;
using FlashCards.App.Views.Account;
using System;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Accounts
{
    public class SignUpAccountViewModel : BaseViewModel
    {
        private readonly IAccountService _service;
        public Command SignUpCommand { get; }
        public Command GoToTermsAndConditionsCommand { get; }

        public SignUpAccountViewModel(IAccountService service)
        {
            _service = service;

            SignUpCommand = new Command(SignUp);
            GoToTermsAndConditionsCommand = new Command(GoToTermsAndConditions);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        private bool _isInvalid =>
            string.IsNullOrEmpty(Name) ||
            string.IsNullOrEmpty(Email) ||
            string.IsNullOrEmpty(Password) ||
            string.IsNullOrEmpty(ConfirmPassword);

        private async void SignUp(object sender)
        {
            try
            {
                if (_isInvalid)
                {
                    DisplayError(message: "Preencha os campos de nome, e-mail e senha.");
                    return;
                }

                await _service.SignUp(this);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }

        private void GoToTermsAndConditions(object sender)
        {
            Navigation.PushAsync(new CreateAccountPage());
        }
    }
}
