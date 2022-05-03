using Database.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface ICourseRepository : IGenericRepository<CourseDomain>
    {
        bool IsDuplicateTitle(CourseDomain course);
        List<CourseDomain> GetByIDs(List<long> ids);
    }
}
