using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradeManagementModel.Concrete.DbYapisiVersionIki
{
    public class Teacher
    {
        [Required]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        [Required]
        public string BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<TeacherStudentGrade> TeacherStudentGrades { get; set; }
    }
}
