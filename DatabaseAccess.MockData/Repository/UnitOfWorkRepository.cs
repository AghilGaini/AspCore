using Database.Domain.Interfaces;
using DatabaseAccess.MockData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.MockData.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public ICityRepository _cityRepository { get; set; }

        public IPermisionRepository _permisionRepository { get; set; }

        public IRolePermisionRepository _rolePermisionRepository { get; set; }

        public IStudentRepositroy _studentRepositroy { get; set; }

        public ICourseRepository _courseRepository { get; set; }

        public IStudentCourseRepository _studentCourseRepository { get; set; }

        public IVwUserRolePermisionRepository _vwUserRolePermisionRepository { get; set; }
        public UnitOfWorkRepository()
        {
            _studentCourseRepository = new StudentCourseRepository();
            _studentRepositroy = new StudentRepository();
            _courseRepository = new CourseRepository();
        }

        public void Complete()
        {
            return;
        }

        public void Dispose()
        {
            return;
        }
    }
}
