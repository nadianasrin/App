using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class BatchSection
    {
        [Key]
        public int BatchSectioId { get; set; }

        public string BatchId { get; set; }
        public string SectionId { get; set; }

        public Batch Batches { get; set; }
        public Section Sections { get; set; }
    }
}