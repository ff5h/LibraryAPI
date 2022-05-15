namespace Library.Repository.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public Guid PhotoId { get; set; }
        public DishCategory Category { get; set; }
        public Attachment Photo { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
