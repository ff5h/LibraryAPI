using AutoMapper;
using Library.Models.DTO.Models.Clients;
using Library.Models.DTO.Requests;
using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Clients;
using LibraryAPI.Queries.Clients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost("AddClient")]
        public async Task<AddClientResponseDTO> PostClient(AddClientRequestDTO requestDTO)
        {
            var command = _mapper.Map<AddClientRequestDTO, AddClientCommand>(requestDTO);
            var result = await _sender.Send(command);
            return result;
        }

        [HttpDelete("DeleteClient")]
        public async Task<DeleteClientResponseDTO> DeleteClient(DeleteClientRequestDTO requestDTO)
        {
            var command = _mapper.Map<DeleteClientRequestDTO, DeleteClientCommand>(requestDTO); ;
            var result = await _sender.Send(command);
            return result;
        }
    }
}