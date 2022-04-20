using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EFCore.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ApplicationContext _context;

        public ICityRepository _cityRepository { get; set; }

        public IPermisionRepository _permisionRepository { get; set; }

        public UnitOfWorkRepository(ApplicationContext context)
        {
            this._context = context;
            _cityRepository = new CityRepository(context);
            _permisionRepository = new PermisionRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
