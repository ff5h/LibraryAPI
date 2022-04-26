using AutoMapper;
using Library.Models.DTO.Models.Clients;
using Library.Repository.Models;
using LibraryAPI.Queries.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Library.Repository.Interfaces;

namespace LibraryAPI.Handlers.Clients
{
    //Какой запрос я обрабатываю и что я должен вернуть
    public class GetClientQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<ClientDTO>>
    {
        private readonly IAppDBContext _ctx;
        private readonly IMapper _mapper;

        public GetClientQueryHandler(IAppDBContext ctx, IMapper mapper)
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
