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
        public Command ToggleVisibilityPasswordCommand { get; }
        public Command ToggleVisibilityConfirmPasswordCommand { get; }

        public SignUpAccountViewModel(IAccountService service)
        {
            _service = service;

            SignUpCommand = new Command(SignUp);
            GoToTermsAndConditionsCommand = new Command(GoToTermsAndConditions);
            ToggleVisibilityPasswordCommand = new Command(ToggleVisibilityPassword);
            ToggleVisibilityConfirmPasswordCommand = new Command(ToggleVisibilityConfirmPassword);
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

        private bool _agreeTerms;
        public bool AgreeTerms
        {
            get => _agreeTerms;
            set => SetProperty(ref _agreeTerms, value);
        }

        private bool _hidePassword = true;
        public bool HidePassword
        {
            get => _hidePassword;
            set => SetProperty(ref _hidePassword, value);
        }

        private bool _hideConfirmPassword = true;
        public bool HideConfirmPassword
        {
            get => _hideConfirmPassword;
            set => SetProperty(ref _hideConfirmPassword, value);
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

                if (!AgreeTerms)
                {
                    DisplayError(message: "Você precisa concordar com os termos para continuar o cadastro.");
                    return;
                }

                //await _service.SignUp(this);
                //Application.Current.MainPage = new AppShell();

                DisplayError(message: "Não é possível criar uma conta no momento!");
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }

        private void GoToTermsAndConditions(object sender)
        {
            Navigation.PushAsync(new TermsAndConditionsPage());
        }

        private void ToggleVisibilityPassword()
        {
            HidePassword = !HidePassword;
        }

        private void ToggleVisibilityConfirmPassword()
        {
            HideConfirmPassword = !HideConfirmPassword;
        }
    }
}
