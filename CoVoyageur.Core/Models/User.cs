using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageur.Core.Models
{
    [Table("User")]
    public class User
    {
        [Column("Id")]
        public int ID { get; set; }

        [Column("LastName")]
        public string? LastName { get; set; }

        [Column("Firstname")]
        public string? FirstName { get; set; }

        [Column("BirthDate")]
        public DateTime? BirthDate { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Password")]
        public string? Password { get; set; }

        [Column("InscriptionDate")]
        public DateTime InscriptionDate { get; set; } = DateTime.Now;

        [Column("DrivingLicence")]
        public bool DrivingLicense { get; set; } = false;

        [Column("IsAdmin")]
        public bool IsAdmin { get; set; } = false;
        public List<Ride>? Rides { get; set; }
        public List<Feedback>? FeedbacksDrivers { get; set; }
        public List<Feedback>? FeedbacksPassengers { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
