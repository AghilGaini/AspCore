using Database.Domain.Entities;
using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EFCore.Repositories
{
    public class PermisionRepository : GenericRepository<PermisionDomain>, IPermisionRepository
    {
        private readonly ApplicationContext _context;

        public PermisionRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public List<PermisionDomain> GetByPermisionIds(List<long> permisionIds)
        {
            return _context.Permisions.Where(r => permisionIds.Any(x => x == r.ID)).ToList();
        }
    }
}
