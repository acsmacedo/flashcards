namespace FlashCards.Api.Core.Users;

public class UserRelationship
{
    public int FollowedID { get; private set; }
    public int FollowerID { get; private set; }
    public bool EnableNotification { get; private set; }

    public User? Followed { get; private set; } 
    public User? Follower { get; private set; } 

    public UserRelationship(int followedID, int followerID, bool enableNotification)
    {
        FollowedID = followedID;
        FollowerID = followerID;
        EnableNotification = enableNotification;
    }

    public void EditNotification(bool enableNotification)
    {
        EnableNotification = enableNotification;
    }
}
