using FlashCards.App.ViewModels.Accounts;
using FlashCards.App.ViewModels.Directories;
using FlashCards.App.ViewModels.Flashcards;
using FlashCards.App.ViewModels.Home;
using FlashCards.App.ViewModels.Network;
using FlashCards.App.ViewModels.NotificationSettings;
using FlashCards.App.ViewModels.Settings;
using FlashCards.App.ViewModels.SubscriptionTypes;
using FlashCards.App.ViewModels.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FlashCards.App.IoC
{
    public static class ViewModelsInjection
    {
        public static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<LoginAccountViewModel>();
            services.AddTransient<SignUpAccountViewModel>();
            services.AddTransient<ChangePasswordAccountViewModel>();

            services.AddTransient<HomeViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<NotificationSettingsViewModel>();
            services.AddTransient<SubscriptionTypesViewModel>();

            services.AddTransient<MyProfileViewModel>();
            services.AddTransient<ProfileUserViewModel>();
            services.AddTransient<ProfileDenounceViewModel>();

            services.AddTransient<NetworkViewModel>();

            services.AddTransient<MyDirectoryViewModel>();
            services.AddTransient<FlashcardsViewModel>();
            services.AddTransient<FlashcardAvailablesViewModel>();
            services.AddTransient<CreateOrEditFlashcardViewModel>();
            services.AddTransient<CreateOrEditFlashcardItemViewModel>();
            services.AddTransient<CreateFlashcardAvailableViewModel>();
        }
    }
}
