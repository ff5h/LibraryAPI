using AutoMapper;
using Library.Models.DTO.Models.Client;
using LibraryAPI.Data;
using LibraryAPI.Data.Models;
using LibraryAPI.Queries.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Handlers.Clients
{
    //Какой запрос я обрабатываю и что я должен вернуть
    public class GetClientQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<ClientDTO>>
    {
        private readonly AppDBContext _ctx;
        private readonly IMapper _mapper;

        public GetClientQueryHandler(AppDBContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDTO>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var clientsArray = await _ctx.Clients.ToArrayAsync();
            var result = _mapper.Map<IEnumerable<Client>, ClientDTO[]>(clientsArray);
            return result;
        }
    }
}
