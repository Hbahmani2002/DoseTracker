using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using static RiseCore.Core.Settings.AppSettings;

namespace RiseCore.Common
{
    public class AppSettings
    {
        private const string SettingsFilePath = "appsettings.json";

        private static AppSettings _AppSettings;
        public static AppSettings GetCurrent()
        {
            if (_AppSettings == null)
            {
                lock (SettingsFilePath)
                {
                    if (_AppSettings == null)
                    {
                        try
                        {
                            var file = File.ReadAllText(SettingsFilePath, Encoding.UTF8);
                            var model = new
                            {
                                ConnectionStrings = new
                                {
                                    MySql = "",
                                }
                            };
                            model = JsonConvert.DeserializeAnonymousType(file, model);
                            if (model == null || model.ConnectionStrings == null)
                            {
                                throw new Exception("model boş");
                            }
                            _AppSettings = new AppSettings(model.ConnectionStrings.MySql);
                            //LoadSettings_Alpha()
                            //LoadSettings_Beta()
                        }
                        catch (Exception ex)
                        {
                            _AppSettings = new AppSettings();
                            _AppSettings.ConfigFileException = ex.ToString();
                            var msg = $"{SettingsFilePath} dosaysından global ayarlar çekilmedi";
                            Debug.WriteLine(msg);
                            Debug.WriteLine(ex);

                        }
                    }
                }
            }
            return _AppSettings;


        }
        public DatabaseSettings DatabaseSetting { get; }
        private AppSettings()
        {
            DatabaseSetting = new DatabaseSettings("server=85.95.242.214\\SQLSERVER2014;user=sa;password=Protek2020!!;database=dosetracker;Connection Timeout=30;");
        }

        private AppSettings(string sql)
        {
            SqlCon1 = sql;
        }
        public bool IsFromConfigFile { get; set; }
        public string ConfigFileException { get; set; }
        public Exception LastException { get; set; }
        public string SqlCon1 { get; }
    }
}
