using FlashCards.Api.Core.Directories;

namespace FlashCards.Api.Service.DTO.Directories;

public class DirectoryDto
{
    public int ID { get; private set; }
    public int? ParentID { get; private set; }
    public int UserID { get; private set; }
    public string Name { get; private set; }

    public DirectoryDto(UserDirectory data)
    {
        ID = data.UserDirectoryID;
        ParentID = data.UserDirectoryParentID;
        UserID = data.UserID;
        Name = data.Name;
    }
}
