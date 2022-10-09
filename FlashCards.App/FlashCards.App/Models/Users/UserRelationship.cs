namespace FlashCards.App.Models.Users
{
    public class UserRelationship : BaseModel
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Instagram { get; private set; }
        public string Interests { get; private set; }
        public string Photo { get; private set; }
        public int Following { get; private set; }
        public int Followers { get; private set; }
        public int Available { get; private set; }
        public int Stars { get; private set; }


        private bool _isFollowed;
        public bool IsFollowed
        {
            get => _isFollowed;
            set
            {
                _isFollowed = value;
                RaisePropertyChanged(nameof(IsFollowed));
            }
        }

        private bool _isEnableNotification;
        public bool IsEnableNotification
        {
            get => _isEnableNotification;
            set
            {
                _isEnableNotification = value;
                RaisePropertyChanged(nameof(IsEnableNotification));
            }
        }

        private bool _notIsFollowed;
        public bool NotIsFollowed
        {
            get => _notIsFollowed;
            set
            {
                _notIsFollowed = value;
                RaisePropertyChanged(nameof(NotIsFollowed));
            }
        }

        private bool _notIsEnableNotification;
        public bool NotIsEnableNotification
        {
            get => _notIsEnableNotification;
            set
            {
                _notIsEnableNotification = value;
                RaisePropertyChanged(nameof(NotIsEnableNotification));
            }
        }

        public UserRelationship(
            int id,
            string name,
            string instagram,
            string interests,
            string photo,
            int following,
            int followers,
            int available,
            int stars,
            bool isFollowed,
            bool isEnableNotification)
        {
            ID = id;
            Name = name;
            Instagram = instagram;
            Interests = interests;
            Photo = photo;
            Following = following;
            Followers = followers;
            Available = available;
            Stars = stars;
            IsFollowed = isFollowed;
            IsEnableNotification = isEnableNotification;

            NotIsFollowed = !IsFollowed;
            NotIsEnableNotification = IsFollowed && !IsEnableNotification;
        }

        public void Follow()
        {
            IsFollowed = true;
            NotIsFollowed = !IsFollowed;

            NotIsEnableNotification = IsFollowed && !IsEnableNotification;
        }

        public void Unfollow()
        {
            IsFollowed = false;
            NotIsFollowed = !IsFollowed;

            IsEnableNotification = false;
            NotIsEnableNotification = IsFollowed && !IsEnableNotification;
        }

        public void DisableNotificationUser()
        {
            IsEnableNotification = false;
            NotIsEnableNotification = IsFollowed && !IsEnableNotification;
        }

        public void EnableNotificationUser()
        {
            IsEnableNotification = true;
            NotIsEnableNotification = IsFollowed && !IsEnableNotification;
        }
    }
}
