namespace RiseCore.Core.Settings
{
    public partial class AppSettings
    {
        public class DatabaseSettings
        {
            public DatabaseSettings(string dosetrackerSql)
            {
                DosetrackerSql = dosetrackerSql;
            }

            public string DosetrackerSql { get; set; }
        }
    }
}
