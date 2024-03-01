using CoVoyageur.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CoVoyageur.API.DTOs

{
    public class ReservationDTO
{
    public int ID { get; set; }

    [Display(Name = "Identifiant du trajet")]
    [Required(ErrorMessage = "L'identifiant du trajet est requis")]
    public int ID_Ride { get; set; }

    [Display(Name = "Identifiant du passager")]
    [Required(ErrorMessage = "L'identifiant du passager est requis")]
    public int ID_Passenger { get; set; }

    [Display(Name = "Statut")]
    [Required(ErrorMessage = "Le statut est requis")]
    public Status? Statuts { get; set; }
}
}
