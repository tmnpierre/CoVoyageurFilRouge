using System.ComponentModel.DataAnnotations;

namespace CoVoyageur.API.DTOs
{
    public class RideDTO
    {
        public int ID { get; set; }

        [Display(Name = "Identifiant du conducteur")]
        [Required(ErrorMessage = "L'identifiant du conducteur est requis")]
        public int ID_Driver { get; set; }

        [Display(Name = "Date et heure")]
        [Required(ErrorMessage = "La date et l'heure sont requises")]
        public DateTime DateHour { get; set; }

        [Display(Name = "Départ")]
        [Required(ErrorMessage = "Le lieu de départ est requis")]
        public string? Departure { get; set; }

        [Display(Name = "Arrivée")]
        [Required(ErrorMessage = "Le lieu d'arrivée est requis")]
        public string? Arrival { get; set; }

        [Display(Name = "Nombre de places")]
        [Required(ErrorMessage = "Le nombre de places est requis")]
        [Range(1, int.MaxValue, ErrorMessage = "Le nombre de places doit être au moins 1")]
        public int NbPlaces { get; set; }

        [Display(Name = "Prix")]
        [Required(ErrorMessage = "Le prix est requis")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
        public decimal Price { get; set; }
    }
}
