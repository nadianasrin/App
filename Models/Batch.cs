using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Models
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public List<BatchSection> ListOfBatches { get; set; }
        
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
    }
}