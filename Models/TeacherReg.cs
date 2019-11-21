using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class TeacherReg
    {
        [Key]
        public string TeacherId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string TeacherEmail { get; set; }
        public string Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string TeacherPassword { get; set; }
        [Required]
        [Compare("TeacherPassword", ErrorMessage = "Passwords don't match")]

        public string TeacherConfirmPassword { get; set; }
    }
}