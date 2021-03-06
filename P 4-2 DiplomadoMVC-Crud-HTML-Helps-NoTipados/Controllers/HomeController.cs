﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P_4_2_DiplomadoMVC_Crud_HTML_Helps_NoTipados.Models;

namespace P_4_2_DiplomadoMVC_Crud_HTML_Helps_NoTipados.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MantenimientoProducto mp = new MantenimientoProducto();
            List<Productos> prod = mp.RecuperarTodos();
            return View(prod);
        }
        [HttpPost]
        public ActionResult Index(FormCollection coleccion)
        {
            MantenimientoProducto mp = new MantenimientoProducto();
            Productos prod = mp.Recuperar(int.Parse(coleccion["id"].ToString()));
            if (prod != null)
                return View("ModificacionProducto", prod);
            else
                return View("ProductoNoExistente");
        }
        public ActionResult ModificacionProducto(Productos prod)
        {
            return View(prod);
        }
        [HttpPost]
        public ActionResult ModificacionProducto(FormCollection coleccion)
        {
            MantenimientoProducto mp = new MantenimientoProducto();
            Productos prod = new Productos
            {
                Id = int.Parse(coleccion["Id"].ToString()),
                Descripcion = coleccion["Descripcion"].ToString(),
                Tipo = coleccion["Tipo"].ToString(),
                Precio = float.Parse(coleccion["Precio"].ToString())
            };
            mp.Modificar(prod);
            return RedirectToAction("Index");
        }
        public ActionResult Grabar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Grabar(FormCollection coleccion)
        {
            MantenimientoProducto mp = new MantenimientoProducto();
            Productos prod = new Productos
            {
                //Id = int.Parse(coleccion["Id"].ToString()),
                Descripcion = coleccion["Descripcion"].ToString(),
                Tipo = coleccion["Tipo"].ToString(),
                Precio = float.Parse(coleccion["Precio"].ToString())
            };
            mp.Agregar(prod);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}