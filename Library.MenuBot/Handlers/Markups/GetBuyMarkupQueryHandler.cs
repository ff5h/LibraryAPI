using Library.MenuBot.Queries.Markups;
using Library.Repository.Interfaces;
using Library.Shared.Implementations;
using Library.Shared.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetBuyMarkupQueryHandler : IRequestHandler<GetBuyMarkupQuery, InlineReplyMarkup>
    {
        private readonly IAppDBContext _ctx;

        public GetBuyMarkupQueryHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<InlineReplyMarkup> Handle(GetBuyMarkupQuery request, CancellationToken cancellationToken)
        {
            var countControls = new Dictionary<string, string>();
            if (request.Count > 1)
            {
                countControls.Add("-", $"Buy {request.DishId} {request.Count - 1} Navigation");
            }
            else
            {
                countControls.Add($" ", "#");
            }
            countControls.Add($"{request.Count}", "#");
            if (request.Count < 8)
            {
                countControls.Add("+", $"Buy {request.DishId} {request.Count + 1} Navigation");

            }
            else
            {
                countControls.Add($" ", "#");
            }

            int category = (await _ctx.Dishes.FirstOrDefaultAsync(d => d.Id == request.DishId)).CategoryId;

            var buttons = new Dictionary<string, string>[]
            {
                countControls,

                new Dictionary<string, string>
                {
                    { "Підтвердити", $"Confirm {request.DishId} {request.Count}" },
                    { "Відмінити", $"Menu {category} 0 Cancel" },
                },
            };
            var markup = new InlineReplyMarkup(buttons);
            return markup;
        }
    }
}
