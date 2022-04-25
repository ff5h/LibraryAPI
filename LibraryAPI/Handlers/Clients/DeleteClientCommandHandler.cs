﻿using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Clients;
using LibraryAPI.Data;
using LibraryAPI.Data.Models;
using MediatR;

namespace LibraryAPI.Handlers.Clients
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, DeleteClientResponseDTO>
    {
        private readonly AppDBContext _ctx;

        public DeleteClientCommandHandler(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<DeleteClientResponseDTO> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client()
            {
                Id = request.Id,
            };

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