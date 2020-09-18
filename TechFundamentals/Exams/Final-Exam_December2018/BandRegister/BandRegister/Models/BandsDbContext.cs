using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandRegister.Models
{
    public class BandsDbContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        public const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=BandDbContext;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
