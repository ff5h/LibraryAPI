using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Clients;
using Library.Repository.Models;
using MediatR;
using Library.Repository.Interfaces;

namespace LibraryAPI.Handlers.Clients
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, AddClientResponseDTO>
    {
        private readonly IAppDBContext _ctx;

        public AddClientCommandHandler(IAppDBContext ctx)
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
