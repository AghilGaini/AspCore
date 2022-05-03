using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.MockData.Repository
{
    public class StudentCourseRepository : GenericRepository<StudentCourseDomain>, IStudentCourseRepository
    {
        public List<StudentCourseDomain> GetByStudentId(long studentId)
        {
            return _myList.Where(x => x.StudentId == studentId).ToList();
        }

        public new void Add(StudentCourseDomain studentCourseDomain)
        {

            var id = _myList.Count() != 0 ? _myList.Max(r => r.Id) + 1 : 1;
            studentCourseDomain.Id = id;
            _myList.Add(studentCourseDomain);
        }

        public long GetMaxId()
        {
            return _myList.Max(r => r.Id);
        }
    }
}
