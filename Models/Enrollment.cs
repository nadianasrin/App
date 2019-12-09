using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int EnrollStudentId { get; set; }
        public Student EnrollStudents { get; set; }
        public int EnrollCourseId { get; set; }
        public Course EnrollCourses { get; set; }
        public Semester EnrolledSemester { get; set; }
        public Batch EnrolledBatch { get; set; }
        public Section EnrolledSection { get; set; }
        public bool IsRetakeCourse { get; set; }
    }
}