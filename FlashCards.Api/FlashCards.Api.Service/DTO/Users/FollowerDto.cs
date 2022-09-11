using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.Users;

public class FollowerDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public bool IsFollowing { get; private set; }
    public bool EnableNotification { get; private set; }

    public FollowerDto(UserRelationship data, User user)
    {
        ID = data.Follower?.ID ?? 0;
        Name = data.Follower?.Name ?? string.Empty;

        var isFollowing = user.Following.FirstOrDefault(x => x.FollowedID == data.Follower?.ID);

        IsFollowing = isFollowing != null;
        EnableNotification = isFollowing?.EnableNotification ?? false;
    }
}
