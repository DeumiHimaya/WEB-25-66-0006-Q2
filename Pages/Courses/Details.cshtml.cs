using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Models;
using System.Threading.Tasks;

namespace StudentManagementApp.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly StudentManagementContext _context;

        public DetailsModel(StudentManagementContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);

            if (Course == null) return NotFound();

            return Page();
        }
    }
}
