using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [Required]
        public string LoginUserId { get; set; }
        [Required, DataType(DataType.Password)]
        public string LoginUserPassword { get; set; }
    }
}