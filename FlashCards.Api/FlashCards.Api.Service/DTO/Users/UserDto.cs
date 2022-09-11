using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.Users;

public class UserDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string? Instagram { get; private set; }
    public string? Interests { get; private set; }
    public IEnumerable<FollowedDto> Following { get; private set; }
    public IEnumerable<FollowerDto> Followers { get; private set; }

    public UserDto(User data)
    {
        ID = data.ID;
        Name = data.Name;
        Instagram = data.Instagram;
        Interests = data.Interests;
        Following = data.Following.Select(x => new FollowedDto(x));
        Followers = data.Followers.Select(x => new FollowerDto(x, data));
    }
}
