using MadoDataAccess.Repository;
using MadoDataAccess.Repository.IRepository;
using MadoModels.Models;
using MadoModels.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Madomoda.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IunitofWork _IunitofWork;
        private readonly IWebHostEnvironment webHost;
        public ProductController(IunitofWork IunitofWork, IWebHostEnvironment webHost)
        {
            this._IunitofWork = IunitofWork;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            List<Product> prdt = _IunitofWork.ProductRepository.GetAll("Category").ToList();
            return View(prdt);
        }
        public IActionResult Upsert(int? id)
        {
            PVM productVM = new()
            {
                categoryList = _IunitofWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                product = new Product()
            };
            if (id == null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.product = _IunitofWork.ProductRepository.Get(u => u.Id == id);
                return View(productVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(PVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHost.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(productVM.product.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, productVM.product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.product.ImageUrl = @"\images\product\" + fileName;
                }

                if (productVM.product.Id == 0)
                {
                    _IunitofWork.ProductRepository.Add(productVM.product);
                }
                else
                {
                    _IunitofWork.ProductRepository.update(productVM.product);
                }

                _IunitofWork.save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.categoryList = _IunitofWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
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
            _IunitofWork.ProductRepository.Delete(product);
            _IunitofWork.save();
            TempData["Success"] = "Product was deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
