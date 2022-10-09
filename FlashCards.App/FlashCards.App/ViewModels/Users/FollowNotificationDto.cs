namespace FlashCards.App.ViewModels.Users
{
    public class FollowNotificationDto
    {
        public int FollowerID { get; private set; }
        public int FollowedID { get; private set; }
        public bool EnableNotification { get; private set; }

        public FollowNotificationDto(
            int followerID,
            int followedID,
            bool enableNotification)
        {
            FollowerID = followerID;
            FollowedID = followedID;
            EnableNotification = enableNotification;
        }
    }
}
