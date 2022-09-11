using FlashCards.Api.Core.FlashCards;
using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Core.Directories;

public class UserDirectory
{
    public const int NameMaxLength = 80;

    public int UserDirectoryID { get; private set; }
    public int? UserDirectoryParentID { get; private set; }
    public int UserID { get; private set; }
    public string Name { get; private set; }

    public User User { get; private set; } = User.Empty;
    public UserDirectory? Parent { get; private set; }
    public IReadOnlyCollection<UserDirectory> Children { get; private set; }
        = new List<UserDirectory>();
    public IReadOnlyCollection<FlashCardCollection> FlashCardCollections { get; private set; }
        = new List<FlashCardCollection>();

    public UserDirectory(
        int userDirectoryID,
        int? userDirectoryParentID,
        int userID,
        string name)
    {
        UserDirectoryID = userDirectoryID;
        UserDirectoryParentID = userDirectoryParentID;
        UserID = userID;
        Name = name;
    }

    public static UserDirectory Empty => new(0, null, 0, string.Empty);
}
