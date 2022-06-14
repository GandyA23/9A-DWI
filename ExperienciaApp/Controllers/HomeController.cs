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

    public HomeController(ILogger<HomeController> logger, IProyectoRepository proyectoRepository, IHabilidadRepository habilidadRepository)
    {
        _logger = logger;
        _proyectoRepository = proyectoRepository;
        _habilidadRepository = habilidadRepository;
    }

    public IActionResult Index()
    {
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
