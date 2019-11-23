using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Models
{
    public class Course
    {
        [Key]           
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string SemesterNumber { get; set; }
        public string CourseTitle { get; set; }
        public int CourseCredit { get; set; }
        public Semester SemesterNo { get; set; }
        public List<Enrollment> ListOfEnrollmentCourse { get; set; }
        
        [NotMapped]
        public List<SelectListItem> SemesterNumbers = new List<SelectListItem>
        {
            new SelectListItem{Value = "Semester 1", Text = "Semester 1"},
            new SelectListItem{Value = "Semester 2", Text = "Semester 2"},
            new SelectListItem{Value = "Semester 3", Text = "Semester 3"},
            new SelectListItem{Value = "Semester 4", Text = "Semester 4"},
            new SelectListItem{Value = "Semester 5", Text = "Semester 5"},
            new SelectListItem{Value = "Semester 6", Text = "Semester 6"},
            new SelectListItem{Value = "Semester 7", Text = "Semester 7"},
            new SelectListItem{Value = "Semester 8", Text = "Semester 8"},
            new SelectListItem{Value = "Semester 9", Text = "Semester 9"},
            new SelectListItem{Value = "Semester 10", Text = "Semester 10"},
            new SelectListItem{Value = "Semester 11", Text = "Semester 11"},
            new SelectListItem{Value = "Semester 12", Text = "Semester 12"}
        };
    }
}