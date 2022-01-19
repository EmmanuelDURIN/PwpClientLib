using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwpClientLib.DemandeDossierLogement
{
  public class RequeteAjoutJustificatif
  {
    [Required]
    public string IdTransaction { get; set; }
    /// <summary>
    /// Numéro unique du dossier sur 18 caractères
    /// </summary>
    [Required]
    [StringLength(18)]
    public string NumUnique { get; set; }
    public Guichet Guichet { get; set; }
    public Utilisateur Utilisateur { get; set; }
    public List<Fichier> Fichiers { get; set; }
  }
}
