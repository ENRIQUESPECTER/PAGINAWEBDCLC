using CRUDCORE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//ReferenciaLocalization
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Builder;


namespace CRUDCORE.Controllers
{
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost] 
        //Metodo para cambiar el idioma - Guardarlo 
        public IActionResult EstablecerCultura(string nuevaCultura, string retornarUrl)
        {
            Response.Cookies.Append(
             CookieRequestCultureProvider.DefaultCookieName,
             CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(nuevaCultura)),
             new CookieOptions { Expires = System.DateTimeOffset.UtcNow.AddDays(5) });
            
            return LocalRedirect(retornarUrl);
        }   
    }
}
