using MEDLIFE.PERSISTANCE.Data.SQL;
using RiseCore.PERSISTANCE;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MEDLIFE.PERSISTANCE.Data
{
    public class WritableEFWorkspace : AbstractWorkspace
    {
        private readonly CommonDbContext _context;

        public WritableEFWorkspace(CommonDbContext context)
        {
            _context = context;
        }

        public override void Add<T>(T item)
        {
            _context.Set<T>().Add(item);
        }

        public override void CommitChanges()
        {
            _context.SaveChanges();
        }

        public override int Count<T>()
        {
            throw new NotImplementedException();
        }

        public override T Last<T>(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<T> Query<T>(Expression<Func<T, bool>> predictate)
        {
            if (predictate == null)
            {
                predictate = o => true;
            }
            return _context.Set<T>().Where(predictate);
        }

        public override T Single<T>(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }

        public override void Dispose()
        {
            _context.Dispose();
        }

        public override void Delete<T>(T item) 
        {
            _context.Set<T>().Remove(item);
        }
        public override void Update<T>(T item)
        {
            //_context.Set<T>().Add(item);
        }
        public void SetIdentityInsert(string tableName, bool enabled)
        {
            var enabledCommand = enabled ? "ON" : "OFF";
           // _context.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT [dbo].[{tableName}] {enabledCommand}");
        }
        //public int ExecutQuery<T>(string sqlText, params object[] parameters)
        //{
        //    //var enabledCommand = enabled ? "ON" : "OFF";
        //    return _context.Database.ExecuteSqlRaw(sqlText, parameters);
        //}
    }
}