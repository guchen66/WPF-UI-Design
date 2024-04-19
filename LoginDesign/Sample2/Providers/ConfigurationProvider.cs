using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2.Providers
{
    public class ConfigurationProvider
    {
        public static ExeConfigurationFileMap init()
        {

            ExeConfigurationFileMap configurationFileMap = new ExeConfigurationFileMap();
            configurationFileMap.ExeConfigFilename = "App.config";

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration
                                                     (configurationFileMap, ConfigurationUserLevel.None);

            AppSettingsSection section = (AppSettingsSection)config.GetSection("connectionString");
            return configurationFileMap;
        }
    }
}
