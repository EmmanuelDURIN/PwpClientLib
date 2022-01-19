using Microsoft.VisualStudio.TestTools.UnitTesting;
using PwpClientLib.DemandeDossierLogement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace PwpClientLib.Test.DemandeDossierLogement
{
  [TestClass]
  public class TestClientDemandeDossierLogement
  {
    [TestMethod]
    public void TestCreerRequeteAjoutJustificatif()
    {
      // Arrange
      // Act 
      string idTransaction = "1234";
      RequeteAjoutJustificatif requeteAjoutJustificatif = CreerRequeteAjoutJustificatif(idTransaction);

      // Assert
      Assert.IsNotNull(requeteAjoutJustificatif);
      List<Fichier> fichiers = requeteAjoutJustificatif.Fichiers;
      Assert.IsNotNull(fichiers);
      Assert.IsTrue(fichiers.Count > 0);
      Fichier fichier = fichiers[0];
      Assert.IsNotNull(fichier);

      Assert.IsNotNull(fichier.NomFichier);
      Assert.IsNotNull(fichier.Content);
      Assert.IsNotNull(fichier.Hash);
    }
    [TestMethod]
    public void TestAjouterJustificatif()
    {
      // Arrange
      string idTransaction = "1234";
      HttpClient httpClient = new HttpClient
      { BaseAddress = new Uri("https://api.preprod.gip-sne.fr/partners/ajouterPieces") };
      var clientDemandeDossierLogement = new ClientDemandeDossierLogement(httpClient);

      RequeteAjoutJustificatif requeteAjoutJustificatif = CreerRequeteAjoutJustificatif(idTransaction);
      // Act 
      ReponseAjoutJustificatif reponseAjoutJustificatif;
      reponseAjoutJustificatif = clientDemandeDossierLogement.AjouterJustificatif(requeteAjoutJustificatif).Result;

      // Assert
      Assert.IsNotNull(reponseAjoutJustificatif);
      Assert.AreEqual("success", reponseAjoutJustificatif.Status);
    }

    private static RequeteAjoutJustificatif CreerRequeteAjoutJustificatif(string idTransaction)
    {
      Fichier fichier = new Fichier();
      fichier.SetContenuFichier(Path.Combine("DemandeDossierLogement", "20220117ParisBeauvais.pdf"));
      var requeteAjoutJustificatif = new RequeteAjoutJustificatif
      {
        Utilisateur = new Utilisateur
        {
          Email = "Emmanuel.Durin@gmail2.com",
          Nom = "Durin",
          Prenom = "Emmanuel",
        },
        Guichet = new Guichet
        {
          CodeGuichet = "1234",
          CodeSIREN = "1234",
          CodesTerritoires = "12 34"
        },
        Fichiers = new List<Fichier>
        {
          fichier
        },
        IdTransaction = idTransaction,
      };
      return requeteAjoutJustificatif;
    }
    // Inspiration pour faire un test qui envoie un fichier de taille normale
    // et un fichier trop gros de +20Mo
    [DataTestMethod]
    [DataRow("a", "b")]
    [DataRow(" ", "a")]
    public void TestMethod1(string value1, string value2)
    {
      Assert.AreEqual(value1 + value2, string.Concat(value1, value2));
    }
  }
}
