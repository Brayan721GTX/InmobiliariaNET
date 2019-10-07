using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria3.Controllers
{
    public class InquilinosController : Controller
    {
        // GET: Inquilino
        public ActionResult Index()
        {
            InquilinoData inquilinoData = new InquilinoData();
            var inquilinos = inquilinoData.obtenerInquilinos();
            return View(inquilinos);
        }

        // GET: Inquilino/Buscar/5
        public ActionResult Buscar(int dni)
        {
            return View();
        }

        // GET: Inquilino/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void Alquilar() {
            
        }

        // GET: Inquilino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilino/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino inquilino)
        {
            try
            {
                // TODO: Add insert logic here
                InquilinoData inquilinoData = new InquilinoData();
                inquilinoData.crear(inquilino);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilino/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            ViewBag.i = new InquilinoData().obtenerInquilino(id);
            return View();
        }

        // POST: Inquilino/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inquilino inquilino)
        {
            try
            {
                // TODO: Add update logic here
                new InquilinoData().editar(inquilino);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilino/Delete/5
        public ActionResult Delete(int id)
        {
            new InquilinoData().eliminar(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Inquilino/Delete/5
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