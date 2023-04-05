namespace Pharoahs_Library.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<Users> listUsers { get; set; }
        public Users user { get; set; }
        public List<Books> listBooks { get; set; }
        public Books book { get; set; }
        public List<Cart> cart { get; set; }
        //public Cart cart { get; set; }
        public List<Favourite> favourites { get; set; }
        public Favourite favourite { get; set; }
        public List<Order> order { get; set; }
        public Order Order { get; set; }
        public List<OrderItems> orderItems { get; set; }
        public OrderItems orderItem { get; set; }

    }
}
