namespace Pharoahs_Library.Models
{
    public class OrderItems
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public decimal BookPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
