using NetCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NetCare.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private JacEntities _entities;

        public Repository()
        {
            this._entities = new JacEntities();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }
        public List<T> GetAll()
        {
            return _entities.Set<T>().ToList();
        }

        public T GetById(object Id)
        {
            return _entities.Set<T>().Find(Id);
        }

        public void Insert(T obj)
        {
            _entities.Set<T>().Add(obj);
        }
        public void Update(T obj)
        {
            _entities.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(object Id)
        {
            T getObjById = _entities.Set<T>().Find(Id);
            _entities.Set<T>().Remove(getObjById);
        }
        public void Save()
        {
            _entities.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._entities != null)
                {
                    this._entities.Dispose();
                    this._entities = null;
                }
            }
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}