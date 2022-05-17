using System.ComponentModel.DataAnnotations;

namespace GradeManagementModel.Concrete.DbYapisiVersionIki
{
    public class TeacherStudentGrade
    {
        private string _branchName;

        [Required]
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public string BranchName
        {
            get
            {
                return _branchName;
            }
            private set
            {
                _branchName = Teacher.Branch.Name;
            }
        }

        [Required]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }


        public int MidTerm { get; set; }
        public int Final { get; set; }
    }
}
