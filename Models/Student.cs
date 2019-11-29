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
        
        public Course Course { get; set; }
        public Semester Semester { get; set; }
        public Batch Batch { get; set; }
        public Section Section { get; set; }

        [NotMapped] 
        public List<SelectListItem> Batches { get; } = new List<SelectListItem>();
        [NotMapped]
        public List<SelectListItem> Sections { get; }  = new List<SelectListItem>();
        [NotMapped]
        public List<SelectListItem> Semesters { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value = "s1", Text = "Semester 1"},
            new SelectListItem{Value = "s2", Text = "Semester 2"},
            new SelectListItem{Value = "s3", Text = "Semester 3"},
            new SelectListItem{Value = "s4", Text = "Semester 4"},
            new SelectListItem{Value = "s5", Text = "Semester 5"},
            new SelectListItem{Value = "s6", Text = "Semester 6"},
            new SelectListItem{Value = "s7", Text = "Semester 7"},
            new SelectListItem{Value = "s8", Text = "Semester 8"},
            new SelectListItem{Value = "s9", Text = "Semester 9"},
            new SelectListItem{Value = "s10", Text = "Semester 10"},
            new SelectListItem{Value = "s11", Text = "Semester 11"},
            new SelectListItem{Value = "s12", Text = "Semester 12"}
        };
        
        
        [NotMapped]
        public List<Enrollment> ListOfEnrollmentStudent { get; set; }

    }
}