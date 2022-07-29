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

        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
                var contacto = await _contactoRepository.BuscarPorId(id);
                if(contacto is null)
                {
                    return RedirectToAction("Index");
                }
                return View(contacto);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(Contacto contacto)
        {
                var existeContacto = await _contactoRepository.BuscarPorId(contacto.Id);
                if(existeContacto is null)
                {
                    return RedirectToAction("Index");
                }
                await _contactoRepository.Actualizar(contacto);
                return RedirectToAction("Index");
        } 

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
                var existeContacto = await _contactoRepository.BuscarPorId(id);
                if(existeContacto is null)
                {
                    return RedirectToAction("Index");
                }
                await _contactoRepository.Eliminar(id);
                return RedirectToAction("Listar");
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> VerificarExisteCorreo(string correoElectronico)
        {
                var existeCorreo = await _contactoRepository.VerificarExisteCorreo(correoElectronico);
                if(existeCorreo)
                {
                    return Json($"El correo {correoElectronico} ya ha sido registrado.");
                }
                return Json(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}