using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Models;
using System.Threading.Tasks;

namespace StudentManagementApp.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly StudentManagementContext _context;

        public DetailsModel(StudentManagementContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Student = await _context.Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null) return NotFound();

            return Page();
        }
    }
}
