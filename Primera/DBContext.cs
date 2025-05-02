using Primera.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Match> Matches { get; set; }

        public IQueryable<Team> GetTeamsFromCity(string city)
        {
            return FromExpression(() => GetTeamsFromCity(city));
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();


            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => GetTeamsFromCity(default!));

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany(m => m.Matches1)
                .HasForeignKey(m => m.Team1Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany(m => m.Matches2)
                .HasForeignKey(m => m.Team2Id)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
