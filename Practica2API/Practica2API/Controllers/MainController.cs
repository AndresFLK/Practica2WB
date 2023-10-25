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


        [HttpGet]
        [Route("ConsultarVendedor")]
        public List<System.Web.Mvc.SelectListItem> ConsultarVendedor()
        {
            using (var context = new Practica2Entities1())
            {

                var datos = (from x in context.Vendedores
                             select x).ToList();

                var res = new List<System.Web.Mvc.SelectListItem>();
                foreach (var item in datos)
                {
                    res.Add(new System.Web.Mvc.SelectListItem { Value = item.IdVendedor.ToString(), Text = item.Nombre });
                }

                return res;
            }
        }


        [HttpGet]
        [Route("ConsultarVehiculo")]
        public List<Vehiculos> ConsultarVehiculo()
        {
            try
            {
                using (var context = new Practica2Entities1())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.Vehiculos
                                 select x).ToList();

                    return datos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("DatosConsulta")]
        public List<ConsultaEntitie> DatosConsulta()
        {
            try
            {
                using (var context = new Practica2Entities1())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from vd in context.Vendedores
                                 join vh in context.Vehiculos
                                 on vd.IdVendedor equals vh.IdVendedor
                                 select new ConsultaEntitie{ 
                                     Cedula = vd.Cedula, 
                                     Nombre = vd.Nombre,
                                     Marca = vh.Marca,
                                     Modelo = vh.Modelo,
                                     Precio = vh.Precio}).ToList();

                    return datos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
