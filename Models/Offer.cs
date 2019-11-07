using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public string OfferSection { get; set; }
        public string OfferCourse { get; set; }
    }
}