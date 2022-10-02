using FlashCards.App.Interfaces;
using FlashCards.App.Services;
using FlashCards.App.ViewModels.SubscriptionTypes;
using Microsoft.Extensions.DependencyInjection;

namespace FlashCards.App.IoC
{
    public static class SubscriptionTypeInjection
    {
        public static void ConfigureSubscriptionTypes(this IServiceCollection services)
        {
            services.AddScoped<ISubscriptionTypeService, SubscriptionTypeService>();

            services.AddTransient<SubscriptionTypesViewModel>();
        }
    }
}
