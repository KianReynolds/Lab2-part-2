namespace AdvertismentApi.Models
{
    public class Advertisment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DatePosted { get; set; }
        public int SellerId {  get; set; }
        public int CategoryId {  get; set; }
        public Seller Seller { get; set; }
        public Category Category { get; set; }

    }

    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
