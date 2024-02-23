using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageur.Core.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Column("Id")]
        public int ID { get; set; }

        [Column("Id_Driver")]
        public int ID_Driver { get; set; }

        [Column("Id_Passenger")]
        public int ID_Passenger { get; set; }

        [Column("Rating")]
        public int Rating { get; set; }

        [Column("Comment")]
        public string? Comment { get; set; }

        [Column("DateHour")]
        public DateTime DateHour { get; set; }
        public User? Author { get; set; }
        public User? Driver { get; set; }
    }
}
