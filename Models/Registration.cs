using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }
        
        [Required]
        [RegularExpression(@"([0-9])([0-9])([0-9])-([0-9])([0-9])-[0-9]+", ErrorMessage = "Incorrect DIU Student ID")]
        public string StudentVarsityId { get; set; }

        [Required]
        [MaxLength(25)]
        public string StudentFullName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w.+\-]+([0-9])([0-9])-[0-9]+@diu.edu.bd$" ,ErrorMessage = "Use DIU email format")]
        public string RegUserEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string RegUserPassword { get; set; }
        [Required]
        [Compare("RegUserPassword", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}