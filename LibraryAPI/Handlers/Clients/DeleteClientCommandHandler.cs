using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Library.Repository.Interfaces;

namespace LibraryAPI.Handlers.Clients
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, DeleteClientResponseDTO>
    {
        private readonly IAppDBContext _ctx;

        public DeleteClientCommandHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<DeleteClientResponseDTO> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var clientsQuery = _ctx.Clients.AsQueryable();
            clientsQuery = clientsQuery.Where(c => c.Id == request.Id);
            var client = await clientsQuery.FirstOrDefaultAsync();
            _ctx.Clients.Remove(client);
            await _ctx.SaveChangesAsync();
            var result = new DeleteClientResponseDTO()
            {
                FirstName = client.FirstName,
                MiddleName = client.MiddleName,
                LastName = client.LastName,
            };
            return result;
        }
    }
}
