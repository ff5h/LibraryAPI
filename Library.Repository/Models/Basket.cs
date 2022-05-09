namespace Library.Repository.Models
{
    public class Basket
    {
        public long UserId { get; set; }
        public List<Dish> BasketDishes { get; set; }
    }
}
