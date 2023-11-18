using Madomoda.Data;
using Madomoda.Models;
using Microsoft.AspNetCore.Mvc;

namespace Madomoda.Controllers
{
    public class CategoryController : Controller
    {
        //Retrieving the db object from ApplicationDbContext to get the data
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
                _db = db;
        }
        public IActionResult Index()
        {
            //Inserting the data inside a List of Category type class.
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        //This method will receive the posted form from Create.cshtml and store it in cat object.
        [HttpPost]
        public IActionResult Create(Category cat)
        {
            //if(cat.DisplayOrder.ToString().Equals(cat.Name))
            //{
            //    ModelState.AddModelError("name", "The name of the category cannot be equal to the displayOrder");
            //}
            //checking whether the sent object information is meeting the validation requirements or not.
            if (ModelState.IsValid) { 
            _db.Categories.Add(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
            
        }
    }
}
