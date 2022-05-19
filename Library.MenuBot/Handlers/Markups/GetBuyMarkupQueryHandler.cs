using Library.MenuBot.Queries.Markups;
using Library.Shared.Implementations;
using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetBuyMarkupQueryHandler : IRequestHandler<GetBuyMarkupQuery, InlineReplyMarkup>
    {
        public async Task<InlineReplyMarkup> Handle(GetBuyMarkupQuery request, CancellationToken cancellationToken)
        {
            var countControls = new Dictionary<string, string>();
            if (request.Count > 0)
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

            var buttons = new Dictionary<string, string>[]
            {
                countControls,

                new Dictionary<string, string>
                {
                    { "Підтвердити", $"Confirm {request.DishId} {request.Count}" },
                    { "Відмінити", "Cancel" },
                },
            };
            var markup = new InlineReplyMarkup(buttons);
            return markup;
        }
    }
}
