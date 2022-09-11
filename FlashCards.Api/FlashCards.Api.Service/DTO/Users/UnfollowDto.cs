namespace FlashCards.Api.Service.DTO.Users;

public class UnfollowDto
{
    public int FollowerID { get; private set; }
    public int UnfollowedID { get; private set; }

    public UnfollowDto(int followerID, int unfollowedID)
    {
        FollowerID = followerID;
        UnfollowedID = unfollowedID;
    }
}
