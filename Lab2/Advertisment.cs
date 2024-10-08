namespace Lab2
{
    public class Advertisment
    {
        public int SellerID { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int Price { get; set; }
    }

    public class Sellers
    {
        public int SellerID { get; set; }
        public string? SellerName { get; set; }
    }

    public class Categories
    {
        public int CategoriesID { get; set; }
        public string? Description { get; set; }
    }
}
