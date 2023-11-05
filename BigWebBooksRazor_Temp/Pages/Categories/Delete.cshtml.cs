using BigWebBooksRazor_Temp.Data;
using BigWebBooksRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigWebBooksRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _database;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext database)
        {
            _database = database;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _database.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? category = _database.Categories.Find(Category.Id);

            if (category == null)
            {
                return NotFound();
            }

            _database.Categories.Remove(category);
            _database.SaveChanges();

            TempData["SuccessMessage"] = "Категория удалена!";

            return RedirectToPage("Index");
        }
    }
}
