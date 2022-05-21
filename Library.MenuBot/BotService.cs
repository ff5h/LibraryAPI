using Library.MenuBot.Configurations;
using Library.MenuBot.HostedServices;
using Library.MenuBot.Services;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot
{
    public class BotService : BackgroundService
    {
        private readonly IServiceProvider _provider;

        public BotService(IServiceProvider provider)
        {
            _provider = provider;
        }

        private IServiceProvider GetAPIProvider()
        {
            return _provider.CreateScope().ServiceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                var builder = Host.CreateDefaultBuilder(); 
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton(_ => new TokenConfiguration(GetAPIProvider().GetService<IConfiguration>()
                                                                                      .GetSection("MenuBotConfiguration")
                                                                                      .GetValue<string>("Token")));
                    services.AddMediatR(typeof(BotService));
                    services.AddScoped(_ => GetAPIProvider().GetService<IAppDBContext>());
                    services.AddScoped(_ => GetAPIProvider().GetService<IDataStorageService<Guid>>());
                    services.AddSingleton(_ => GetAPIProvider().GetService<IUserService>());
                    services.AddSingleton<ITelegramService, TelegramService>();
                    services.AddHostedService<ProcessingService>();
                });
                var app = builder.Build();
                app.Run();
            });
        }
    }
}