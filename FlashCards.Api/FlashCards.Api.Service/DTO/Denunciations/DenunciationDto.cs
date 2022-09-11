using FlashCards.Api.Core.Denunciations;

namespace FlashCards.Api.Service.DTO.Denunciations;

public class DenunciationDto
{
    public int ID { get; private set; }
    public int AccuserID { get; private set; }
    public int SuspectID { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DenunciationStatus Status { get; private set; }

    public DenunciationDto(Denunciation data)
    {
        ID = data.ID;
        AccuserID = data.AccuserID;
        SuspectID = data.SuspectID;
        Title = data.Title;
        Description = data.Description;
        Status = data.Status;
    }
}
