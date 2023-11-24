using MadoDataAccess.Repository;
using MadoDataAccess.Repository.IRepository;
using MadoModels.Models;
using MadoModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Madomoda.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IunitofWork _IunitofWork;
        public ProductController(IunitofWork IunitofWork)
        {
            this._IunitofWork = IunitofWork;
        }
        public IActionResult Index()
        {

            return View(_IunitofWork.ProductRepository.GetAll().ToList());
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> categoryList = _IunitofWork.CategoryRepository
            .GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            //ViewBag.CatList = categoryList;
            ViewData["CatList"] = categoryList;
            PVM pvm = new (){
                product = new Product(),
                categoryList = categoryList
            };
            return View(pvm);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _IunitofWork.ProductRepository.Add(product);
                _IunitofWork.save();
                return RedirectToAction("Index", _IunitofWork.ProductRepository.GetAll());
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0) return NotFound();
            Product product = _IunitofWork.ProductRepository.Get(u => u.Id == id);
            return View(product);

        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _IunitofWork.ProductRepository.update(product);
                _IunitofWork.save();
                TempData["Success"] = "Product was updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Product pro = _IunitofWork.ProductRepository.Get(ui => ui.Id == id);
                if (pro == null) return NotFound();
                return View(pro);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                _IunitofWork.ProductRepository.Delete(product);
                _IunitofWork.save();
                TempData["Success"] = "Product was deleted successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

    }
}
