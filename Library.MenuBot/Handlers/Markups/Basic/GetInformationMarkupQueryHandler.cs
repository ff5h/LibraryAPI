using Library.MenuBot.Queries.Markups.Basic;
using Library.Shared.Implementations;
using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Handlers.Markups.Basic
{
    public class GetInformationMarkupQueryHandler : IRequestHandler<GetInformationMarkupQuery, IMarkup>
    {
        public async Task<IMarkup> Handle(GetInformationMarkupQuery request, CancellationToken cancellationToken)
        {
            var buttons = new Dictionary<string, string>[]
            {
                new Dictionary<string, string>
                {
                    { "Головна", "Main" },
                },
            };
            var markup = new InlineReplyMarkup(buttons);
            return markup;
        }
    }
}
