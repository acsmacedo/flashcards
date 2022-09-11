using FlashCards.Api.Service.DTO.Directories;

namespace FlashCards.Api.Service.Interfaces;

public interface IDirectoryService
{
    Task<IEnumerable<DirectoryDto>> GetByUserIDAsync(int userID);
    Task CreateAsync(CreateDirectoryDto data);
    Task EditAsync(EditDirectoryDto data);
    Task DeleteAsync(DeleteDirectoryDto data);
}
