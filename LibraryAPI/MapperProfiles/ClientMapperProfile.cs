using AutoMapper;
using Library.Models.DTO.Models.Client;
using LibraryAPI.Data.Models;

namespace LibraryAPI.MapperProfiles
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Client, ClientDTO>();
        }
    }
}
