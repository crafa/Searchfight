using System;
using System.Configuration;

namespace SearchChallenge.engine.Config
{
    public class ReadConfig
    {
        public static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key];

                if (string.IsNullOrEmpty(result))
                    throw new ConfigurationErrorsException(string.Format("The value for {0} was not found in the configuration file", key));

                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return "";
            }
        }
    }
}
