using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class OfficerReg
    {
        [Key]
        public string OfficerId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string OfficerEmail { get; set; }
        public string Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OfficerPassword { get; set; }
        [Required]
        [Compare("OfficerPassword", ErrorMessage = "Passwords don't match")]

        public string OfficerConfirmPassword { get; set; }
    }
}