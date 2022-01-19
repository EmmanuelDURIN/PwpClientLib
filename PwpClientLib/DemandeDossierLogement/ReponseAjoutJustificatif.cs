using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PwpClientLib.DemandeDossierLogement
{
  public class ReponseAjoutJustificatif
  {
    [Required]
    public string IdTransaction { get; set; }
    public string Status { get; set; }
  }
}
