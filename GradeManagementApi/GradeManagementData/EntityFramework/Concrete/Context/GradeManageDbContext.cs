using GradeManagementModel.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace GradeManagementData.Concrete.Context
{
    public class GradeManageDbContext : DbContext
    {
        public GradeManageDbContext(DbContextOptions<GradeManageDbContext> options) : base(options)
        {

        }

        public DbSet<StudentGrade> StudentGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentGrade>().HasData(
                new StudentGrade() { Id = Guid.NewGuid(), FirstName = "Stevie", LastName = "Wonder", MidTerm = 42, Final = 35 },
                new StudentGrade() { Id = Guid.NewGuid(), FirstName = "David", LastName = "Bowie", MidTerm = 45, Final = 45 },
                new StudentGrade() { Id = Guid.NewGuid(), FirstName = "Robert", LastName = "Plant", MidTerm = 70, Final = 83 },
                new StudentGrade() { Id = Guid.NewGuid(), FirstName = "Elton", LastName = "John", MidTerm = 90, Final = 95 },
                new StudentGrade() { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Marley", MidTerm = 8, Final = 99 }
                );
        }
    }
}
