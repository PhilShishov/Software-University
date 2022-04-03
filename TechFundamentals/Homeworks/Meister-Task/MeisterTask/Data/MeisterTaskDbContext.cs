
namespace MeisterTask.Data
{
    using Microsoft.EntityFrameworkCore;
    using MeisterTask.Models;

    public class MeisterTaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQL2019;Database=MeisterTaskDb;Integrated Security = true;");
        }
    }
}
