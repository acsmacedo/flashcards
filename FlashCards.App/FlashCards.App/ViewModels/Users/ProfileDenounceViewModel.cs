using FlashCards.App.Interfaces;
using FlashCards.App.Models.Users;
using System;
using Xamarin.Forms;

namespace FlashCards.App.ViewModels.Users
{
    public class ProfileDenounceViewModel : BaseViewModel
    {
        private readonly IUserService _service;

        public Command SubmitDenounceProfileCommand { get; }

        public ProfileDenounceViewModel(IUserService service)
        {
            _service = service;

            SubmitDenounceProfileCommand = new Command(SubmitDenounceProfile);
        }

        private int _accuserID;
        public int AccuserID
        {
            get => _accuserID;
            set => SetProperty(ref _accuserID, value);
        }

        private int _suspectID;
        public int SuspectID
        {
            get => _suspectID;
            set => SetProperty(ref _suspectID, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _photo;
        public string Photo
        {
            get => _photo;
            set => SetProperty(ref _photo, value);
        }

        private string _instagram;
        public string Instagram
        {
            get => _instagram;
            set => SetProperty(ref _instagram, value);
        }

        private bool _isInvalid => 
            string.IsNullOrEmpty(Title) ||
            string.IsNullOrEmpty(Description);

        public void SetInitialData(UserRelationship data)
        {
            AccuserID = UserID;
            SuspectID = data.ID;
            Photo = data.Photo;
            Instagram = data.Instagram;
            Name = data.Name;
        }

        private async void SubmitDenounceProfile()
        {
            try
            {
                if (_isInvalid)
                {
                    DisplayError(message: "O campo ocorrência e descrição são obrigatórios.");
                    return;
                }

                await _service.DenounceProfile(this);

                await DisplaySuccess();

                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayError(message: ex.Message);
            }
        }
    }
}
