using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using TestCoreAPP.Models;
using TestCoreAPP.Repository.@base;

namespace TestCoreAPP.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        public CategoryController(IunitOfWork _myUnit)
        {
            myUnit=_myUnit;
        } 
        private readonly IunitOfWork myUnit;
        public async Task <IActionResult> Index()
        {
            var one = myUnit.categories.SelectOne(x => x.Name == "Computers");
            var all = await myUnit.categories.FindAllAsync("Items"); 
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
            myUnit.categories.addCat(categories);
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult EditCat(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var category = myUnit.categories.GetById(id.Value);
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
                myUnit.categories.updateCat(categories);
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
            var category = myUnit.categories.GetById(id.Value);
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
            myUnit.categories.deleteCat(categories);
            TempData["successData"] = "Category has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
