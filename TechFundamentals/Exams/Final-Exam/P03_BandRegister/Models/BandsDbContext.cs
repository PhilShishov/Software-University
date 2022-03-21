
namespace BandRegister.Models
{
    using Microsoft.EntityFrameworkCore;

    public class BandsDbContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        public const string ConnectionString = @"Server=.\SQL2019;Database=BandDbContext;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
