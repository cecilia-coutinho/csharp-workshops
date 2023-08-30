using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc_resultats_typer.Models;
using Newtonsoft.Json;
using System.Net.Cache;

namespace mvc_resultats_typer.Controllers
{
    public class PersonController : Controller
    {
        private List<Person> people = new List<Person>
    {
        new Person { Id = 1, Name = "Maria Rosa", Age = 30 },
        new Person { Id = 2, Name = "Kalle Krille", Age = 25 },
        new Person { Id = 3, Name = "Donna Donnuts", Age = 35 }
    };

        // GET: PersonController
        public ActionResult Index()
        {
            var jsonPeople = JsonConvert.SerializeObject(people, Formatting.Indented);
            ViewBag.PeopleJson = jsonPeople;

            return View(people);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {

            var person = people.FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                return Json(person);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
