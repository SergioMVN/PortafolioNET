using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IservicioEmail iservicioEmail;
        

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IservicioEmail iservicioEmail)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.iservicioEmail = iservicioEmail;
        }

        public IActionResult Index()
            
        {
            _logger.LogError("Error desde el segundo LOGGER");
            //_logger.LogInformation("mensaje desde el log");
            //var repositorioProyectos = new RepositorioProyectos();
            var proyectos = repositorioProyectos.ObtenerProyecto().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { proyectos = proyectos };
        
            return View (modelo); 
        }

      public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyecto();
            return View (proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult>Contacto(ContactoViewModel contactoViewModel)
        {
            await iservicioEmail.Enviar(contactoViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}