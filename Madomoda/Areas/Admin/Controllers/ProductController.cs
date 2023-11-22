using MadoDataAccess.Repository;
using MadoDataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

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
    }
}
