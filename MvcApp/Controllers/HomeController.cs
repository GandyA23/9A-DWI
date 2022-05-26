using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        // Es posible mandar valores a la vista dentro de ViewBag
        ViewBag.Name = "Gandy Esaú";
        ViewBag.Lastname = "Ávila Estrada";

        return View("Privacy2");
    }

    public IActionResult PersonalData()
    {
        ViewBag.Name = "Gandy Esaú";
        ViewBag.Lastname = "Ávila Estrada";
        ViewBag.Age = 20;
        ViewBag.Email = "avila.gandy@gmail.com";
        ViewBag.Phone = "+52 557 390 8785";
        return View();
    }

    public IActionResult Hobbie()
    {
        ViewBag.Hobbie1 = "Jugar videojuegos";
        ViewBag.Hobbie2 = "Jugar Ajedrez";
        ViewBag.Hobbie3 = "Programar";        
        return View();
    }

    public IActionResult Major()
    {
        ViewBag.Name = "Ingenería en Desarrollo y Gestión de Software";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
