using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions<FootballBettingContext> options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

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
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingEntityPlayerStatistic(modelBuilder);
            OnModelCreatingEntityGame(modelBuilder);
            OnModelCreatingEntityTeam(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void OnModelCreatingEntityTeam(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Team>(entity =>
                {
                    entity
                        .HasOne(c => c.PrimaryKitColor)
                        .WithMany(x => x.PrimaryKitTeams)
                        .HasForeignKey(x => x.PrimaryKitColorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity
                        .HasOne(x => x.SecondaryKitColor)
                        .WithMany(x => x.SecondaryKitTeams)
                        .HasForeignKey(x => x.SecondaryKitColorId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }

        private void OnModelCreatingEntityGame(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>(entity =>
                {
                    entity
                        .HasOne(h => h.HomeTeam)
                        .WithMany(h => h.HomeGames)
                        .HasForeignKey(h => h.HomeTeamId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity
                        .HasOne(a => a.AwayTeam)
                        .WithMany(a => a.AwayGames)
                        .HasForeignKey(a => a.AwayTeamId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
        }

        public void OnModelCreatingEntityPlayerStatistic(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity
                    .HasKey(k => new { k.PlayerId, k.GameId });

                entity
                    .HasOne(x => x.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(p => p.PlayerId);

                entity
                    .HasOne(x => x.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(g => g.GameId);
            });
        }
    }
}