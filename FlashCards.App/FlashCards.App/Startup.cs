using FlashCards.App.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlashCards.App
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Init()
        {
            var provider = new ServiceCollection();
            
            provider.ConfigureInfrastructure();
            provider.ConfigureServices();
            provider.ConfigureViewModels();
            
            ServiceProvider = provider.BuildServiceProvider();
        }
    }
}
