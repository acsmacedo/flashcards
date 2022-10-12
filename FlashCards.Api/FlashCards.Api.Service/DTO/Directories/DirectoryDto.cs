using FlashCards.Api.Core.Directories;
using FlashCards.Api.Service.DTO.FlashCards;

namespace FlashCards.Api.Service.DTO.Directories;

public class DirectoryDto
{
    public int ID { get; private set; }
    public int? ParentID { get; private set; }
    public int UserID { get; private set; }
    public string Name { get; private set; }
    public IEnumerable<DirectoryItemDto> Directories { get; private set; }
    public IEnumerable<FlashCardCollectionDto> Cards { get; private set; }

    public DirectoryDto(UserDirectory data)
    {
        ID = data.ID;
        ParentID = data.UserDirectoryParentID;
        UserID = data.UserID;
        Name = data.Name;
        Directories = data.Children.Select(x => new DirectoryItemDto(x));
        Cards = data.FlashCardCollections.Select(x => new FlashCardCollectionDto(x));
    }
}
