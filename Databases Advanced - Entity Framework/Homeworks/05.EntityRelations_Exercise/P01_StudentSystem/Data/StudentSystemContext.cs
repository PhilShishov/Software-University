
namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnConfiguringStudent(modelBuilder);

            OnConfiguringCourse(modelBuilder);

            OnConfiguringResource(modelBuilder);

            OnConfiguringHomework(modelBuilder);

            OnConfiguringStudentCourse(modelBuilder);

        }

        private void OnConfiguringStudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<StudentCourse>(studentCourse =>
                    {
                        studentCourse
                            .HasKey(sc => new { sc.StudentId, sc.CourseId });

                        studentCourse
                            .HasOne(sc => sc.Student)
                            .WithMany(s => s.CourseEnrollments)
                            .HasForeignKey(sc => sc.StudentId);

                        studentCourse
                            .HasOne(sc => sc.Course)
                            .WithMany(c => c.StudentsEnrolled)
                            .HasForeignKey(sc => sc.CourseId);
                    });
        }

        private void OnConfiguringHomework(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<Homework>(homework =>
                    {
                        homework
                            .HasKey(h => h.HomeworkId);

                        homework
                            .Property(h => h.Content)
                            .IsRequired();

                        homework
                           .HasOne(h => h.Student)
                           .WithMany(s => s.HomeworkSubmissions);

                        homework
                           .HasOne(h => h.Course)
                           .WithMany(c => c.HomeworkSubmissions);
                    });
        }

        private void OnConfiguringResource(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<Resource>(resource =>
                    {
                        resource
                            .HasKey(r => r.ResourceId);

                        resource
                            .Property(r => r.Name)
                            .HasMaxLength(50)
                            .IsUnicode()
                            .IsRequired();

                        resource
                        .Property(r => r.Url)
                        .IsRequired();

                        resource
                        .HasOne(r => r.Course)
                        .WithMany(c => c.Resources);
                    });
        }

        private void OnConfiguringCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<Course>(course =>
                    {
                        course
                            .HasKey(c => c.CourseId);

                        course
                            .Property(c => c.Name)
                            .HasMaxLength(80)
                            .IsUnicode()
                            .IsRequired();

                        course
                            .Property(c => c.Description)
                            .IsUnicode();
                    });
        }

        private static void OnConfiguringStudent(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<Student>(student =>
                    {
                        student
                            .HasKey(s => s.StudentId);

                        student
                            .Property(s => s.Name)
                            .HasMaxLength(100)
                            .IsUnicode()
                            .IsRequired();

                        student
                        .Property(s => s.PhoneNumber)
                        .HasColumnType("CHAR(10)");

                        student
                        .Property(s => s.RegisteredOn)
                        .HasDefaultValueSql("GETDATE()");
                    });
        }
    }
}
