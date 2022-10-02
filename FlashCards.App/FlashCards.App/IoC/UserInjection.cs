using FlashCards.App.Interfaces;
using FlashCards.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlashCards.App.IoC
{
    public static class UserInjection
    {
        public static void ConfigureUsers(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
