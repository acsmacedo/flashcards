namespace FlashCards.App.Models.NotificationSettings
{
    public class NotificationSettingByUser : BaseModel
    {
        public int UserID { get; private set; }
        public int NotificationSettingID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private NotificationSettingStatus _status;
        public NotificationSettingStatus Status 
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        public NotificationSettingByUser(
            int userID,
            int notificationSettingID, 
            string name, 
            string description,
            NotificationSettingStatus status)
        {
            UserID = userID;
            NotificationSettingID = notificationSettingID;
            Name = name;
            Description = description;
            Status = status;
        }

        public void Change(NotificationSettingStatus status)
        {
            Status = status;
        }
    }
}
