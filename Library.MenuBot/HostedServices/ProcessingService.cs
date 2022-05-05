using Library.MenuBot.Commands.Updates;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Library.MenuBot.HostedServices
{
    public class ProcessingService : IHostedService, IUpdateHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;

        public ProcessingService(ITelegramBotClient botClient, ISender sender)
        {
            _botClient = botClient;
            _sender = sender;
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message       => _sender.Send(new OnMessageUpdateCommand { Message = update.Message }),
                UpdateType.CallbackQuery => _sender.Send(new OnCallbackQueryUpdateCommand { CallbackQuery = update.CallbackQuery }),
                                       _ => _sender.Send(new OnUnknownUpdateCommand { Update = update }),
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                 var receiverOptions = new ReceiverOptions() { AllowedUpdates = { } };
                _botClient.StartReceiving(this, receiverOptions, cancellationToken);
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
