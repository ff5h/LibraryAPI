﻿using Library.MenuBot.Commands.Actions.Messages;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class CreateCardActionCommandHandler : IRequestHandler<CreateCardActionCommand, bool> //add implementation
    {
        private readonly ITelegramBotClient _botClient;

        public CreateCardActionCommandHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task<bool> Handle(CreateCardActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: request.Message.MessageId);

            await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                  text: "Створити:");
            return true;
        }
    }
}
