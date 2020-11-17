using System;
using System.Linq;
using System.Linq.Expressions;

namespace RiseCore.PERSISTANCE
{
    public interface IAbstractWorkspace: IDisposable
    {
        void Add<T>(T item) where T : class;
        void CommitChanges();
        int Count<T>() where T : class;
        void Delete<T>(T item) where T : class;       
        T Last<T>(Expression<Func<T, bool>> expression = null) where T : class;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> predictate = null) where T : class;
        T Single<T>(Expression<Func<T, bool>> expression = null) where T : class;
        void Update<T>(T item) where T : class;
    }
}