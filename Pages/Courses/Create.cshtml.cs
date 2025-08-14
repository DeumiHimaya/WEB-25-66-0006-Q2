using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementApp.Data;
using StudentManagementApp.Models;
using System.Threading.Tasks;

namespace StudentManagementApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly StudentManagementContext _context;

        public CreateModel(StudentManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
