using Microsoft.AspNetCore.Mvc;
using RepasoApp.Models;
using RepasoApp.Service;

namespace RepasoApp.Controllers
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
        public async Task<IActionResult> Index()
        {
            var modelo = await ObtenerContactoViewModel();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(Contacto contacto)
        {
            var existeCorreo = await _contactoRepository.VerificarExisteCorreo(contacto.CorreoElectronico);
            if (!ModelState.IsValid || existeCorreo)
            {
                if(existeCorreo){
                    ModelState.AddModelError(nameof(contacto.CorreoElectronico),
                    $"El correo {contacto.CorreoElectronico} ya existe");
                }
                var modelo = await ObtenerContactoViewModel();
                modelo.Nombre = contacto.Nombre;
                modelo.Edad = contacto.Edad;
                modelo.CorreoElectronico = contacto.CorreoElectronico;
                modelo.Telefono = contacto.Telefono;
                modelo.AbrirModel = 1;
                //await _contactoRepository.Registrar(contacto);
                return View("Index", modelo);
            }
            await _contactoRepository.Registrar(contacto);
            return RedirectToAction("Index");
        }

        private async Task<ContactoViewModel> ObtenerContactoViewModel(){
            var modelo = new ContactoViewModel();
            modelo.Contactos = await _contactoRepository.Listar();
            return modelo;
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(Contacto contacto)
        {
            var existeContacto = await _contactoRepository.BuscarPorId(contacto.Id);
            if (existeContacto is null)
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
            if (existeContacto is null)
            {
                return RedirectToAction("Index");
            }
            await _contactoRepository.Eliminar(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            var contacto = await _contactoRepository.BuscarPorId(id);
            if (contacto is null)
            {
                return RedirectToAction("Index");
            }
            return View(contacto);
        }


        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> VerificarExisteCorreo(string correoElectronico)
        {
            var existeCorreo = await _contactoRepository.VerificarExisteCorreo(correoElectronico);
            if (existeCorreo)
            {
                return Json($"El correo {correoElectronico} ya ha sido registrado.");
            }else{
                return Json(true);
            }
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> VerificarExisteTelefono(string Telefono, int Id)
        {
            var existeTelefono = await _contactoRepository.VerificarExisteTelefono(Telefono, Id);
            if (existeTelefono)
            {
                return Json($"El telefono {Telefono} ya ha sido registrado.");
            }else{
                 return Json(true);
            }
           
        }

        //...Other programming code
    }
}