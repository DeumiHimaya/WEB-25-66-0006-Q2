using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementApp.Data;
using StudentManagementApp.Models;
using System.Threading.Tasks;

namespace StudentManagementApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly StudentManagementContext _context;

        public CreateModel(StudentManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name");
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
