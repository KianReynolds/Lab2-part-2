using Microsoft.EntityFrameworkCore;
using AdvertismentApi.Models;
namespace AdvertismentApi.Data
{
   
    public class AdvertismentDb : DbContext
    {
        public AdvertismentDb(DbContextOptions<AdvertismentDb> options) : base(options) { }

        public DbSet<Advertisment> Advertisments => Set<Advertisment>();
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
