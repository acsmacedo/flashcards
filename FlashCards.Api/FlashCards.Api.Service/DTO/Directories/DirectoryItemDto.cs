using FlashCards.Api.Core.Directories;

namespace FlashCards.Api.Service.DTO.Directories
{
    public class DirectoryItemDto
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public DirectoryItemDto(UserDirectory data)
        {
            ID = data.ID;
            Name = data.Name;
        }
    }
}
