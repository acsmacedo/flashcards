namespace FlashCards.Api.Service.DTO.Denunciations;

public class CreateDenunciationDto
{
    public int AccuserID { get; private set; }
    public int SuspectID { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public CreateDenunciationDto(
        int accuserID, 
        int suspectID, 
        string title, 
        string description)
    {
        AccuserID = accuserID;
        SuspectID = suspectID;
        Title = title;
        Description = description;
    }
}
