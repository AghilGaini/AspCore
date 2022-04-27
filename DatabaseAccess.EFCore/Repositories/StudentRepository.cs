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
        public StudentRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
