
using RiseCoreApi.Core.Settings.Global;
using System;
using System.IO;
using System.Text;

namespace GT.Core.Settings.Global
{
    public partial class GlobalAppSettings
    {
        private static GlobalAppSettings globalSettings;
        public static GlobalAppSettings GetCurrent()
        {
            if (globalSettings == null)
            {
                globalSettings = new GlobalAppSettings();
            }
            return globalSettings;
        }
        //CONSTANT
        public WebAppSetting WebAppSettings { get; set; }
        public FilePathSettings FilePathSetting { get; set; }

        private GlobalAppSettings()
        {
            WebAppSettings = new WebAppSetting();
            FilePathSetting = new FilePathSettings();
        }
    }
}
