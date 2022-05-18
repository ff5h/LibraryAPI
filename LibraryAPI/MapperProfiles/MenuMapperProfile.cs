using AutoMapper;
using Library.Models.DTO.Models.Dishes;
using Library.Models.DTO.Models.Files;
using Library.Models.DTO.Requests;
using Library.Repository.Models;
using LibraryAPI.Commands.Menu;

namespace LibraryAPI.MapperProfiles
{
    public class MenuMapperProfile : Profile
    {
        public MenuMapperProfile()
        {
            CreateMap<Dish, DishDTO>();
            CreateMap<DishCategory, DishCategoryDTO>();
            CreateMap<AddDishRequestDTO, AddDishCommand>();
            CreateMap<AddCategoryRequestDTO, AddCategoryCommand>();
            CreateMap<DeleteDishRequestDTO, DeleteDishCommand>();
            CreateMap<DeleteCategoryRequestDTO, DeleteCategoryCommand>();
            CreateMap<Attachment, FileDTO>();
        }
    }
}
