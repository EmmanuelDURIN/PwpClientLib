using System.ComponentModel.DataAnnotations;

namespace PwpClientLib.DemandeDossierLogement
{
  public class Utilisateur
  {
    [Required]
    public string Nom { get; set; }
    public string Prenom { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
  }
}
