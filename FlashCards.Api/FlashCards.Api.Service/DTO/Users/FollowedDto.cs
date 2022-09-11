using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.Users;

public class FollowedDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public bool EnableNotification { get; private set; }

    public FollowedDto(UserRelationship data)
    {
        ID = data.Followed?.ID ?? 0;
        Name = data.Followed?.Name ?? string.Empty;
        EnableNotification = data.EnableNotification;
    }
}
