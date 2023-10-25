using Practica2WB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica2WB.Models;
using System.Reflection;

namespace Practica2WB.Controllers
{
    public class HomeController : Controller
    {
        VendedorModel vendedorModel = new VendedorModel();
        VehiculoModel vehiculoModel = new VehiculoModel();
        ConsultaModel consultaModel = new ConsultaModel();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }





        [HttpGet]
        public ActionResult RegistrarVendedor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarVendedor(VendedorEnt entidad)
        {
            var res = vendedorModel.RegistrarVendedor(entidad);
            if (res == "Ok")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MensajeUsuario = "La cedula introducida ya esta registrada";
                return View();
            }
        }






        [HttpGet]
        public ActionResult RegistrarVehiculo()
        {
            ViewBag.Vendedores = vendedorModel.ConsultarVendedor();
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarVehiculo(VehiculoEnt entidad)
        {
           
            var res = vehiculoModel.RegistrarVehiculo(entidad);
            if (res == "Ok")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Vendedores = vendedorModel.ConsultarVendedor();
                return View();
            }
            
        }







        [HttpGet]
        public ActionResult ConsultaVehiculo(ConsultaEnt entidad)
        {
            var datos = consultaModel.DatosConsulta();
            return View(datos);
        }

        
    }
}