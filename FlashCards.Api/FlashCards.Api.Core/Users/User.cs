using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Directories;
using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Core.Users;

public class User
{
    public const int NameMaxLength = 80;
    public const int InstagramMaxLength = 80;
    public const int InterestsMaxLength = 80;

    public int ID { get; private set; }
    public int AccountID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Instagram { get; private set; }
    public string? Interests { get; private set; }

    public Account Account { get; private set; } = Account.Empty;
    //public IReadOnlyCollection<UserDirectory> Directories { get; private set; }
    //    = new List<UserDirectory>();

    private User() { }

    public User(Account account)
    {
        Account = account;
        Name = "Sem Nome";
    }

    public void Edit(string name, string? instagram, string? interests)
    {
        Name = name;
        Instagram = instagram;
        Interests = interests;
    }

    private List<UserRelationship> _following = new();
    public IReadOnlyCollection<UserRelationship> Following => _following;
    public IReadOnlyCollection<UserRelationship> Followers { get; private set; }
        = new List<UserRelationship>();

    public void Follow(User user)
    {
        var followed = _following.FirstOrDefault(x => x.FollowedID == user.ID);
        if (followed == null)
        {
            var newFollowed = new UserRelationship(user.ID, ID, false);
            _following.Add(newFollowed);
        }
    }

    public void Unfollow(User user)
    {
        var followed = _following.FirstOrDefault(x => x.FollowedID == user.ID);
        if (followed != null)
        {
            _following.Remove(followed);
        }
    }

    public void EditNotificationFollowed(int followedID, bool enableNotification)
    {
        var followed = _following.FirstOrDefault(x => x.FollowedID == followedID);
        if (followed != null)
        {
            followed.EditNotification(enableNotification);
        }
    }

    public static User Empty => new(Account.Empty);
}
