namespace Library.Models.DTO.Requests
{
    public class AddDishRequestDTO
    {
        public string Name { get; init; }
        public int CategoryId { get; init; }
        public double Price { get; init; }
        public int Weight { get; init; }
        public Guid PhotoId { get; set; }

    }
}
