using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria3.Controlador
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Inmuebles");
        }
    }
}