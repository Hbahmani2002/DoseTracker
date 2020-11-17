using Gt.PERSISTANCE;
using MEDLIFE.PERSISTANCE.Data;
using MEDLIFE.PERSISTANCE.Data.SQL;
using MEDLIFE.PERSISTANCE.DOMAIN.Models;
using Rise.Core.Persistance;
using RiseCore.PERSISTANCE;
using RiseCore.PERSISTANCE.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseCore.PERSISTANCE
{
    public class WorkspaceFactory
    {
        private static TextFileWorkspace _textFileWorkspace;
        private static string _connectionString;
        public static void UpdateConnection(string connectionString)
        {
            _connectionString = connectionString;
          //  Database.SetInitializer(new DataInitializer());

            if (string.IsNullOrEmpty(_connectionString))
            {
                //    if (LocalSettings.IsSqlce40Installed())
                //        _connectionString = string.Format("data source={0}\\{1}.sdf", LocalSettings.DocumentPath, LocalSettings.AppName);
                //    else _connectionString = GetTextFileName();
            }
            //if (_connectionString.EndsWith(".sdf"))
            //{
            //    if (!_connectionString.ToLower().Contains("data source") && !_connectionString.Contains(":\\"))
            //        _connectionString = string.Format("data source={0}\\{1}", LocalSettings.DocumentPath, _connectionString);

            //    Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "", _connectionString);
            //}
            else if (_connectionString.EndsWith(".txt"))
            {
                _textFileWorkspace = GetTextFileWorkspace();
            }
            //else if (!string.IsNullOrEmpty(_connectionString))
            //{
            //    var cs = _connectionString;
            //    if (!cs.Trim().EndsWith(";"))
            //        cs += ";";
            //    if (!cs.ToLower().Contains("multipleactiveresultsets"))
            //        cs += " MultipleActiveResultSets=True;";
            //    if (!cs.ToLower(CultureInfo.InvariantCulture).Contains("user id") &&
            //        (!cs.ToLower(CultureInfo.InvariantCulture).Contains("integrated security")))
            //        cs += " Integrated Security=True;";
            //    if (cs.ToLower(CultureInfo.InvariantCulture).Contains("user id") &&
            //        !cs.ToLower().Contains("persist security info"))
            //        cs += " Persist Security Info=True;";
            //    Database..DefaultConnectionFactory = new SqlConnectionFactory(cs);
            //}
        }


        public static AbstractWorkspace Create(bool log = false)
        {
            var dc = new DataContext(true);
            //dc.Configuration.ValidateOnSaveEnabled = false;
            return new WritableEFWorkspace(dc);
        }

        public static AbstractWorkspace CreateReadOnly(bool log = false)
        {
            var dc = new DataContext(true);
            return new ReadOnlyEFWorkspace(dc);
        }
        private static string GetTextFileName()
        {
            return _connectionString.EndsWith(".txt")
                ? _connectionString
                : string.Format("{0}\\{1}.txt", LocalSettings.DocumentPath, LocalSettings.AppName);
        }
        private static TextFileWorkspace GetTextFileWorkspace()
        {
            var fileName = GetTextFileName();
            return new TextFileWorkspace(fileName, false);
        }
    }

    //public class DataInitializer : IDatabaseInitializer<DataContext>
    //{

    //    public void InitializeDatabase(DataContext context)
    //    {
    //        return;
    //        if (!context.Database.Exists())
    //        {
    //            Create(context);
    //        }
    //        //#if DEBUG
    //        //            else if (!context.Database.CompatibleWithModel(false))
    //        //            {
    //        //                context.Database.Delete();
    //        //                Create(context);
    //        //            }
    //        //#else
    //        else
    //        {
    //            Migrate(context);
    //        }
    //        //#endif
    //        //var version = context.ObjContext().ExecuteStoreQuery<long>("select top(1) Version from VersionInfo order by version desc").FirstOrDefault();
    //        //LocalSettings.CurrentDbVersion = version;
    //    }

    //    private static void Create(CommonDbContext context)
    //    {
    //        return;
    //        //context.Database.Create();
    //        //context.ObjContext().ExecuteStoreCommand("CREATE TABLE VersionInfo (Version bigint not null)");
    //        //context.ObjContext().ExecuteStoreCommand("CREATE NONCLUSTERED INDEX IX_Tickets_LastPaymentDate ON Tickets(LastPaymentDate)");
    //        //context.ObjContext().ExecuteStoreCommand("CREATE UNIQUE INDEX IX_EntityStateValue_EntityId ON EntityStateValues (EntityId)");
    //        //context.ObjContext().SaveChanges();
    //        //GetMigrateVersions(context);
    //        //LocalSettings.CurrentDbVersion = LocalSettings.DbVersion;
    //    }

    //    private static void GetMigrateVersions(CommonDbContext context)
    //    {
    //        //for (var i = 0; i < LocalSettings.DbVersion; i++)
    //        //{
    //        //    context.ObjContext().ExecuteStoreCommand("Insert into VersionInfo (Version) Values (" + (i + 1) + ")");
    //        //}
    //    }

    //    private static void Migrate(CommonDbContext context)
    //    {
    //        //if (!File.Exists(LocalSettings.UserPath + "\\migrate.txt")) return;

    //        //var preVersion = context.ObjContext().ExecuteStoreQuery<long>("select top(1) Version from VersionInfo order by version desc").FirstOrDefault();
    //        //var db = context.Database.Connection.ConnectionString.Contains(".sdf") ? "sqlserverce" : "sqlserver";
    //        //if (preVersion < 18 && db == "sqlserverce") ApplyV16Fix(context);

    //        //IAnnouncer announcer = new TextWriterAnnouncer(Console.Out);

    //        //IRunnerContext migrationContext =
    //        //    new RunnerContext(announcer)
    //        //    {
    //        //        ApplicationContext = context,
    //        //        Connection = context.Database.Connection.ConnectionString,
    //        //        Database = db,
    //        //        Target = LocalSettings.AppPath + "\\Samba.Persistance.DbMigration.dll"
    //        //    };

    //        //new TaskExecutor(migrationContext).Execute();

    //        //File.Delete(LocalSettings.UserPath + "\\migrate.txt");
    //    }
 
    //}
}
