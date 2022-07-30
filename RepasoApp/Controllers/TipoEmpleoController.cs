using Microsoft.AspNetCore.Mvc;
using RepasoApp.Models;
using RepasoApp.Service;
using RepasoApp.Services;

namespace RepasoApp.Controllers
{
    public class TipoEmpleoController : Controller
    {
        private readonly ILogger<TipoEmpleoController> _logger;
        private readonly ITipoEmpleoRepository _tipoEmpleoRepository;

        public TipoEmpleoController(ILogger<TipoEmpleoController> logger, ITipoEmpleoRepository TipoEmpleoRepository)
        {
            _logger = logger;
            _tipoEmpleoRepository = TipoEmpleoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var modelo = await ObtenerTipoEmpleoViewModel();
            return View(modelo);
        }


        [HttpPost]
        public async Task<IActionResult> Registrar(TipoEmpleo tipoEmpleo)
        {
           if (!ModelState.IsValid){
            var modelo = await ObtenerTipoEmpleoViewModel();
            modelo.Nombre = tipoEmpleo.Nombre;
            return View("Index",modelo);
           }
           await _tipoEmpleoRepository.Registrar(tipoEmpleo);
           return RedirectToAction("Index");
        }

        private async Task<TipoEmpleoViewModel> ObtenerTipoEmpleoViewModel(){
            var modelo = new TipoEmpleoViewModel();
            modelo.TipoEmpleos = await _tipoEmpleoRepository.Listar();
            return modelo;
        }

    }
}