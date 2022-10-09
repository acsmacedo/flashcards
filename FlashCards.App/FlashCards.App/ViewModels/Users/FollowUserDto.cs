namespace FlashCards.App.ViewModels.Users
{
    public class FollowUserDto
    {
        public int FollowerID { get; private set; }
        public int FollowedID { get; private set; }

        public FollowUserDto(
            int followerID,
            int followedID)
        {
            FollowerID = followerID;
            FollowedID = followedID;
        }
    }
}
