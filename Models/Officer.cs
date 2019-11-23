using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using app.Models;

namespace App.Models
{
    public class Officer
    {
        [Key]
        public int SerialId  { get; set; }
        public OfficerReg OfficerReg { get; set; }
        public Semester OfficerSemester { get; set; }
        public List<Enrollment> ListOfEnrollmentStudent { get; set; }
    }
}