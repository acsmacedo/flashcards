using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Core.Directories;
using FlashCards.Api.Core.NotificationSettings;
using FlashCards.Api.Core.SubscriptionTypes;

namespace FlashCards.Api.Core.Users;

public class User
{
    public const int NameMaxLength = 80;
    public const int InstagramMaxLength = 80;
    public const int InterestsMaxLength = 80;
    public const int PhotoMaxLength = 1000;
    public const string PhotoDefault = @"http://acsmacedo.somee.com/images/photos/photo-0.jpg";
    public int ID { get; private set; }
    public int AccountID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Instagram { get; private set; }
    public string? Interests { get; private set; }
    public int? SubscriptionTypeID { get; private set; }
    public string? Photo { get; private set; }

    public Account? Account { get; private set; }
    public SubscriptionType? SubscriptionType { get; private set; }
    public IReadOnlyCollection<UserDirectory> Directories { get; private set; }
        = new List<UserDirectory>();

    private User() { }

    public User(int id, string name)
    {
        ID = id;
        AccountID = id;
        Name = name;
    }

    public User(Account account, string name, int? subscriptionTypeID)
    {
        Account = account;
        Name = name;
        SubscriptionTypeID = subscriptionTypeID;
    }

    public void Edit(string name, string? instagram, string? interests)
    {
        Name = name;
        Instagram = instagram;
        Interests = interests;
    }

    public void ChangeSubscriptionType(int subscriptionTypeID)
    {
        SubscriptionTypeID = subscriptionTypeID;
    }

    #region Relationship
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
    #endregion

    #region NotifiactionsSettings
    private List<UserNotificationSetting> _notificationSettings = new();
    public IReadOnlyCollection<UserNotificationSetting> NotiicationSettings => _notificationSettings;

    public void AddOrEditNotificationSettings(int notificationSettingID, NotificationSettingStatus status)
    {
        var setting = _notificationSettings.FirstOrDefault(x => x.NotificationSettingID == notificationSettingID);
        if (setting == null)
        {
            var newFollowed = new UserNotificationSetting(notificationSettingID, status);
            _notificationSettings.Add(newFollowed);
        }
        else
        {
            setting.Edit(status);
        }
    }

    public NotificationSettingStatus GetNotificationStatus(int notificationSettingID)
    {
        var setting = _notificationSettings.FirstOrDefault(x => x.NotificationSettingID == notificationSettingID);
        if (setting != null)
        {
            return setting.Status;
        }
        else
        {
            return NotificationSettingStatus.None;
        }
    }

    public void UpdatePhoto(string filePath)
    {
        Photo = filePath;
    }
    #endregion
}
