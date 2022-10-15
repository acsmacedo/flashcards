using FlashCards.App.Models.Directories;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface IDirectoryService
    {
        Task<UserDirectory> GetUserDirectory(int userID, int? directoryID);

        Task<int> CreateDirectory(CreateUserDirectoryDto data);
        Task EditDirectory(EditUserDirectoryDto data);
        Task DeleteDirectory(DeleteUserDirectoryDto data);
    }
}
