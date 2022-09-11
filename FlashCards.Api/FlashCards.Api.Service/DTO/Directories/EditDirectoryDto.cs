namespace FlashCards.Api.Service.DTO.Directories;

public class EditDirectoryDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }

    public EditDirectoryDto(int id, string name)
    {
        ID = id;
        Name = name;
    }
}
