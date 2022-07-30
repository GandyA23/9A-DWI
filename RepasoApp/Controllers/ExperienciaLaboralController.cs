using Microsoft.AspNetCore.Mvc;
using RepasoApp.Models;
using RepasoApp.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepasoApp.Services;
using AutoMapper;

namespace RepasoApp.Controllers
{
    public class ExperienciaLaboralController : Controller
    {
        private readonly ILogger<ExperienciaLaboralController> _logger;
        private readonly IExperienciaLaboralRepository _experienciaLaboralRepository;
        private readonly ITipoEmpleoRepository _tipoEmpleoRepository;
        private readonly IEntidadFederativaRepository _entidadFederativaRepository;
        private readonly IMapper _autoMapper;

        public ExperienciaLaboralController(ILogger<ExperienciaLaboralController> logger, IExperienciaLaboralRepository ExperienciaLaboralRepository, ITipoEmpleoRepository TipoEmpleoRepository, IEntidadFederativaRepository EntidadFederativaRepository, IMapper autoMapper)
        {
            _logger = logger;
            _experienciaLaboralRepository = ExperienciaLaboralRepository;
            _entidadFederativaRepository = EntidadFederativaRepository;
            _tipoEmpleoRepository = TipoEmpleoRepository;
            _autoMapper = autoMapper;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(ExperienciaLaboral experienciaLaboral)
        {
           if (!ModelState.IsValid) {
                var modelo = await ObtenerExperienciaLaboralViewModel();
                modelo.AbrirModel = 1;
                return View("Index",modelo);
           }
           await _experienciaLaboralRepository.Registrar(experienciaLaboral);
           return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var modelo = await ObtenerExperienciaLaboralViewModel();
            return View(modelo);
        }

        private async Task<IEnumerable<SelectListItem>> ObtenerTiposEmpleos(){
            var tiposEmpleos = await _tipoEmpleoRepository.Listar();
            return tiposEmpleos.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
        }

        private async Task<IEnumerable<SelectListItem>> ObtenerEntidadesFederativas(){
            var tiposEmpleos = await _entidadFederativaRepository.Listar();
            return tiposEmpleos.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
        }

        private async Task<ExperienciaLaboralViewModel> ObtenerExperienciaLaboralViewModel(){
            var modelo = new ExperienciaLaboralViewModel();
            modelo.ExperienciaLaborales = await _experienciaLaboralRepository.Listar();
            modelo.TiposEmpleos = await ObtenerTiposEmpleos();
            modelo.EntidadesFederativas = await ObtenerEntidadesFederativas();
            return modelo;
        }

    }
}