namespace FlashCards.Api.Service.DTO.Directories;

public class DeleteDirectoryDto
{
    public int ID { get; private set; }

    public DeleteDirectoryDto(int id)
    {
        ID = id;
    }
}
