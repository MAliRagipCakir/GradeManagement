using System.ComponentModel.DataAnnotations;

namespace GradeManagementModel.DTOs
{
    public class PostStudentGradeDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public int MidTerm { get; set; }
        public int Final { get; set; }
    }
}
