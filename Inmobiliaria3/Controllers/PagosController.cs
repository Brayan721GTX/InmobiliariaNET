using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria3.Controllers
{
    public class PagosController : Controller
    {
        // GET: Pagos
        public ActionResult Index(int idAlquiler)
        {
            ViewBag.IdAlquiler = idAlquiler;
            System.Diagnostics.Debug.WriteLine("IdAlquiler Index: "+ idAlquiler);
            PagosData pagosData = new PagosData();
            var pagos = pagosData.obtenerPagos(idAlquiler);
            return View(pagos);
        }

        // GET: Pagos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pagos/Create
        public ActionResult Create(int IdAlquiler)
        {
            ViewBag.IdAlquiler = IdAlquiler;
            System.Diagnostics.Debug.WriteLine("IdAlquiler Create: " + IdAlquiler);
            return View();
        }

        // POST: Pagos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                AlquilerData alquilerData = new AlquilerData();

                System.Diagnostics.Debug.WriteLine("COMPLETO 0.5: "+ Request.Query["IdAlquiler"]);
                System.Diagnostics.Debug.WriteLine("COMPLETOOOOO"+ Request.Form["IdAlquiler"].ToString()); 
                Alquiler alquiler = alquilerData.obtenerAlquiler(Convert.ToInt32(Request.Form["IdAlquiler"]));
                System.Diagnostics.Debug.WriteLine("IDDDDDDDDDDDDD: "+ Convert.ToInt32(Request.Form["IdAlquiler"]));
                System.Diagnostics.Debug.WriteLine("COMPLETO 1");
                Pagos pago = new Pagos {
                    NroPago = new PagosData().obtenerNumerosDePagos(Convert.ToInt32(Request.Form["IdAlquiler"])) + 1,
                    Fecha = Convert.ToDateTime(Request.Form["Fecha"]),
                    Importe = Convert.ToDouble(Request.Form["Importe"]),
                    Alquiler = alquiler,
                };
                System.Diagnostics.Debug.WriteLine("COMPLETO 2");

                PagosData pagosData = new PagosData();
                pagosData.crear(pago);
                System.Diagnostics.Debug.WriteLine("COMPLETO 3");

                return RedirectToAction(nameof(Index), "Pagos", new {IdAlquiler = Convert.ToInt32(Request.Form["IdAlquiler"]) });
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("EXCEPCION :"+e.Message);
                return View();
            }
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pagos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int id)
        {
            new PagosData().eliminar(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Pagos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}