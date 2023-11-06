using BigWeb.DataAccess.Data;
using BigWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigWebBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _database;

        public CategoryController(ApplicationDbContext database)
        {
            _database = database;
        }
        
        
        public IActionResult Index()
        {
            List<Category> listCategory = _database.Categories.ToList();
            return View(listCategory);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDatabase = _database.Categories.Find(id);
            if (categoryFromDatabase == null)
            {
                return NotFound();
            }

            return View(categoryFromDatabase);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDatabase = _database.Categories.Find(id);
            if (categoryFromDatabase == null)
            {
                return NotFound();
            }

            return View(categoryFromDatabase);
        }



        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Имя и порядковый номер не могут совпадать");
            }
            
            if (ModelState.IsValid)
            {
                _database.Categories.Add(category);
                _database.SaveChanges();

                TempData["SuccessMessage"] = "Категория создана!";

                return RedirectToAction("Index", "Category");
            }

            TempData["ErrorMessage"] = "Категория не создана!";

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
           if (ModelState.IsValid)
            {
                _database.Categories.Update(category);
                _database.SaveChanges();

                TempData["SuccessMessage"] = "Категория отредактирована!";

                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Категория не отредактирована!";

            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (ModelState.IsValid)
            {
                Category? categoryFromDatabase = _database.Categories.Find(id);
                
                if (categoryFromDatabase == null)
                {
                    return NotFound();
                }
                
                _database.Categories.Remove(categoryFromDatabase);
                _database.SaveChanges();

                TempData["SuccessMessage"] = "Категория удалена!";

                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Категория не удалена!";

            return View();
        }
    }
}

