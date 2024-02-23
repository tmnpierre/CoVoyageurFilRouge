using System.ComponentModel.DataAnnotations;

namespace CoVoyageur.API.DTOs
{
    public class FeedbackDTO
    {
        public int ID { get; set; }

        [Display(Name = "Identifiant du conducteur")]
        [Required(ErrorMessage = "L'identifiant du conducteur est requis")]
        public int ID_Driver { get; set; }

        [Display(Name = "Identifiant du passager")]
        [Required(ErrorMessage = "L'identifiant du passager est requis")]
        public int ID_Passenger { get; set; }

        [Display(Name = "Évaluation")]
        [Required(ErrorMessage = "L'évaluation est requise")]
        [Range(1, 5, ErrorMessage = "L'évaluation doit être comprise entre 1 et 5")]
        public int Rating { get; set; }

        [Display(Name = "Commentaire")]
        [Required(ErrorMessage = "Veuillez saisir un commentaire")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Le commentaire doit être compris entre 10 et 300 caractères.")]
        public string? Comment { get; set; }

        [Display(Name = "Date et heure")]
        [Required(ErrorMessage = "La date et l'heure sont requises")]
        public DateTime DateHour { get; set; }
    }
}

