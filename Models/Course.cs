using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string CourseTitle { get; set; }
        [Required]
        public int CourseCredit { get; set; }
        public List<Enrollment> ListOfEnrollmentCourse { get; set; }
    }
}