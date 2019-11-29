using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public Registration Registration { get; set; }
        //public Course Course { get; set; }
        public Semester Semester { get; set; }
        public Batch Batch { get; set; }
        public Section Section { get; set; }
        
        [NotMapped]
        public List<SelectListItem> BatchNumber = new List<SelectListItem>
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
            new SelectListItem{Value = "batch29", Text = "Batch 29"}
        };
        [NotMapped]
        public List<SelectListItem> Sections = new List<SelectListItem>
        {
            new SelectListItem{Value = "A", Text = "A"},
            new SelectListItem{Value = "B", Text = "B"}
        };
        [NotMapped]
        public List<SelectListItem> Semesters { get; } = new List<SelectListItem>();
        
        [NotMapped]
        public List<Enrollment> ListOfEnrollmentStudent { get; set; }

    }
}