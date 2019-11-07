using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int EnrollStudentId { get; set; }
        public Student EnrollStudents { get; set; }
        public int EnrollCourseId { get; set; }
        public Course EnrollCourses { get; set; }
        public bool IsRetakeCourse { get; set; }
        public string Batch { get; set; }
        public string Section { get; set; }
    }
}