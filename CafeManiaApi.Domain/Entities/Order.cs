namespace CafeManiaApi.Domain.Entities
{
    public class Order
    {
        protected Order() { }

        public Order(int id, int userId, DateTime dateOrder, bool finished)
        {
            Id = id;
            UserId = userId;
            DateOrder = dateOrder;
            Finished = finished;
        }
        public Order(int userId, DateTime dateOrder, bool finished, User user)
        {
            UserId = userId;
            DateOrder = dateOrder;
            Finished = finished;
            User = user;
        }

        public Order(int id, int userId, DateTime dateOrder, bool finished, User user, ICollection<ProductOrder> products)
        {
            Id = id;
            UserId = userId;
            DateOrder = dateOrder;
            Finished = finished;
            User = user;
            Products = products;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateOrder { get; set; }
        public bool Finished { get; set; }

        public User User { get; set; }

        public ICollection<ProductOrder> Products { get; set; } = new List<ProductOrder>();
    }
}
