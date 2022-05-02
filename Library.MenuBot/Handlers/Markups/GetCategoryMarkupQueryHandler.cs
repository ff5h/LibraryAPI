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

        public Task<IReplyMarkup> Handle(GetCategoryMarkupQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
