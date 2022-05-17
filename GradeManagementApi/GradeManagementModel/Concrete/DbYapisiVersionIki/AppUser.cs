using GradeManagementModel.Abstract;
using GradeManagementModel.Concrete.DbYapisiVersionIki.Enums;
using System;

namespace GradeManagementModel.Concrete.DbYapisiVersionIki
{
    public class AppUser : IBaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AppRoles AppRoles { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}
