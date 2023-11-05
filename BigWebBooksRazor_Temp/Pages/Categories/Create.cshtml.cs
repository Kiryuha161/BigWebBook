using BigWebBooksRazor_Temp.Data;
using BigWebBooksRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigWebBooksRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _database;
        
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext database)
        {
            _database = database;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _database.Categories.Add(Category);
                _database.SaveChanges();

                TempData["SuccessMessage"] = "Категория создана!";

                return RedirectToPage("Index");
            }

            TempData["ErrorMessage"] = "Категория не создана!";
            return Page();
            
        }
    }
}
