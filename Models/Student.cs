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
        public Semester Semester { get; set; }
        public Batch Batch { get; set; }
        public Section Section { get; set; }
        
        [NotMapped]
        public List<SelectListItem> Batches { get; } = new List<SelectListItem>();
        [NotMapped]
        public List<SelectListItem> Sections { get; } = new List<SelectListItem>();
        public List<Enrollment> ListOfEnrollmentStudent { get; set; }

    }
}