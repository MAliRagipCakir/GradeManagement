using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradeManagementModel.Concrete.DbYapisiVersionIki
{
    public class Student
    {
        [Required]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<TeacherStudentGrade> TeacherStudentGrades { get; set; }
    }
}
