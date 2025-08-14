using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Models;

namespace StudentManagementApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentManagementContext _context;

        public IndexModel(StudentManagementContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.Course)
                .ToListAsync();
        }
    }
}
