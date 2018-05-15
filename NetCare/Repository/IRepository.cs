using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCare.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

        List<T> GetAll();
        T GetById(object Id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(Object Id);
        void Save();
    }
}