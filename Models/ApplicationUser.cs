using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Student_VarsityId { get; set; }
        public string Student_FullName { get; set; }
    }
}