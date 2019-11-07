using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public Registration Registration { get; set; }
        [Required]
        public Semester Semester { get; set; }
        public List<Enrollment> ListOfEnrollmentStudent { get; set; }

    }
}