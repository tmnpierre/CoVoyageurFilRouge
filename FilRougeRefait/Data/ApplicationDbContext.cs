using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.DTOs;

namespace CoVoyageur.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<UserDTO> UserDTO { get; set; }
        public DbSet<RideDTO> RideDTO { get; set; }
        public DbSet<FeedbackDTO> FeedbackDTO { get; set; }
        public DbSet<ReservationDTO> ReservationDTO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDTO>().HasKey(u => u.ID);
            modelBuilder.Entity<RideDTO>().HasKey(r => r.ID);
            modelBuilder.Entity<FeedbackDTO>().HasKey(f => f.ID);
            modelBuilder.Entity<ReservationDTO>().HasKey(r => r.ID);

            modelBuilder.Entity<ReservationDTO>()
                .HasOne<RideDTO>()
                .WithMany()
                .HasForeignKey(r => r.ID_Ride);

            modelBuilder.Entity<ReservationDTO>()
                .HasOne<UserDTO>()
                .WithMany()
                .HasForeignKey(r => r.ID_Passenger);

            modelBuilder.Entity<FeedbackDTO>()
                .HasOne<UserDTO>()
                .WithMany()
                .HasForeignKey(f => f.ID_Driver)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FeedbackDTO>()
                .HasOne<UserDTO>()
                .WithMany()
                .HasForeignKey(f => f.ID_Passenger)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
