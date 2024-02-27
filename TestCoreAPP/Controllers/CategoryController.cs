using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
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
        public async Task <IActionResult> Index()
        {
            var one = _reository.SelectOne(x => x.Name == "Computers");
            var all = await _reository.FindAllAsync("Items"); 
            return View( all);
        }
        //GET
        public IActionResult AddCat()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCat(Categories categories)
        {
            _reository.addCat(categories);
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult EditCat(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var category = _reository.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCat(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _reository.updateCat(categories);
                return RedirectToAction("Index");
            }
            else
            {
                return View(categories);
            }
        }
        //GET
        public IActionResult DeleteCat(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _reository.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCat(Categories categories)
        {
            _reository.deleteCat(categories);
            TempData["successData"] = "Category has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
