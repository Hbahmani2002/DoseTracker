using MEDLIFE.PERSISTANCE;
using RiseCore.PERSISTANCE;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MEDLIFE.PERSISTANCE.Data.SQL
{
    public class ReadOnlyEFWorkspace : AbstractWorkspace
    {
        private readonly CommonDbContext _context;

        public ReadOnlyEFWorkspace(CommonDbContext context)
        {
            _context = context;
        }

        public override void Add<T>(T item)
        {
            throw new NotImplementedException();
        }

        public override void CommitChanges()
        {
            throw new NotImplementedException();
        }

        public override int Count<T>() 
        {
            return 0;
        }

        public override T Last<T>(Expression<Func<T, bool>> expression)
        {
            return null;
        }

        public override IQueryable<T> Query<T>(Expression<Func<T, bool>> predictate=null)
        {

            if (predictate == null)
                predictate = o => true;
            return _context
                .Set<T>()
                .Where(predictate);
                //.AsNoTracking();
        }

        public override T Single<T>(Expression<Func<T, bool>> expression)
        {            
            return _context.Set<T>().SingleOrDefault(expression);
        }

        public override void Update<T>(T item)
        {
            throw new NotImplementedException();
        }

        public override void Delete<T>(T item)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}