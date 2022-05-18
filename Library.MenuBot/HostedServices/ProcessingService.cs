using Library.MenuBot.Commands.Updates;
using Library.Shared.Enums;
using Library.Shared.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;

namespace Library.MenuBot.HostedServices
{
    public class ProcessingService : IHostedService, IUpdateHandler
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;

        public ProcessingService(ITelegramService telegramService, ISender sender)
        {
            _telegramService = telegramService;
            _sender = sender;
        }
        public async Task HandleUpdateAsync(IUpdate update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => _sender.Send(new OnMessageUpdateCommand { Message = update.Message }),
                UpdateType.CallbackQuery => _sender.Send(new OnCallbackQueryUpdateCommand { CallbackQuery = update.CallbackQuery }),
                _ => _sender.Send(new OnUnknownUpdateCommand { Update = update }),
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(exception, cancellationToken);
            }
        }

        public Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _telegramService.StartReceiving(this, cancellationToken);
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
