using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class BatchSection
    {
        [Key]
        public int BatchSectioId { get; set; }

        public int BatchId { get; set; }
        public int SectionId { get; set; }

        public Batch Batches { get; set; }
        public Section Sections { get; set; }
    }
}