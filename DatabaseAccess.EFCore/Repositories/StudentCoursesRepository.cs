using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EFCore.Repositories
{
    public class StudentCoursesRepository : GenericRepository<StudentCourseDomain>, IStudentCourseRepository
    {
        private readonly ApplicationContext _context;

        public StudentCoursesRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public List<StudentCourseDomain> GetByStudentId(long studentId)
        {
            return _context.StudentCourses.Where(c => c.StudentId == studentId).ToList();
        }
    }
}
