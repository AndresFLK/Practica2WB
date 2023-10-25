using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using Practica2WB.Entities;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Practica2WB.Models
{
    public class VehiculoModel
    {
        public string urlApi = "https://localhost:44359/";
        public string RegistrarVehiculo(VehiculoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "/RegistrarVehiculo";
                JsonContent content = JsonContent.Create(entidad);
                var res = client.PostAsync(url, content).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<VehiculoEnt> ConsultarVehiculo()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarVehiculo";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<VehiculoEnt>>().Result;
            }
        }

        
    }
}