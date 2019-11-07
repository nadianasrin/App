using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }
        
        [Required]
        public string StudentVarsityId { get; set; }

        [Required]
        public string StudentFullName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string RegUserEmail { get; set; }

        [Required, DataType(DataType.Password)]
        public string RegUserPassword { get; set; }
    }
}