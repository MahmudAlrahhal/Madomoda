using MadoDataAccess.Data;
using MadoDataAccess.Repository;
using MadoDataAccess.Repository.IRepository;
using MadoModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Madomoda.Controllers
{
    public class CategoryController : Controller
    {
        //Retrieving the db object from ApplicationDbContext to get the data
        private readonly IunitofWork UnitofWork;
       // private readonly CategoryRespository RpoRepository;
        public CategoryController(IunitofWork db)//, CategoryRespository RpoRepository)
        {
            UnitofWork = db;
           // this.RpoRepository = RpoRepository;
        }
        public IActionResult Index()
        {
            //Inserting the data inside a List of Category type class.
            //List<Category> categories = RpoRepository.GetAll().ToList();
            List<Category> categories = UnitofWork.CategoryRepository.GetAll().ToList();
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
            if (ModelState.IsValid)
            {
                UnitofWork.CategoryRepository.Add(cat);
                UnitofWork.CategoryRepository.save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category? editCat = UnitofWork.CategoryRepository.Get(u=>u.Id==id);
            //Category? editCat1 = _db.Categories.FirstOrDefault(d => d.Id == id);
            //Category? editCat2 = _db.Categories.Where(d => d.Id == id).FirstOrDefault();
            if (editCat == null) return NotFound();

            return View(editCat);
        }

        //This method will receive the posted form from Create.cshtml and store it in cat object.
        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.CategoryRepository.update(cat);
                UnitofWork.save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category? deletecat = UnitofWork.CategoryRepository.Get(u => u.Id == id);
            if (deletecat == null) return NotFound();

            return View(deletecat);
        }

        //This method will receive the posted form from Create.cshtml and store it in cat object.
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            Category? cat = UnitofWork.CategoryRepository.Get(u => u.Id == id);
            if(cat == null) return NotFound();
            UnitofWork.CategoryRepository.Delete(cat);
            UnitofWork.save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");


        }
    }
}
