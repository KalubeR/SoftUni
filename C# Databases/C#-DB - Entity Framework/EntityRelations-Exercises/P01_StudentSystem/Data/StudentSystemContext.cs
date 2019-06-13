using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingEntityStudent(modelBuilder);

            OnModelCreatingEntityCourse(modelBuilder);

            OnModelCreatingEntityResource(modelBuilder);

            OnModelCreatingEntityStudentCourse(modelBuilder);
        }

        private void OnModelCreatingEntityStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity
                    .Property(s => s.Name)
                    .HasMaxLength(100)
                    .IsUnicode()
                    .IsRequired();

                entity
                    .HasMany(s => s.HomeworkSubmissions)
                    .WithOne(s => s.Student);
            });
        }

        private void OnModelCreatingEntityCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity
                    .HasKey(c => c.CourseId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsUnicode();

                entity
                    .Property(c => c.Description)
                    .IsUnicode();

                entity
                    .HasMany(c => c.Resources)
                    .WithOne(c => c.Course);

                entity
                    .HasMany(c => c.HomeworkSubmissions)
                    .WithOne(c => c.Course);
            });
        }

        private void OnModelCreatingEntityResource(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Resource>(entity =>
                {
                    entity
                        .Property(r => r.Name)
                        .HasMaxLength(50)
                        .IsUnicode();
                });
        }

        private void OnModelCreatingEntityStudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StudentCourse>(entity =>
                {
                    entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                    entity
                        .HasOne(sc => sc.Student)
                        .WithMany(sc => sc.CourseEnrollments)
                        .HasForeignKey(sc => sc.StudentId);

                    entity
                        .HasOne(sc => sc.Course)
                        .WithMany(sc => sc.StudentsEnrolled)
                        .HasForeignKey(sc => sc.CourseId);
                });
        }
    }
}