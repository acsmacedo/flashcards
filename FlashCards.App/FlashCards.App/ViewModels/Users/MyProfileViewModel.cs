using FlashCards.App.Interfaces;
using FlashCards.App.Models.Users;
using System;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Users
{
    public class MyProfileViewModel : BaseViewModel
    {
        private readonly IUserService _service;
        public Command SubmitEditProfileCommand { get; }
        public Command EditPhotoCommand { get; }

        public MyProfileViewModel(IUserService service)
        {
            _service = service;

            SubmitEditProfileCommand = new Command(SubmitEditProfile);
            EditPhotoCommand = new Command(EditPhoto);
        }

        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _instagram;
        public string Instagram
        {
            get => _instagram;
            set => SetProperty(ref _instagram, value);
        }

        private string _interests;
        public string Interests
        {
            get => _interests;
            set => SetProperty(ref _interests, value);
        }

        private string _photo;
        public string Photo
        {
            get => _photo;
            set => SetProperty(ref _photo, value);
        }

        private bool _isInvalid => string.IsNullOrEmpty(Name);

        public void SetInitialData(User data)
        {
            ID = data.ID;
            Name = data.Name;
            Instagram = data.Instagram;
            Interests = data.Interests;
            Photo = data.Photo + "?&g=" + Guid.NewGuid();
        }

        private async void SubmitEditProfile(object sender)
        {
            try
            {
                if (_isInvalid)
                {
                    DisplayError(message: "O campo nome é obrigatório.");
                    return;
                }

                await _service.EditProfile(this);

                await DisplaySuccess();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }

        private async void EditPhoto(object sender)
        {
            try
            {
                var success = await _service.UpdatePhoto(UserID);

                if (success)
                {
                    await DisplaySuccess();

                    var user = await _service.GetUserByID(UserID);

                    SetInitialData(user);
                }
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }
    }
}
