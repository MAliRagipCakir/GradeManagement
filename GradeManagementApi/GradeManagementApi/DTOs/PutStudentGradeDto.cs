using System.ComponentModel.DataAnnotations;

namespace GradeManagementApi.DTOs
{
    public class PutStudentGradeDto
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public int MidTerm { get; set; }
        public int Final { get; set; }
    }
}
