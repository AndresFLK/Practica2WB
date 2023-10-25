using Practica2WB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Practica2WB.Models
{
    public class ConsultaModel
    {
        public string urlApi = "https://localhost:44359/";
        public List<ConsultaEnt> DatosConsulta()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "DatosConsulta";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<ConsultaEnt>>().Result;
            }
        }
    }
}