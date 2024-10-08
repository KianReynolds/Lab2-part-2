namespace Lab2
{
    using Microsoft.EntityFrameworkCore;
    public class AdvertismentDb : DbContext
    {
        public AdvertismentDb(DbContextOptions<AdvertismentDb> options) : base(options) { }

        public DbSet<Advertisment> Advertisments => Set<Advertisment>();
    }
}
