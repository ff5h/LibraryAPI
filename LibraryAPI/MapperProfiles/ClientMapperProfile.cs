using AutoMapper;
using Library.Models.DTO.Models.Client;
using Library.Models.DTO.Requests;
using LibraryAPI.Commands.Clients;
using LibraryAPI.Data.Models;

namespace LibraryAPI.MapperProfiles
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<AddClientRequestDTO, AddClientCommand>();
        }
    }
}
