using FlashCards.App.Interfaces;
using FlashCards.App.Services;
using FlashCards.App.ViewModels.Accounts;
using Microsoft.Extensions.DependencyInjection;

namespace FlashCards.App.IoC
{
    public static class AccountInjection
    {
        public static void ConfigureAccounts(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            services.AddTransient<LoginAccountViewModel>();
            services.AddTransient<SignUpAccountViewModel>();
            services.AddTransient<ChangePasswordAccountViewModel>();
        }
    }
}
