using FlashCards.App.ViewModels.Accounts;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface IAccountService
    {
        Task Login(LoginAccountViewModel viewModel);
        Task SignUp(SignUpAccountViewModel viewModel);
        Task ChangePassword(ChangePasswordAccountViewModel viewModel);
    }
}
