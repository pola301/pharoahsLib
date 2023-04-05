namespace Pharoahs_Library.Models
{
    public class Favourite
    {
        public int FavID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public decimal BookPrice { get; set; }
        public string ImgURL { get; set; }

    }
}
