using GradeManagementData.Concrete.Context;
using GradeManagementData.EntityFramework.Abstract;
using GradeManagementModel.Concrete;

namespace GradeManagementData.EntityFramework.Concrete
{
    public class StudentGradeRepository : BaseRepository<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(GradeManageDbContext context) : base(context)
        {
        }
    }
}
