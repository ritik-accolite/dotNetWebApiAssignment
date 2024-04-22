using Microsoft.EntityFrameworkCore;

namespace StudentRestApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Ritik",
                    LastName = "Bhati",
                    Email = "ritik@gmail.com",
                    Gender = Gender.Male,
                    DepartmentId = 1
                });
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 2,
                    FirstName = "Vinay",
                    LastName = "Bhati",
                    Email = "vinay@gmail.com",
                    Gender = Gender.Male,
                    DepartmentId = 2
                });
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 3,
                    FirstName = "Rajdeep",
                    LastName = "Bhati",
                    Email = "rajdeep@gmail.com",
                    Gender = Gender.Male,
                    DepartmentId = 3
                });
        }
    }
}
