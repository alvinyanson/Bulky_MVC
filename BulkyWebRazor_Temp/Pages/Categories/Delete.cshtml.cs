using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category categoryObj = _db.Categories.Find(Category.Id);

            if (categoryObj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryObj);
            _db.SaveChanges();
            //TempData["success"] = "Category deleted successfully.";
            return RedirectToPage("Index");
        }
    }
}
