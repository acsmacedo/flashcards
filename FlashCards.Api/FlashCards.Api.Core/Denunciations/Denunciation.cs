using FlashCards.Api.Core.Users;

namespace FlashCards.Api.Core.Denunciations;

public class Denunciation
{
    public const int TitleMaxLength = 80;
    public const int DescriptionMaxLength = 500;

    public int ID { get; private set; }
    public int AccuserID { get; private set; }
    public int SuspectID { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DenunciationStatus Status { get; private set; }
    public User? Accuser { get; private set; }
    public User? Suspect { get; private set; }

    public Denunciation(
        int accuserID, 
        int suspectID,
        string title,
        string description)
    {
        AccuserID = accuserID;
        SuspectID = suspectID;
        Title = title;
        Description = description;
        Status = DenunciationStatus.New;
    }
}
