using Library.Repository.Models;

namespace Library.Models.DTO.Models.Dishes
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DishCategory Category { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public Guid PhotoId { get; set; }

    }
}
