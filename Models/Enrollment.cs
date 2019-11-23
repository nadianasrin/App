using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public Semester Semester { get; set; }
        public bool IsRetakeCourse { get; set; }
        public string Batch { get; set; }
        public string Section { get; set; }
        public int SectionCapacity { get; set; }
        
        [NotMapped]
        public List<SelectListItem> Batches = new List<SelectListItem>
        {
            new SelectListItem{Value = "batch20", Text = "Batch 20"},
            new SelectListItem{Value = "batch21", Text = "Batch 21"},
            new SelectListItem{Value = "batch22", Text = "Batch 22"},
            new SelectListItem{Value = "batch23", Text = "Batch 23"},
            new SelectListItem{Value = "batch24", Text = "Batch 24"},
            new SelectListItem{Value = "batch25", Text = "Batch 25"},
            new SelectListItem{Value = "batch26", Text = "Batch 26"},
            new SelectListItem{Value = "batch27", Text = "Batch 27"},
            new SelectListItem{Value = "batch28", Text = "Batch 28"},
            new SelectListItem{Value = "batch29", Text = "Batch 29"},
            new SelectListItem{Value = "batch30", Text = "Batch 30"}
        };
        
        [NotMapped]
        public List<SelectListItem> Sections = new List<SelectListItem>
        {
            new SelectListItem{Value = "A", Text = "A"},
            new SelectListItem{Value = "B", Text = "B"}
        };
    }
}