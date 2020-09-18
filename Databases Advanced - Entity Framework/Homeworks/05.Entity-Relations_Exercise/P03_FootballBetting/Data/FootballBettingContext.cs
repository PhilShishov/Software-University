
namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() { }

        public FootballBettingContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnConfiguringTeam(modelBuilder);

            OnConfiguringTown(modelBuilder);

            OnConfiguringGame(modelBuilder);

            OnConfiguringPlayerStatistic(modelBuilder);
        }

        private void OnConfiguringPlayerStatistic(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<PlayerStatistic>(playerstatistic =>
               {
                   playerstatistic.HasKey(ps => new { ps.PlayerId, ps.GameId });

                   playerstatistic
                       .HasOne(ps => ps.Player)
                       .WithMany(p => p.PlayerStatistics)
                       .HasForeignKey(ps => ps.PlayerId);

                   playerstatistic
                       .HasOne(ps => ps.Game)
                       .WithMany(g => g.PlayerStatistics)
                       .HasForeignKey(ps => ps.GameId);
               });
        }

        private void OnConfiguringGame(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Game>(game =>
               {
                   game.HasKey(g => g.GameId);

                   game
                       .HasOne(g => g.HomeTeam)
                       .WithMany(ht => ht.HomeGames)
                       .HasForeignKey(g => g.HomeTeamId)
                       .OnDelete(DeleteBehavior.Restrict);

                   game
                       .HasOne(g => g.AwayTeam)
                       .WithMany(at => at.AwayGames)
                       .HasForeignKey(g => g.AwayTeamId)
                       .OnDelete(DeleteBehavior.Restrict);
               });
        }

        private void OnConfiguringTown(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Town>(town =>
               {
                   town.HasKey(t => t.TownId);

                   town
                       .HasOne(t => t.Country)
                       .WithMany(c => c.Towns);
               });
        }

        private void OnConfiguringTeam(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Team>(team =>
                {
                    team.HasKey(t => t.TeamId);

                    team
                        .Property(t => t.Initials)
                        .HasColumnType("CHAR(3)")
                        .IsRequired();

                    team
                        .HasOne(t => t.PrimaryKitColor)
                        .WithMany(pc => pc.PrimaryKitTeams)
                        .HasForeignKey(t => t.PrimaryKitColorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    team
                        .HasOne(t => t.SecondaryKitColor)
                        .WithMany(sc => sc.SecondaryKitTeams)
                        .HasForeignKey(t => t.SecondaryKitColorId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
