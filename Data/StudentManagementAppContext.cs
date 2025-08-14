using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Models;

namespace StudentManagementApp.Data
{
    public class StudentManagementAppContext : DbContext
    {
        public StudentManagementAppContext (DbContextOptions<StudentManagementAppContext> options)
            : base(options)
        {
        }

        public DbSet<StudentManagementApp.Models.Student> Student { get; set; } = default!;
        public DbSet<StudentManagementApp.Models.Course> Course { get; set; } = default!;
    }
}
