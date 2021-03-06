using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EFCore.Repositories
{
    public class StudentRepository : GenericRepository<StudentDomain>, IStudentRepositroy
    {
        private readonly ApplicationContext _context;

        public StudentRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public bool IsDuplicateNationalCode(StudentDomain studentDomain)
        {
            return _context.Students.Where(r => r.NationalCode == studentDomain.NationalCode && r.Id != studentDomain.Id).Any();
        }
    }
}
