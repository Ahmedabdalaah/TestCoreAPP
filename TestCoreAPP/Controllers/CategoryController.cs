using Microsoft.AspNetCore.Mvc;
using TestCoreAPP.Models;
using TestCoreAPP.Repository.@base;

namespace TestCoreAPP.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(IRepository<Categories> reository)
        {
            _reository = reository;
        } 
        private IRepository<Categories> _reository;
        public IActionResult Index()
        {
            return View(_reository.GetAll());
        }
    }
}
