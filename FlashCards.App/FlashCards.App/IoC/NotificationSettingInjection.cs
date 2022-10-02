using FlashCards.App.Interfaces;
using FlashCards.App.Services;
using FlashCards.App.ViewModels.NotificationSettings;
using Microsoft.Extensions.DependencyInjection;

namespace FlashCards.App.IoC
{
    public static class NotificationSettingInjection
    {
        public static void ConfigureNotificationSettings(this IServiceCollection services)
        {
            services.AddScoped<INotificationSettingService, NotificationSettingService>();

            services.AddTransient<NotificationSettingsViewModel>();
        }
    }
}
