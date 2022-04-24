using AutoMapper;
using Library.Models.DTO.Models.Client;
using LibraryAPI.Queries.Clients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public ClientController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("GetClients")]
        public async Task<IEnumerable<ClientDTO>> GetClients()
        {
            var query = new GetClientsQuery();
            var result = await _sender.Send(query);
            return result;
        }
    }
}
