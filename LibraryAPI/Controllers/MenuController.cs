using AutoMapper;
using Library.Models.DTO.Models.Dishes;
using Library.Models.DTO.Requests;
using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Menu;
using LibraryAPI.Queries.Menu;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public MenuController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("GetDishes")]
        public async Task<IEnumerable<DishDTO>> GetDishes()
        {
            var query = new GetDishesQuery();
            var result = await _sender.Send(query);
            return result;
        }

        [HttpGet("GetCategories")]
        public async Task<IEnumerable<DishCategoryDTO>> GetCategories()
        {
            var query = new GetCategoriesQuery();
            var result = await _sender.Send(query);
            return result;
        }

        [HttpPost("AddDish")]
        public async Task<AddDishResponseDTO> PostDish(AddDishRequestDTO requestDTO)
        {
            var command = _mapper.Map<AddDishRequestDTO, AddDishCommand>(requestDTO);
            var result = await _sender.Send(command);
            return result;
        }

        [HttpPost("AddCategory")]
        public async Task<AddCategoryResponseDTO> PostCategory(AddCategoryRequestDTO requestDTO)
        {
            var command = _mapper.Map<AddCategoryRequestDTO, AddCategoryCommand>(requestDTO);
            var result = await _sender.Send(command);
            return result;
        }

        [HttpDelete("DeleteDish")]
        public async Task<DeleteDishResponseDTO> DeleteDish(DeleteDishRequestDTO requestDTO)
        {
            var command = _mapper.Map<DeleteDishRequestDTO, DeleteDishCommand>(requestDTO);
            var result = await _sender.Send(command);
            return result;
        }

        [HttpDelete("DeleteCategory")]
        public async Task<DeleteCategoryResponseDTO> PostCategory(DeleteCategoryRequestDTO requestDTO)
        {
            var command = _mapper.Map<DeleteCategoryRequestDTO, DeleteCategoryCommand>(requestDTO);
            var result = await _sender.Send(command);
            return result;
        }
    }
}
