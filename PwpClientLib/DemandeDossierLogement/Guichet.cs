using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwpClientLib.DemandeDossierLogement
{
  public class Guichet
  {
    [Required]
    [StringLength(5)]
    public string CodeGuichet { get; set; }
    [Required]
    public string CodeSIREN { get; set; }
    [Required]
    public string CodesTerritoires { get; set; }
  }
}
