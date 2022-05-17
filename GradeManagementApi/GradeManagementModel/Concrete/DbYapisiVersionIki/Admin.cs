using System.ComponentModel.DataAnnotations;

namespace GradeManagementModel.Concrete.DbYapisiVersionIki
{
    public class Admin
    {
        [Required]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
