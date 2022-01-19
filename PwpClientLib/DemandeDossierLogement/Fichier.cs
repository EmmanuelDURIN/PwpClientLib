using PwpClientLib.Hash;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace PwpClientLib.DemandeDossierLogement
{
  public class Fichier
  {
    public string IdTransaction { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nomFichierComplet">Chemin complet jusqu'au fichier</param>
    public void SetContenuFichier (string nomFichierComplet)
    {
      NomFichier = Path.GetFileName(nomFichierComplet);
      byte[] content = File.ReadAllBytes(nomFichierComplet);
      Hash = HashMaker.MakeSha1(content);
      //, string contenuFichier
      Content = Convert.ToBase64String(content);
    }
    // Base 64
    [Required]
    public string Content { get; private set; }
    [Required]
    public string Hash { get; private set; }
    [Required]
    public string NomFichier { get; private set; }
  }
}
