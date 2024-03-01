using CoVoyageur.API.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoVoyageur.API.DTOs
{
    public class UserDTO
    {
        public int ID { get; set; }

        [Display(Name = "Nom de famille")]
        [Required(ErrorMessage = "Nom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
        [RegularExpression(@"^[a-zA-ZàâäéèêëïîôöùûüÿçÀÂÄÉÈÊËÏÎÔÖÙÛÜŸÇ'\- ]+$", ErrorMessage = "Le nom contient des caractères non valides.")]
        public string? LastName { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Prénom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le prénom doit être compris entre 3 et 30 caractères.")]
        [RegularExpression(@"^[a-zA-ZàâäéèêëïîôöùûüÿçÀÂÄÉÈÊËÏÎÔÖÙÛÜŸÇ'\- ]+$", ErrorMessage = "Le prénom contient des caractères non valides.")]
        public string? FirstName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Manquant")]
        [EmailAddress(ErrorMessage = "Email Invalide !")]
        public string? Email { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "Date de naissance Manquante")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Âge")]
        public int? Age => BirthDate.HasValue ? DateTime.Now.Year - BirthDate.Value.Year - (DateTime.Now.DayOfYear < BirthDate.Value.DayOfYear ? 1 : 0) : null;

        [Display(Name = "Date d'inscription")]
        public DateTime InscriptionDate { get; set; } = DateTime.Now;

        [Display(Name = "Permis de conduire")]
        [Required(ErrorMessage = "Renseignement Manquant")]
        public bool DrivingLicense { get; set; } = false;

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Mot de passe Manquant")]
        [PasswordValidator]
        [JsonIgnore]
        public string? Password { get; set; }

        [Display(Name = "Administrateur")]
        public bool IsAdmin { get; set; }
    }
}
