using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExperienciaApp.Models;
using ExperienciaApp.Services;

namespace ExperienciaApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // Uso del repository en el controller
    private readonly IProyectoRepository _proyectoRepository;
    private readonly IHabilidadRepository _habilidadRepository;
    private readonly IContactoRepository _contactoRepository;

    public HomeController(ILogger<HomeController> logger, IProyectoRepository proyectoRepository, IHabilidadRepository habilidadRepository, IContactoRepository contactoRepository)
    {
        _logger = logger;
        _proyectoRepository = proyectoRepository;
        _habilidadRepository = habilidadRepository;
        _contactoRepository = contactoRepository;
    }

    public IActionResult Index()
    {
        // Estas líneas no se ejecutaran cuando cambie la aplicación a productivo
        // Mostrar información con el logger
        _logger.LogInformation("Test information in Logger");
        _logger.LogError("Test error in Logger");
        _logger.LogWarning("Test warning in Logger");

        // Obtener variables de entorno dentro de la aplicación
        var builder = WebApplication.CreateBuilder();
        var directory = builder.Configuration.GetValue<string>("DirectoryImages");
        _logger.LogInformation($"Image Directory: {directory}");

        // Obten los proyectos tomando solo N
        var proyectos = _proyectoRepository.ObtenerProyectos().Take(4).ToList();
        var habilidades = _habilidadRepository.ObtenerHabilidades().Take(3).ToList();

        // Objeto que nos va a ayudar a mandar varios atributos a la vista
        var modelo = new HomeIndexViewModel { 
            Proyectos = proyectos,
            Habilidades = habilidades,
            Estatus = true
        };
        return View(modelo);
    }

    [HttpGet]
    public IActionResult Contacto() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contacto(Contacto contacto) {
        _logger.LogInformation($"Contacto: {contacto.Email}");
        // Validación del modelo
        if (!ModelState.IsValid)
            return View(contacto);
        await _contactoRepository.Registrar(contacto);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
