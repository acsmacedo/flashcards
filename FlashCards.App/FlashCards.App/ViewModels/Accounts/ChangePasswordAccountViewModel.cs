using FlashCards.App.Interfaces;
using System;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Accounts
{
    public class ChangePasswordAccountViewModel : BaseViewModel
    {
        private readonly IAccountService _service;
        public Command ChangePasswordCommand { get; }

        public ChangePasswordAccountViewModel(IAccountService service)
        {
            _service = service;

            ChangePasswordCommand = new Command(ChangePassword);
        }

        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _oldPassword;
        public string OldPassword
        {
            get => _oldPassword;
            set => SetProperty(ref _oldPassword, value);
        }

        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set => SetProperty(ref _newPassword, value);
        }

        private string _confirmNewPassword;
        public string ConfirmNewPassword
        {
            get => _confirmNewPassword;
            set => SetProperty(ref _confirmNewPassword, value);
        }

        private bool _isInvalid =>
            string.IsNullOrEmpty(OldPassword) ||
            string.IsNullOrEmpty(NewPassword) ||
            string.IsNullOrEmpty(ConfirmNewPassword);

        private async void ChangePassword(object sender)
        {
            try
            {
                if (_isInvalid)
                {
                    DisplayError(message: "Preencha todos os campos de senha.");
                    return;
                }

                ID = UserID;

                await _service.ChangePassword(this);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }
    }
}
