using Gt.PERSISTANCE;
using RiseCore.PERSISTANCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GT.REPOSITORY
{
    public abstract class AbstractTableRepository<T> : AbstractRepository where T : class
    {
        public AbstractTableRepository(IAbstractWorkspace workspace) : base(workspace)
        {
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> exp = null)
        {
            return Workspace.Query(exp);
        }

        public T Single(Expression<Func<T, bool>> exp)
        {
            return Workspace.Single(exp);
        }



        public void Add(T item)
        {
            Workspace.Add(item);
        }

        public void Update(T item)
        {
            Workspace.Update(item);
        }

        public void Delete(T item)
        {
            Workspace.Delete(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Workspace.Add(item);
            }

        }

        public abstract T GetByID(long id);

    }
}