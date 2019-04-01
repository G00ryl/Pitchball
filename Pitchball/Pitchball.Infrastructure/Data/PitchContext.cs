using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitchball.Infrastructure.Data
{
    public class PitchContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<TeamImage> TeamImages { get; set; }
        public DbSet<PitchImage> PitchImages { get; set; }
        public DbSet<AccountImage> AccountImages { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<Team> Teams { get; set; }

        public PitchContext(DbContextOptions<PitchContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            #region Accounts
            modelBuilder.Entity<Account>()
                .HasMany(x => x.Comments)
                .WithOne(y => y.Creator)
                .IsRequired(false);

            modelBuilder.Entity<Account>()
                .HasOne(x => x.AccountImage)
                .WithOne(y => y.Account)
                .HasForeignKey<AccountImage>(y => y.AccountRef)
                .IsRequired(false);

            modelBuilder.Entity<Captain>()
                .HasMany(x => x.Reservations)
                .WithOne(y => y.Captain)
                .IsRequired(false);
            #endregion

            #region Team
            modelBuilder.Entity<Team>()
                .HasMany(x => x.Members)
                .WithOne(y => y.Team)
                .IsRequired(false);

            modelBuilder.Entity<Team>()
                .HasOne(x => x.Captain)
                .WithOne(x => x.Team)
                .HasForeignKey<Captain>(y => y.TeamRef);

            modelBuilder.Entity<Team>()
                .HasOne(x => x.TeamImage)
                .WithOne(y => y.Team)
                .HasForeignKey<TeamImage>(y => y.TeamRef)
                .IsRequired(false);
            #endregion

            #region Pitch
            modelBuilder.Entity<Pitch>()
                .HasMany(x => x.Comments)
                .WithOne(y => y.Pitch)
                .IsRequired(false);

            modelBuilder.Entity<Pitch>()
                .HasMany(x => x.Reservations)
                .WithOne(y => y.Pitch)
                .IsRequired(false);

            modelBuilder.Entity<Pitch>()
                .HasOne(x => x.PitchImage)
                .WithOne(y => y.Pitch)
                .HasForeignKey<PitchImage>(y => y.PitchRef)
                .IsRequired(false);

            modelBuilder.Entity<Pitch>()
                .HasData(
                new { Id = 1, Name = "Boisko Orlik Stadion Ludowy", Street = "Kresowa 1", City = "Sosnowiec", IsActive = true, Surface = "Sztuczna trawa", Lighting = "Płatne" },
                new { Id = 2, Name = "Boisko Orlik KKS Czarni Sosnowiec", Street = "Mireckiego 31", City = "Sosnowiec", IsActive = true, Surface = "Sztuczna trawa", Lighting = "Darmowe" },
                new { Id = 3, Name = "Boisko Orlik ZSO nr 12", Street = "Jasieńskiego 2A", City = "Sosnowiec", Surface = "Sztuczna trawa", Lighting = "Darmowe" },
                new { Id = 4, Name = "Boisko VI LO \"Korczak\"", Street = "Czeladzka 43", City = "Sosnowiec", IsActive = true, Surface = "Tartan", Lighting = "Brak" },
                new { Id = 5, Name = "Boisko ZSO nr 5", Street = "Bohaterów Monte Cassino 46", City = "Sosnowiec", IsActive = true, Surface = "Tartan", Lighting = "Brak" },
                new { Id = 6, Name = "Boisko Orlik Gimnazjum nr 9", Street = "Kalagi 9A", City = "Sosnowiec", IsActive = true, Surface = "Sztuczna trawa", Lighting = "Darmowe" },
                new { Id = 7, Name = "Boisko Szkoła Podstawowa nr 4", Street = "Kościelna 9", City = "Sosnowiec", IsActive = true, Surface = "Beton / asfalt", Lighting = "Darmowe" },
                new { Id = 8, Name = "Boisko Orlik ZS nr 2 \"Manhattan\"", Street = "Piłsudskiego 24", City = "Dąbrowa Górnicza ", IsActive = true, Surface = "Sztuczna trawa", Lighting = "Darmowe" }
                );
            #endregion
        }
    }
}
