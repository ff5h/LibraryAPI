using Library.LibrarianBot.Commands.Messages;
using Library.Repository.Interfaces;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Library.LibrarianBot.HostedServices
{
    public class ProcessingService : IHostedService, IUpdateHandler
    {
        private readonly IAppDBContext _ctx;
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;

        public ProcessingService(IAppDBContext ctx, ITelegramBotClient botClient, ISender sender)
        {
            _ctx = ctx;
            _botClient = botClient;
            _sender = sender;
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => _sender.Send(new OnMessageReceivedCommand { Message = update.Message }),
                //UpdateType.EditedMessage => BotOnMessageReceived(botClient, update.EditedMessage!),
                //UpdateType.CallbackQuery => BotOnCallbackQueryReceived(botClient, update.CallbackQuery!),
                //UpdateType.InlineQuery => BotOnInlineQueryReceived(botClient, update.InlineQuery!),
                //UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(botClient, update.ChosenInlineResult!),
                //_ => UnknownUpdateHandlerAsync(botClient, update)
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
                ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
                _botClient.StartReceiving(this, receiverOptions, cancellationToken);
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
