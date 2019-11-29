using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Models
{
    public class Batch
    {
        [Key]
        public string BatchId { get; set; }
        public string BatchName { get; set; }
        public List<BatchSection> ListOfBatches { get; set; }
    }
}