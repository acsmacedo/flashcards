namespace FlashCards.App.ViewModels.Users
{
    public class UnfollowUserDto
    {
        public int FollowerID { get; private set; }
        public int UnfollowedID { get; private set; }

        public UnfollowUserDto(
            int followerID,
            int unfollowedID)
        {
            FollowerID = followerID;
            UnfollowedID = unfollowedID;
        }
    }
}
