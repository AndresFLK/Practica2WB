using Practica2WB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace Practica2WB.Models
{
    public class VendedorModel
    {
        public string urlApi = "https://localhost:44359/";
        public string RegistrarVendedor(VendedorEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "/RegistrarVendedor";
                JsonContent content = JsonContent.Create(entidad);
                var res = client.PostAsync(url, content).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<SelectListItem> ConsultarVendedor()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "/ConsultarVendedor";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }


        public List<VendedorEnt> DatosVendedor()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "DatosVendedor";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<VendedorEnt>>().Result;
            }
        }
    }
}