using BigWeb.DataAccess.Data;
using BigWeb.DataAccess.Repository;
using BigWeb.DataAccess.Repository.IRepository;
using BigWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigWebBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            List<Category> listCategory = _unitOfWork.Category.GetAll().ToList();
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

            Category? categoryFromDatabase = _unitOfWork.Category.Get(u => u.Id == id);
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

            Category? categoryFromDatabase = _unitOfWork.Category.Get(u => u.Id == id);
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
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();

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
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();

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
                Category? categoryFromDatabase = _unitOfWork.Category.Get(u => u.Id == id);

                if (categoryFromDatabase == null)
                {
                    return NotFound();
                }

                _unitOfWork.Category.Remove(categoryFromDatabase);
                _unitOfWork.Save();

                TempData["SuccessMessage"] = "Категория удалена!";

                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Категория не удалена!";

            return View();
        }
    }
}

        

