namespace Pharoahs_Library.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int UserID { get; set; }
        public string OrderStatus { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
