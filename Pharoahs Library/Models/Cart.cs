namespace Pharoahs_Library.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int UserID { get; set;}
        public decimal BookPrice { get; set;}
        public decimal Discount { get; set;}
        public int BookID { get; set;}
        public decimal TotalPrice { get; set;}

    }
}
