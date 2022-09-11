namespace FlashCards.Api.Service.DTO.Users;

public class FollowDto
{
    public int FollowerID { get; private set; }
    public int FollowedID { get; private set; }

    public FollowDto(int followerID, int followedID)
    {
        FollowerID = followerID;
        FollowedID = followedID;
    }
}
