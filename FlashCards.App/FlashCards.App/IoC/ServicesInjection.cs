using FlashCards.App.Interfaces;
using FlashCards.App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlashCards.App.IoC
{
    public static class ServicesInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INotificationSettingService, NotificationSettingService>();
            services.AddScoped<ISubscriptionTypeService, SubscriptionTypeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFlashcardCollectionService, FlashcardCollectionService>();
        }
    }
}
