using Microsoft.Extensions.DependencyInjection;

namespace FlashCards.App.IoC
{
    public static class InfrastructureInjection
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient();
        }
    }
}
