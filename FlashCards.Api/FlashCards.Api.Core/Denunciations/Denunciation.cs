using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Core.Denunciations;

public class Denunciation
{
    public const int TitleMaxLength = 80;
    public const int DescriptionMaxLength = 500;

    public int DenunciationID { get; private set; }
    public int AccuserID { get; private set; }
    public int SuspectID { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DenunciationStatus Status { get; private set; }
    public User Accuser { get; private set; } = User.Empty;
    public User Suspect { get; private set; } = User.Empty;

    public Denunciation(
        int denunciationID, 
        int accuserID, 
        int suspectID,
        string title,
        string description, 
        DenunciationStatus status)
    {
        DenunciationID = denunciationID;
        AccuserID = accuserID;
        SuspectID = suspectID;
        Title = title;
        Description = description;
        Status = status;
    }
}
