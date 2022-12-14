using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Service.DTO.Users;

public class UserDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string? Instagram { get; private set; }
    public string? Interests { get; private set; }
    public string Photo { get; private set; }
    public int Following { get; private set; }
    public int Followers { get; private set; }
    public int Available { get; private set; }
    public int Stars { get; private set; }

    public UserDto(User data)
    {
        ID = data.ID;
        Name = data.Name;
        Instagram = data.Instagram;
        Interests = data.Interests;
        Photo = string.IsNullOrEmpty(data.Photo) ? User.PhotoDefault : data.Photo;
        Following = data.Following.Select(x => new FollowedDto(x)).Count();
        Followers = data.Followers.Select(x => new FollowerDto(x, data)).Count();

        var available = data.Directories.SelectMany(x => x.FlashCardCollections).SelectMany(x => x.Ratings);

        if (available.Any())
        {
            Available = available.Count();
            Stars = (int)Math.Round(available.Average(x => x.Rating));
        }
    }
}
