using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using Pitchball.Domain.Models.Base;
using Pitchball.Infrastructure.Extensions;
using System.Linq;

namespace Pitchball.Infrastructure.Data
{
    public class PitchContext : DbContext
    {
        public PitchContext(DbContextOptions<PitchContext> options) : base(options)
        {
        }

        public DbSet<AccountImage> AccountImages { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Pitch> Pitches { get; set; }
        public DbSet<PitchImage> PitchImages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TeamImage> TeamImages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

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

            modelBuilder.Entity<Account>()
                .HasMany(x => x.Messages)
                .WithOne(y => y.Creator)
                .IsRequired(false);

            modelBuilder.Entity<Admin>()
                .HasData(CreateDefaultAdmin());

            #endregion Accounts

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

            #endregion Team

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
            #endregion Pitch

            modelBuilder.Entity<Message>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<ContactMessage>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Captain>()
                .HasMany(x => x.Reservations);

            #region Reservation
            modelBuilder.Entity<Reservation>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Reservation>()
               .HasOne(x => x.Captain)
               .WithMany(y => y.Reservations)
               .IsRequired(false);
            #endregion

        }

        private Admin CreateDefaultAdmin()
        {
            var _passwordManager = new PasswordManager();
            _passwordManager.CalculatePasswordHash("@dmin68$%", out var passwordHash, out var passwordSalt);
            var id = 1;

            return new Admin(id, "Jan", "Nowak", "Admin", "admin@callme.com", passwordSalt, passwordHash);
        }
    }
}