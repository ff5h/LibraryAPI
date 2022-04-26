using AutoMapper;
using Library.Models.DTO.Models.Clients;
using Library.Models.DTO.Requests;
using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Clients;
using Library.Repository.Models;

namespace LibraryAPI.MapperProfiles
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<AddClientRequestDTO, AddClientCommand>();
            CreateMap<DeleteClientRequestDTO, DeleteClientCommand>();
        }
    }
}
