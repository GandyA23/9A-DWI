using Microsoft.AspNetCore.Mvc;

/**
* Cada que se use el método View, este va a ser referencia a las vistas dentro de la carpeta View/App
*/
namespace ExampleApp.Controllers {
    public class AppController : Controller {
        public IActionResult Index () {
            return View();
        }
    }
}