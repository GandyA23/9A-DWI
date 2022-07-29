using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExperienciaApp.Models;
using ExperienciaApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExperienciaApp.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;

        private readonly IContactoRepository _contactoRepository;

        public ContactoController(ILogger<ContactoController> logger, IContactoRepository contactoRepository) 
        {
            _logger = logger;
            _contactoRepository = contactoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(){
            var listaContactos = await _contactoRepository.Listar();
            var modelo = new ContactoViewModel() { Contactos = listaContactos };
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(Contacto contacto){
            if(ModelState.IsValid)
            {
                await _contactoRepository.Registrar(contacto);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}