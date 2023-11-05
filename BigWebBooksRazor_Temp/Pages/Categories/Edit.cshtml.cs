using BigWebBooksRazor_Temp.Data;
using BigWebBooksRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigWebBooksRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _database;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext database)
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
            if (ModelState.IsValid)
            {
                _database.Categories.Update(Category);
                _database.SaveChanges();

                TempData["SuccessMessage"] = "Категория отредактирована!";

                return RedirectToPage("Index");
            }

            TempData["ErrorMessage"] = "Категория не отредактирована!";

            return Page();
        }
    }
}
            
            
