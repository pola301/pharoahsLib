namespace Pharoahs_Library.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Fund { get; set; }
        public string  Type { get; set;}
        public int Status { get; set; }
        public DateTime Createdon { get; set; }
    }
}
