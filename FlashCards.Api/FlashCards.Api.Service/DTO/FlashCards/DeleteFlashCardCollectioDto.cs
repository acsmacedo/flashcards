namespace FlashCards.Api.Service.DTO.FlashCards;

public class DeleteFlashCardCollectioDto
{
    public int ID { get; private set; }

    public DeleteFlashCardCollectioDto(int id)
    {
        ID = id;
    }
}
