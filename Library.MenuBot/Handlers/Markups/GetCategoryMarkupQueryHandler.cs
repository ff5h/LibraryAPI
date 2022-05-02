using Library.MenuBot.Common.Utilities;
using Library.MenuBot.Queries.Markups;
using Library.Repository.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetCategoryMarkupQueryHandler : IRequestHandler<GetCategoryMarkupQuery, IReplyMarkup>
    {
        private readonly IAppDBContext _ctx;

        public GetCategoryMarkupQueryHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IReplyMarkup> Handle(GetCategoryMarkupQuery request, CancellationToken cancellationToken)
        {
            var buttons = new[]
                    {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData("Назад", "Previous"),
                            InlineKeyboardButton.WithCallbackData("До меню", "Menu"),
                            InlineKeyboardButton.WithCallbackData("Кошик", "Basket"),
                            InlineKeyboardButton.WithCallbackData("Вперед", "Next"),
                        },
                    };
            InlineKeyboardMarkup markup = new(buttons);
            return markup; //Переделать
        }
    }
}
