using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Clients;
using LibraryAPI.Data;
using LibraryAPI.Data.Models;
using MediatR;

namespace LibraryAPI.Handlers.Clients
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, AddClientResponseDTO>
    {
        private readonly AppDBContext _ctx;

        public AddClientCommandHandler(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<AddClientResponseDTO> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client()
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
            };

            _ctx.Clients.Add(client);
            await _ctx.SaveChangesAsync();
            var result = new AddClientResponseDTO()
            {
                Id = client.Id
            };
            return result;
        }
    }
}
