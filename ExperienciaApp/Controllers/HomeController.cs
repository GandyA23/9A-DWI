using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExperienciaApp.Models;

namespace ExperienciaApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Obten los proyectos tomando solo N
        var proyectos = ObtenerProyectos().Take(4).ToList();
        var habilidades = ObtenerHabilidades().Take(3).ToList();
        // Objeto que nos va a ayudar a mandar varios atributos a la vista
        var modelo = new HomeIndexViewModel { 
            Proyectos = proyectos,
            Habilidades = habilidades
        };
        return View(modelo);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    private List<Proyecto> ObtenerProyectos () {
        return new List<Proyecto>(){
            new Proyecto {
                Titulo = "Amazon",
                Descripcion = "E-commerce en .NET",
                Imagen = "imagen1.jpg",
                Enlace = "https://www.amazon.com"
            },
            new Proyecto {
                Titulo = "Farmacia",
                Descripcion = "Plataforma que administra medicamentos creada con Laravel 7",
                Imagen = "imagen2.jpg",
                Enlace = "https://www.farmacia.com"
            },
            new Proyecto {
                Titulo = "Educación",
                Descripcion = "Plataforma que administra alumnos en una escuela creada con Laravel 7 (Back-end) y Quasar 2 (Front-end)",
                Imagen = "imagen3.jpg",
                Enlace = "https://www.escuela.com"
            },
            new Proyecto {
                Titulo = "Ferias Virtuales",
                Descripcion = "Plataforma que administra Ferias Virtuales creada con Laravel 4",
                Imagen = "imagen4.jpg",
                Enlace = "https://www.ferias.com"
            }
        };
    }

    private List<Habilidad> ObtenerHabilidades () {
        return new List<Habilidad> () {
            new Habilidad {
                Nombre = "MVC Laravel"
            },
            new Habilidad {
                Nombre = "Laravel API Rest"
            },
            new Habilidad {
                Nombre = "Front-end Quasar"
            },
            new Habilidad {
                Nombre = "Front-end Bootstrap"
            }
        };
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
