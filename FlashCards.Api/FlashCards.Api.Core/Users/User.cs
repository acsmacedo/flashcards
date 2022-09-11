using FlashCards.Api.Core.Directories;

namespace FlashCards.Api.Core.Users;

public class User
{
    public const int NameMaxLength = 80;
    public const int InstagramMaxLength = 80;
    public const int InterestsMaxLength = 80;

    public int UserID { get; private set; }
    public string Name { get; private set; }
    public string Instagram { get; private set; }
    public string Interests { get; private set; }
    public IReadOnlyCollection<UserDirectory> Directories { get; private set; }
        = new List<UserDirectory>();

    public User(
        int userID,
        string name,
        string instagram,
        string interests)
    {
        UserID = userID;
        Name = name;
        Instagram = instagram;
        Interests = interests;
    }

    public static User Empty => new(0, string.Empty, string.Empty, string.Empty);
}
