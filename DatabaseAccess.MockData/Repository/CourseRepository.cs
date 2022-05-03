using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.MockData.Repository
{
    internal class CourseRepository : GenericRepository<CourseDomain>, ICourseRepository
    {
        public CourseRepository()
        {
            _myList = new List<CourseDomain>()
            {
                new CourseDomain(){ Id =1 , Title="Math" },
                new CourseDomain(){ Id =2 , Title="Physic" }
            };
        }
        public bool IsDuplicateTitle(CourseDomain course)
        {
            return _myList.Any(r => r.Id != course.Id && r.Title == course.Title);
        }
        public new CourseDomain GetByID(long id)
        {
            return _myList.FirstOrDefault(r => r.Id == id);
        }

        public new void Update(CourseDomain entry)
        {
            var old = _myList.FirstOrDefault(r => r.Id == entry.Id);
            if (old != null)
            {
                old.Title = entry.Title;
            }
            return;
        }

        public List<CourseDomain> GetByIDs(List<long> ids)
        {
            return _myList.Where(r => ids.Contains(r.Id)).ToList();
        }
    }
}
