namespace FlashCards.Api.Service.DTO.Denunciations;

public class DeleteDenunciationDto
{
    public int ID { get; private set; }

    public DeleteDenunciationDto(int id)
    {
        ID = id;
    }
}
