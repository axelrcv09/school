using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Models;

namespace School.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly SchoolDB _context;
        public IActionResult Index()
        {
            var estudiantes = _context.People.ToList();

            return View(estudiantes);
        }

        public IActionResult Ficha(int id)
        { 
            var estudiante = _context.People
            .Where(r => r.PersonID == id)
            .FirstOrDefault();

            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Modificar(Person estudiante)
        {
            if(ModelState.IsValid)
            {
                _context.Update(estudiante);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View("Ficha");
            }
        }

        public EstudiantesController(SchoolDB context)
        {
            _context = context;
        }
    }
}