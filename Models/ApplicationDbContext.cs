using app.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Batch> Batch { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<BatchSection> BatchSection { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<OfficerReg> OfficerReg { get; set; }
        public DbSet<Officer> Officer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Implement Many to many relationship with student and course
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
            
            builder.Entity<BatchSection>().HasKey(sc => new
            {
                sc.BatchId,
                sc.SectionId
            });
            
            // Implement Many to many relationship with sections and batches
            builder.Entity<BatchSection>()
                .HasOne(stu => stu.Batches)
                .WithMany(enr => enr.ListOfBatches)
                .HasForeignKey(f => f.BatchId);
            
            builder.Entity<BatchSection>()
                .HasOne(cls => cls.Sections)
                .WithMany(enr => enr.ListOfSections)
                .HasForeignKey(f => f.SectionId);
        }
    }
}