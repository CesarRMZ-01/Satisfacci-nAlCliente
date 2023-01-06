using Cliente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Services
{
    public class ClienteService
    {
        HttpClient cliente = new HttpClient();

        public ClienteService()
        {
            cliente.BaseAddress = new Uri("https://0c79-2806-108e-21-1a8b-899-9c19-ccc1-7508.ngrok.io/votacion/");
        }

        public async Task VotarPost(Votos voto)
        {
            var json = JsonConvert.SerializeObject(voto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("responder", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
