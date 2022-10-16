using FlashCards.App.Interfaces;
using System;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Accounts
{
    public class ChangePasswordAccountViewModel : BaseViewModel
    {
        private readonly IAccountService _service;
        public Command ChangePasswordCommand { get; }
        public Command ToggleVisibilityOldPasswordCommand { get; }
        public Command ToggleVisibilityNewPasswordCommand { get; }
        public Command ToggleVisibilityConfirmNewPasswordCommand { get; }

        public ChangePasswordAccountViewModel(IAccountService service)
        {
            _service = service;

            ChangePasswordCommand = new Command(ChangePassword);
            ToggleVisibilityOldPasswordCommand = new Command(ToggleVisibilityOldPassword);
            ToggleVisibilityNewPasswordCommand = new Command(ToggleVisibilityNewPassword);
            ToggleVisibilityConfirmNewPasswordCommand = new Command(ToggleVisibilityConfirmNewPassword);
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

        private bool _hideOldPassword = true;
        public bool HideOldPassword
        {
            get => _hideOldPassword;
            set => SetProperty(ref _hideOldPassword, value);
        }

        private bool _hideNewPassword = true;
        public bool HideNewPassword
        {
            get => _hideNewPassword;
            set => SetProperty(ref _hideNewPassword, value);
        }

        private bool _hideConfirmNewPassword = true;
        public bool HideConfirmNewPassword
        {
            get => _hideConfirmNewPassword;
            set => SetProperty(ref _hideConfirmNewPassword, value);
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

                await DisplaySuccess();

                await _service.ChangePassword(this);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }

        private void ToggleVisibilityOldPassword()
        {
            HideOldPassword = !HideOldPassword;
        }

        private void ToggleVisibilityNewPassword()
        {
            HideNewPassword = !HideNewPassword;
        }

        private void ToggleVisibilityConfirmNewPassword()
        {
            HideConfirmNewPassword = !HideConfirmNewPassword;
        }
    }
}
