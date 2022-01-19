using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PwpClientLib.DemandeDossierLogement
{
  public class ClientDemandeDossierLogement
  {
    private HttpClient client;
    public ClientDemandeDossierLogement(HttpClient client)
    {
      this.client = client;
    }
    public async Task<ReponseAjoutJustificatif> AjouterJustificatif( RequeteAjoutJustificatif requeteAjoutJustificatif)
    {
      string json = JsonConvert.SerializeObject(requeteAjoutJustificatif);
      // C'est le corps de la requête avec son type Mime
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
      HttpResponseMessage resp = await client.PostAsync("api/courses", stringContent);
      resp.EnsureSuccessStatusCode();
      string content = await resp.Content.ReadAsStringAsync();
      var reponseAjoutJustificatif =
        JsonConvert.DeserializeObject<ReponseAjoutJustificatif>(content);
      return reponseAjoutJustificatif;
    }
  }
}
