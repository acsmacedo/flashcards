namespace FlashCards.Api.Service.DTO.Directories;

public class CreateDirectoryDto
{
    public int? ParentID { get; private set; }
    public int UserID { get; private set; }
    public string Name { get; private set; }

    public CreateDirectoryDto(
        int? parentID, 
        int userID, 
        string name)
    {
        ParentID = parentID;
        UserID = userID;
        Name = name;
    }
}
