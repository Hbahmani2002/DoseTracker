
using RiseCore.PERSISTANCE;
using RiseCore.PERSISTANCE.Data.Text;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Rise.Core.Persistance
{
    public class TextFileWorkspace : AbstractWorkspace
    {
        private DataStorage _storage = new DataStorage();
        private readonly string _fileName;
        private readonly bool _asyncSave;

        public TextFileWorkspace()
            : this(GetDefaultDbFileName(), false)
        {

        }
        public TextFileWorkspace(string fileName, bool asyncSave)
        {
            _fileName = fileName;
            _asyncSave = asyncSave;

        }
        private static string GetDefaultDbFileName()
        {
            return Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + "\\METLIBDB.txt";
        }
        public override void CommitChanges()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<T> Query<T>(Expression<Func<T, bool>> predictate)
        {
            throw new NotImplementedException();
        }

        public override T Single<T>(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public override T Last<T>(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public override int Count<T>()
        {
            throw new NotImplementedException();
        }

        public override void Add<T>(T item)
        {
            throw new NotImplementedException();
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
