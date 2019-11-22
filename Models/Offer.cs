using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public Course DesiredCourse { get; set; }
        public Course OfferedCourse { get; set; }
    }
}