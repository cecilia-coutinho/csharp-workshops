using mvc_resultats_typer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Hosting.Internal;
using System.Web;
using mvc_resultats_typer.ActionFilters;

namespace mvc_resultats_typer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [CustomStringFilter]
        public IActionResult Index()
        {
            ViewBag.CustomMessage = HttpContext.Items["CustomMessage"];
            return View();
        }

        //GET/DownloadFile
        public IActionResult DownloadTrial(string fileName)
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileName);

            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/octet-stream", fileName);
            }
            else
            {
                return NotFound();
            }
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
}