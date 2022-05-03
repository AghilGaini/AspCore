using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DatabaseAccess.EFCore.Repositories
{
    public class CourseRepository : GenericRepository<CourseDomain>, ICourseRepository
    {
        private readonly ApplicationContext _context;

        public CourseRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public List<CourseDomain> GetByIDs(List<long> ids)
        {
            return _context.Courses.Where(c => ids.Contains(c.Id)).ToList();
        }

        public bool IsDuplicateTitle(CourseDomain course)
        {
            return _context.Courses.Where(r => r.Title == course.Title && r.Id != course.Id).Any();
        }
    }
}
