using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageur.Core.Models
{
    [Table("Ride")]
    public class Ride
    {
        [Column("Id")]
        public int ID { get; set; }

        [Column("Id_Rider")]
        public int ID_Driver { get; set; }

        [Column("DateHour")]
        public DateTime DateHour { get; set; }

        [Column("Departure")]
        public string? Departure { get; set; }

        [Column("Arrival")]
        public string? Arrival { get; set; }

        [Column("NbPlaces")]
        public int NbPlaces { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }
        public User? Driver { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
