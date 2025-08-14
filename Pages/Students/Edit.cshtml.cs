using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Models;
using System.Threading.Tasks;

namespace StudentManagementApp.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly StudentManagementContext _context;

        public EditModel(StudentManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Student = await _context.Students.FindAsync(id);

            if (Student == null) return NotFound();

            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", Student.CourseID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", Student.CourseID);
                return Page();
            }

            _context.Attach(Student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
