using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EFCore.Repositories
{
    public class CityRepository : GenericRepository<CityDomain>, ICityRepository
    {
        private readonly ApplicationContext _context;

        public CityRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }
    }
}
