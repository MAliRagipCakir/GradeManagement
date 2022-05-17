using GradeManagementModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradeManagementModel.Concrete.DbYapisiVersionIki
{
    public class Branch : IBaseEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
