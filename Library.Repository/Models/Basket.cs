namespace Library.Repository.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
