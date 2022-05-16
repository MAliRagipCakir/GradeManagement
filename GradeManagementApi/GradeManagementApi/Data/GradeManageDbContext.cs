using Microsoft.EntityFrameworkCore;

namespace GradeManagementApi.Data
{
    public class GradeManageDbContext : DbContext
    {
        public GradeManageDbContext(DbContextOptions<GradeManageDbContext> options) : base(options)
        {

        }

        public DbSet<StudentGrades> StudentGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentGrades>().HasData(
                new StudentGrades() { Id = 1, FirstName = "Stevie", LastName = "Wonder", MidTerm = 42, Final = 35 },
                new StudentGrades() { Id = 2, FirstName = "David", LastName = "Bowie", MidTerm = 45, Final = 45 },
                new StudentGrades() { Id = 3, FirstName = "Robert", LastName = "Plant", MidTerm = 70, Final = 83 },
                new StudentGrades() { Id = 4, FirstName = "Elton", LastName = "John", MidTerm = 90, Final = 95 },
                new StudentGrades() { Id = 5, FirstName = "Bob", LastName = "Marley", MidTerm = 8, Final = 99 }
                );
        }
    }
}
