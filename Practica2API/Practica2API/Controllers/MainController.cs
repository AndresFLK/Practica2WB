using Practica2API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practica2API.Controllers
{
    public class MainController : ApiController
    {
        [HttpPost]
        [Route("RegistrarVendedor")]
        public string RegistrarVendedor(VendedorEnt entidad)
        {
            try
            {

                using (var context = new Practica2Entities1())
                {
                    Vendedores vendedor = new Vendedores();
                    vendedor.Cedula = entidad.Cedula;
                    vendedor.Nombre = entidad.Nombre;
                    vendedor.Correo = entidad.Correo;
                    vendedor.Estado = true;

                    context.Vendedores.Add(vendedor);
                    context.SaveChanges();

                    
                    return "Ok";
                }
            }
            catch
            {
                return string.Empty;
            }

        }



        [HttpPost]
        [Route("RegistrarVehiculo")]
        public string RegistrarVehiculo(VehiculoEnt entidad)
        {
            try
            {

                using (var context = new Practica2Entities1())
                {
                    Vehiculos vehiculo = new Vehiculos();
                    vehiculo.Marca = entidad.Marca;
                    vehiculo.Modelo = entidad.Modelo;
                    vehiculo.Color = entidad.Color;
                    vehiculo.Precio = entidad.Precio;
                    vehiculo.IdVendedor = entidad.IdVendedor;

                    context.Vehiculos.Add(vehiculo);
                    context.SaveChanges();


                    return "Ok";
                }
            }
            catch
            {
                return string.Empty;
            }

        }
    }
}
