using Microsoft.AspNetCore.Mvc;
using Adoption_MVC_Lab.Models;

namespace Adoption_MVC_Lab.Controllers
{
    public class AnimalController : Controller
    {
        AdoptionDbContext dbcontext = new AdoptionDbContext();
        public IActionResult Index()
        {
            List<Animal> animals = dbcontext.Animals.ToList();
            return View(animals);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult AddAnimal(Animal a)
        {
            dbcontext.Animals.Add(a);
            dbcontext.SaveChanges();
            return RedirectToAction("confirmation", new {add=true});
        }
        public IActionResult Adopt(int id)
        {
           Animal result = dbcontext.Animals.Find(id);
            dbcontext.Animals.Remove(result);
            dbcontext.SaveChanges();
            return RedirectToAction("confirmation", new { add = false });
        }
        public IActionResult Result(string breed)
        {
            List<Animal> result = dbcontext.Animals.Where(p => p.Breed == breed).ToList();
            return View(result);
        }
        public IActionResult confirmation(bool add)
        {
            return View(add);
        }

    }
}
