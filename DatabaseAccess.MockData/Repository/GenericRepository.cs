using Database.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.MockData.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public virtual List<T> _myList { get; set; }

        public GenericRepository()
        {
            _myList = new List<T>();
        }

        public void Add(T entity)
        {
            _myList.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _myList.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _myList.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _myList;
        }

        public T GetByID(long id)
        {
            //TODO
            return _myList.FirstOrDefault();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            //TODO
            return;
        }

        public void Update(T entity)
        {
            //TODO
            var t = _myList.FirstOrDefault(r => r == entity);
            if (t != null)
                return;
            return;
        }
    }
}
