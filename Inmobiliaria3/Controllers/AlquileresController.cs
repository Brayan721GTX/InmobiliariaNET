using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria3.Controllers
{
    public class AlquileresController : Controller
    {
        // GET: Alquiler
        public ActionResult Index()
        {
            AlquilerData alquilerData = new AlquilerData();
            var alquileres = alquilerData.obtenerAlquileres();
            System.Diagnostics.Debug.WriteLine("Numer de inquilinos: " + alquileres.Count);
            return View(alquileres);
        }

        // GET: Alquiler
        public ActionResult ListarVigentes()
        {
            AlquilerData alquilerData = new AlquilerData();
            var alquileres = alquilerData.obtenerAlquileresVigentes();
            return View(alquileres);
        }

        // GET: Alquiler
        public ActionResult ListarContratos(int id)
        {
            ViewBag.idInmueble = id;
            AlquilerData alquilerData = new AlquilerData();
            var alquileres = alquilerData.obtenerAlquileresDeInmueble(id);
            return View(alquileres);
        }

        // GET: Alquiler/Details/5
        public ActionResult Details(int Id)
        {
            return RedirectToAction("Index", "Pagos", new { IdAlquiler = Id});
        }

        // GET: Alquiler/Create
        public ActionResult Create(int id)
        {
            ViewBag.IdInmueble = id;
            System.Diagnostics.Debug.WriteLine("ID INMUEBLE: "+ id);
            ViewBag.Inquilinos = new InquilinoData().obtenerInquilinos();
            ViewBag.Inmuebles = new InmueblesData().obtenerInmuebles();

            return View();
        }

        // POST: Alquiler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("AAA1");
                // TODO: Add insert logic here
                InquilinoData inquilinoData = new InquilinoData();
                Inquilino inquilinoACrear = new Inquilino {
                    Dni = Request.Form["Dni"].ToString(),
                    Apellido = Request.Form["Apellido"].ToString(),
                    Nombre = Request.Form["Nombre"].ToString(),
                    Direccion = Request.Form["Direccion"].ToString(),
                    Telefono = Request.Form["Telefono"].ToString(),
                };
                System.Diagnostics.Debug.WriteLine("AAA2");

                int idInquilino = inquilinoData.crear(inquilinoACrear);
                System.Diagnostics.Debug.WriteLine("ID INQUILINO: " + idInquilino);
                System.Diagnostics.Debug.WriteLine("AAA3");
                Inquilino inquilino = inquilinoData.obtenerInquilino(idInquilino);
                System.Diagnostics.Debug.WriteLine("AAA4");

                InmueblesData inmuebleData = new InmueblesData();
                int idInmueble = Convert.ToInt32(collection["IdInmueble"]);
                System.Diagnostics.Debug.WriteLine("ID INMUEBLE: "+idInmueble);
                Inmueble inmueble = inmuebleData.obtenerInmueble(idInmueble);
                inmuebleData.marcarComoAlquilado(idInmueble);

                System.Diagnostics.Debug.WriteLine("AAA5");

                Alquiler a = new Alquiler
                {
                    Precio = Double.Parse(Request.Form["Precio"].ToString()),
                    FechaInicio = Convert.ToDateTime(Request.Form["FechaInicio"].ToString()),
                    FechaFin = Convert.ToDateTime(Request.Form["FechaFin"].ToString()),
                    Inquilino = inquilino,
                    Inmueble = inmueble,
                };

                System.Diagnostics.Debug.WriteLine("AAA6");

                AlquilerData alquilerData = new AlquilerData();
                alquilerData.crear(a);

                System.Diagnostics.Debug.WriteLine("AAA7");



                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("EXCEPCION: "+e.Message);
                return View();
            }
        }

        // GET: Alquiler/Edit/5
        public ActionResult Cancelar(int id)
        {
            AlquilerData alquilerData = new AlquilerData();
            alquilerData.cancelarAlquiler(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Alquiler/Edit/5
        public ActionResult Renovar(int id)
        {
            ViewBag.IdAlquiler = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Renovar()
        {
            int idAlquiler = Convert.ToInt32(Request.Form["IdAlquiler"]);
            double Precio = Convert.ToDouble(Request.Form["Precio"]);
            DateTime FechaInicio = Convert.ToDateTime(Request.Form["FechaInicio"]);
            DateTime FechaFin = Convert.ToDateTime(Request.Form["FechaFin"]);
            AlquilerData alquilerData = new AlquilerData();
            Alquiler alquiler = alquilerData.obtenerAlquiler(idAlquiler);
            //alquiler.
            alquilerData.renovarAlquiler(idAlquiler, FechaInicio, FechaFin, Precio);
            return RedirectToAction(nameof(Index));
        }

        // GET: Alquiler/Edit/5
        public ActionResult Edit(int id, int IdInmueble)
        {
            System.Diagnostics.Debug.WriteLine("Id de alquiler GET: " + id);
            Alquiler a = new AlquilerData().obtenerAlquiler(id);
            ViewBag.Id = id;
            ViewBag.Precio = a.Precio;
            ViewBag.FechaInicio = a.FechaInicio;
            ViewBag.FechaFin = a.FechaFin;
            return View();
        }

        // POST: Alquiler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alquiler alquiler, int IdInmueble)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Id de alquiler POST: "+alquiler.Id);
                new AlquilerData().editar(alquiler);
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Excepcion Create POST: " + e.Message);
                return View();
            }
        }

        // GET: Alquiler/Delete/5
        public ActionResult Delete(int id)
        {
            new AlquilerData().eliminar(id);

            return RedirectToAction("ListarContratos", new { id = id });
        }

        // POST: Alquiler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                new AlquilerData().eliminar(id);

                return RedirectToAction("ListarContratos", new { id = id });
            }
            catch
            {
                return View();
            }
        }
    }
}