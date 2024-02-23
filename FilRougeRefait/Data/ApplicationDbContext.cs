using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.DTOs;

namespace CoVoyageur.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserDTO> UserDTO { get; set; } = default!;

        public DbSet<RideDTO> RideDTO { get; set; } = default!;

        public DbSet<FeedbackDTO> FeedbackDTO { get; set; } = default!;

        public DbSet<ReservationDTO> ReservationDTO { get; set; } = default!;
    }
}
