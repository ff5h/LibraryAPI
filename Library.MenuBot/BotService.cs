using Library.MenuBot.HostedServices;
using Library.Repository.Interfaces;
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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                var configuration = _provider.GetService<IConfiguration>();
                string token = configuration.GetSection("MenuBotConfiguration").GetValue<string>("Token");
                var builder = Host.CreateDefaultBuilder();
                var botClient = new TelegramBotClient(token);
                builder.ConfigureServices(services =>
                {
                    services.AddMediatR(typeof(BotService));
                    services.AddSingleton<ITelegramBotClient>(botClient);
                    services.AddScoped(_ => _provider.CreateScope().ServiceProvider.GetService<IAppDBContext>());
                    services.AddHostedService<ProcessingService>();
                });
                var app = builder.Build();
                app.Run();
            });
        }
    }
}