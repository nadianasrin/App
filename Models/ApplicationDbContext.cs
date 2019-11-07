using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Student> Student { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Enrollment>().HasKey(sc => new
            {
                sc.EnrollStudentId,
                sc.EnrollCourseId
            });

            builder.Entity<Enrollment>()
                .HasOne(stu => stu.EnrollStudents)
                .WithMany(enr => enr.ListOfEnrollmentStudent)
                .HasForeignKey(f => f.EnrollStudentId);
            
            builder.Entity<Enrollment>()
                .HasOne(cls => cls.EnrollCourses)
                .WithMany(enr => enr.ListOfEnrollmentCourse)
                .HasForeignKey(f => f.EnrollCourseId);
        }
    }
}