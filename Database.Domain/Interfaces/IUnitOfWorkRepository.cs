using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        ICityRepository _cityRepository { get; }
        IPermisionRepository _permisionRepository { get; }
        IRolePermisionRepository _rolePermisionRepository { get; }
        IStudentRepositroy _studentRepositroy { get; }
        ICourseRepository _courseRepository { get; }
        IStudentCourseRepository _studentCourseRepository { get; }
        IVwUserRolePermisionRepository _vwUserRolePermisionRepository { get; }
        void Complete();
    }
}
