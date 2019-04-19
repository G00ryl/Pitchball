using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Extensions;
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
            #endregion

            //#region PitchImage Data
            //modelBuilder.Entity<PitchImage>()
            //    .HasData(
            //    new
            //    {
            //        Id = 1,
            //        PitchRef = 1,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch01),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 2,
            //        PitchRef = 2,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch02),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 3,
            //        PitchRef = 3,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch03),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 4,
            //        PitchRef = 4,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch04),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 5,
            //        PitchRef = 5,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch05),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 6,
            //        PitchRef = 6,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch06),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 7,
            //        PitchRef = 7,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch07),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 8,
            //        PitchRef = 8,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch08),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 9,
            //        PitchRef = 9,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch09),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 10,
            //        PitchRef = 10,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch10),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 11,
            //        PitchRef = 11,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch11),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 12,
            //        PitchRef = 12,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch12),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 13,
            //        PitchRef = 13,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch13),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 14,
            //        PitchRef = 14,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch14),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 15,
            //        PitchRef = 15,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch15),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 16,
            //        PitchRef = 16,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch16),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 17,
            //        PitchRef = 17,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch17),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 18,
            //        PitchRef = 18,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch18),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 19,
            //        PitchRef = 19,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch19),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 20,
            //        PitchRef = 20,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch20),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 21,
            //        PitchRef = 21,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch21),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 22,
            //        PitchRef = 22,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch22),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 23,
            //        PitchRef = 23,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch23),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 24,
            //        PitchRef = 24,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch24),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 25,
            //        PitchRef = 25,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch25),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    },
            //    new
            //    {
            //        Id = 26,
            //        PitchRef = 26,
            //        ImageContent = Convert.FromBase64String(PitchImagesRoot.Pitch26),
            //        ImageType = "jpg",
            //        CreatedAt = DateTime.UtcNow,
            //        UpdatedAt = DateTime.UtcNow
            //    });
            //#endregion
        }
    }
}
