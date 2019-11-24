using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int SectionCapacity { get; set; }
        public List<BatchSection> ListOfSections { get; set; }
        
        [NotMapped]
        public List<SelectListItem> Sections = new List<SelectListItem>
        {
            new SelectListItem{Value = "A", Text = "A"},
            new SelectListItem{Value = "B", Text = "B"}
        };
    }
}