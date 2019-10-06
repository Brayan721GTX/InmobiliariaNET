using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria3.Controllers
{
    public class PropietariosController : Controller
    {
        // GET: Propietario
        public ActionResult Index()
        {
            PropietarioData propietarioData = new PropietarioData();
            var propietarios = propietarioData.obtenerPropietarios();

            return View(propietarios);
        }

        // GET: Propietario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Propietario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propietario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietario propietario)
        {
            try
            {
                // TODO: Add insert logic here
                PropietarioData propietarioData = new PropietarioData();
                propietarioData.crear(propietario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Propietario/Edit/5
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

        // GET: Propietario/Delete/5
        public ActionResult Delete(int id)
        {
            new PropietarioData().eliminar(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Propietario/Delete/5
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