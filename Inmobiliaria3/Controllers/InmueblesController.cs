using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria3.Controllers
{
    public class InmueblesController : Controller
    {
        // GET: Inmuebles
        public ActionResult Index()
        {
            InmueblesData inmueblesData = new InmueblesData();
            var inmuebles = inmueblesData.obtenerInmuebles();
            return View(inmuebles);
        }

        // GET: Inmuebles
        public ActionResult ListaDisponibles()
        {
            InmueblesData inmueblesData = new InmueblesData();
            var inmuebles = inmueblesData.obtenerInmueblesDisponibles();
            return View(inmuebles);
        }

        // GET: Inmuebles
        public ActionResult ListaInmueblesPropietario(int id)
        {
            InmueblesData inmueblesData = new InmueblesData();
            var inmuebles = inmueblesData.obtenerInmueblesDePropietario(id);
            return View(inmuebles);
        }

        // GET: Inmuebles
        public ActionResult Buscar()
        {

            System.Diagnostics.Debug.WriteLine("USO: " + Request.Form["Uso"]);
            System.Diagnostics.Debug.WriteLine("TIPO: " + Request.Form["Tipo"]);
            System.Diagnostics.Debug.WriteLine("AMBIENTES: " + Int32.Parse(Request.Form["Ambientes"]));
            System.Diagnostics.Debug.WriteLine("PRECIO: " + Double.Parse(Request.Form["Precio"]));

            Inmueble inmueble = new Inmueble {
                Uso = Request.Form["Uso"].ToString(),
                Tipo = Request.Form["Tipo"].ToString(),
                Ambientes = Int32.Parse(Request.Form["Ambientes"]),
                Precio = Double.Parse(Request.Form["Precio"]),
            };

            InmueblesData inmueblesData = new InmueblesData();
            var inmuebles = inmueblesData.obtenerInmueblesFiltro(inmueble);
            return View(inmuebles);
        }

        // GET: Inmuebles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            PropietarioData propietarioData = new PropietarioData();
            var propietarios = propietarioData.obtenerPropietarios();
            ViewBag.propietarios = propietarios;
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble inmueble)
        {
            try
            {
                // TODO: Add insert logic here
                PropietarioData propietarioData = new PropietarioData();
                Propietario p = propietarioData.obtenerPropietario(Int32.Parse(Request.Form["idPropietario"]));
                inmueble.Propietario = p;

                InmueblesData inmueblesData = new InmueblesData();
                inmueblesData.agregarInmueble(inmueble);
                System.Diagnostics.Debug.WriteLine("HOLAAAAAAAAAAAAAAA: " + Request.Form["idPropietario"]);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Inmuebles/Create
        public ActionResult FormBuscar()
        {
                return View();
        }

        public ActionResult Alquilar(int IdInmueble) {
            //return RedirectToAction("Create", "Alquileres", new { Id = Request.Form["Id"]});
            return RedirectToAction("Create", "Alquileres", new { IdInmueble = IdInmueble });
        }

        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.i = new InmueblesData().obtenerInmueble(id);
            return View();
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inmueble i)
        {
            try
            {
                // TODO: Add update logic here
                new InmueblesData().editar(i);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inmuebles/Delete/5
        public ActionResult Delete(int id)
        {
            new InmueblesData().eliminar(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Inmuebles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                new InmueblesData().eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}