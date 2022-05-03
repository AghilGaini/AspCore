using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.MockData.Repository
{
    public class StudentRepository : GenericRepository<StudentDomain>, IStudentRepositroy
    {
        public StudentRepository()
        {
            _myList = new List<StudentDomain>() {
                new StudentDomain() { Id = 1, Name = "aghil", NationalCode = "0371046041", Age = 20 },
                new StudentDomain() { Id = 2, Name = "ali", NationalCode = "0371046042", Age = 21 },
                new StudentDomain() { Id = 3, Name = "payam", NationalCode = "0371046043", Age = 22 },
                new StudentDomain() { Id = 4, Name = "mehdi", NationalCode = "0371046044", Age = 23 }
            };

        }

        public bool IsDuplicateNationalCode(StudentDomain studentDomain)
        {
            return _myList.Any(r => r.Id != studentDomain.Id && r.NationalCode == studentDomain.NationalCode);
        }

        public new StudentDomain GetByID(long id)
        {
            return _myList.FirstOrDefault(r => r.Id == id);
        }

        public new void Update(StudentDomain entry)
        {
            var old = _myList.FirstOrDefault(r => r.Id == entry.Id);
            if (old != null)
            {
                old.Age = entry.Age;
                old.Name = entry.Name;
                old.NationalCode = entry.NationalCode;
            }
            return;
        }
    }
}
