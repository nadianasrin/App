using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Semester
    {
        [Key]
        public string SemesterId { get; set; }
        public string SemesterName { get; set; }
        public bool IsActiveForm { get; set; }
        public bool IsActiveCourseSuggestion { get; set; }
        public List<Enrollment> ListOfEnrollmentSemester { get; set; }
    }
}