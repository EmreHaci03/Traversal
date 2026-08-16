using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;

namespace Traversal.DataAccessLayer.Repository
{
    public class GenericRepository<T>:IGenericDal<T> where T:class
    {
        private readonly TraversalContext _traversalContext;

        public GenericRepository(TraversalContext traversalContext)
        {
            _traversalContext = traversalContext;
        }

        public void Delete(T entity)
        {
            _traversalContext.Remove<T>(entity);
            _traversalContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _traversalContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _traversalContext.Set<T>().Find(id);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _traversalContext.Set<T>().Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            _traversalContext.Set<T>().Add(entity);
            _traversalContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _traversalContext.Set<T>().Update(entity);
            _traversalContext.SaveChanges();
        }
    }
}
