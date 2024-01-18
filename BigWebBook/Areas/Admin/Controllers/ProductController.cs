using BigWeb.DataAccess.Repository.IRepository;
using BigWeb.Models;
using BigWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BigWebBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            List<Product> listProduct = _unitOfWork.Product.GetAll(includeProperties: "CategoryName").ToList();

            return View(listProduct);
        }

        public IActionResult Upsert(int? id)
        {
            ProductViewModel productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),

                Product = new Product()

            };

            if (id == null || id == 0)
            {
                //Создание
                return View(productVM);
            }
            else
            {
                //Обновление
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }


        }

        [HttpPost]
        public IActionResult Upsert(ProductViewModel obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(wwwRootPath, @"Images/Product");

                    if (!string.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        //Удаление старого изображения
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.Product.ImageUrl = @"/Images/Product/" + fileName;
                }

                if (obj.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                }


                _unitOfWork.Save();

                TempData["SuccessMessage"] = "Книга создана!";

                return RedirectToAction("Index");
            }

            else
            {
                ProductViewModel productVM = new()
                {
                    CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }),

                    Product = new Product()

                };

                return View(productVM);
            }

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (ModelState.IsValid)
            {
                Product? productFromDatabase = _unitOfWork.Product.Get(u => u.Id == id);

                if (productFromDatabase == null)
                {
                    return NotFound();
                }

                _unitOfWork.Product.Remove(productFromDatabase);
                _unitOfWork.Save();

                TempData["SuccessMessage"] = "Книга удалена!";

                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Книга не удалена!";

            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> listProduct = _unitOfWork.Product.GetAll(includeProperties: "CategoryName").ToList();
            return Json (new {data = listProduct});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id==id);

            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Ошибка при удалении" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json (new { success = true, message = "Удаление успешно" });
        }

        #endregion
    }
}
