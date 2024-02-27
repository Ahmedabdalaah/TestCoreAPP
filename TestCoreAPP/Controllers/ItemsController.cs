using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestCoreAPP.Data;
using TestCoreAPP.Models;

namespace TestCoreAPP.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDBContext _db;
        public ItemsController(AppDBContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            IEnumerable<Item> itemList = _db.items.ToList();
            return View(itemList);
        }
        //Get
        public IActionResult New()
        {
            createSelect();
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (item.Name == "apple")
            {
                ModelState.AddModelError("Name", "Change item name ");
            }
            if(ModelState.IsValid)
            {
                _db.items.Add(item);
                _db.SaveChanges();
                TempData["success"] = "you have bedn added data successfully";
                return RedirectToAction("Index");
            }
           else
            {
                return View(item);
            }
        }
        public void createSelect(int selectedId=1)
        {
            //List<Categories> categories= new List<Categories>{
            // new Categories { Id= 0 , Name="Select Catgory"},
            // new Categories { Id= 1 , Name="Computers"},
            // new Categories { Id= 2 , Name="Mobiles"},
            // new Categories { Id= 3 , Name="Electrical"}
            //};
            List<Categories> categories = _db.categories.ToList();  
            SelectList listItems = new SelectList(categories, "Id", "Name", selectedId);
            ViewBag.CategoryList = listItems; 
        }
        //Get
        public IActionResult Edit(int? id )
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           var item = _db.items.Find(id); 
            if(item == null)
            {
                return NotFound();
            }
            createSelect(item.category);
            return View(item);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.Name == "apple")
            {
                ModelState.AddModelError("Name", "Change item name ");
            }
            if (ModelState.IsValid)
            {
                _db.items.Update(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            createSelect(item.category);
            return View(item);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? id)
        {
            var item = _db.items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
