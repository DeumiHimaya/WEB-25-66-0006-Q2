using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly StudentManagementContext _context;

        public IndexModel(StudentManagementContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}
