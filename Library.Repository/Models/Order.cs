namespace Library.Repository.Models
{
    public class Order
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int DishId { get; set; }
        public int BasketId { get; set; }
        public int DishCount { get; set; }
        public Dish Dish { get; set; }
        public Basket Basket { get; set; }
    }
}
