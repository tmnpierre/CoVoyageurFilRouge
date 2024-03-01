using Microsoft.EntityFrameworkCore;
using CoVoyageur.Core.Models;

namespace CoVoyageur.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.ID);
            modelBuilder.Entity<Ride>().HasKey(r => r.ID);
            modelBuilder.Entity<Feedback>().HasKey(f => f.ID);
            modelBuilder.Entity<Reservation>().HasKey(r => r.ID);

            modelBuilder.Entity<Reservation>()
                .HasOne<Ride>()
                .WithMany()
                .HasForeignKey(r => r.ID_Ride);

            modelBuilder.Entity<Reservation>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.ID_Passenger);

            modelBuilder.Entity<Feedback>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.ID_Driver)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.ID_Passenger)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Author)
                .WithMany()
                .HasForeignKey(f => f.ID_Passenger)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Driver)
                .WithMany()
                .HasForeignKey(f => f.ID_Driver)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
