using System;
using System.Linq;
using System.Linq.Expressions;

namespace RiseCore.PERSISTANCE
{
    public abstract class AbstractWorkspace :  IAbstractWorkspace
    {
        public abstract IQueryable<T> Query<T>(Expression<Func<T, bool>> predictate = null) where T : class;
        public abstract T Single<T>(Expression<Func<T, bool>> expression = null) where T : class;
        public abstract T Last<T>(Expression<Func<T, bool>> expression = null) where T : class;
        public abstract int Count<T>() where T : class;
        public abstract void CommitChanges();
        public abstract void Add<T>(T item) where T : class;
        public abstract void Update<T>(T item) where T : class;
        public abstract void Delete<T>(T item) where T : class;
        public abstract void Dispose();        
    }
}