using BigWebBooksRazor_Temp.Data;
using BigWebBooksRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigWebBooksRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _database;
        public List<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext database)
        {
            _database = database;
        }
        
        public void OnGet()
        {
            Categories = _database.Categories.ToList();
        }
    }
}
