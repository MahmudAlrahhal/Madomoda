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
    }
}
