using FlashCards.Api.Service.DTO.Directories;

namespace FlashCards.Api.Service.Interfaces;

public interface IDirectoryService
{
    Task<DirectoryDto> GetByUserIDAsync(int userID, int? directoryID);
    Task<int> CreateAsync(CreateDirectoryDto data);
    Task EditAsync(EditDirectoryDto data);
    Task DeleteAsync(DeleteDirectoryDto data);
}
