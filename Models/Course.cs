using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string LecturerName { get; set; }
    }
}
