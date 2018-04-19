using Student.Common.Logic.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.UtilsConfig
{
    public static class UtilsConfiguration
    {
        public static readonly ILogger Log = UtilsConfiguration.InstanceLog(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        public static ILogger InstanceLog(Type TypeDeclaring)
        {
            Log.Debug("");
            try
            {
                var key = ConfigurationManager.AppSettings["LogType"];

                object[] Params = { TypeDeclaring };
                Type t = Assembly.GetExecutingAssembly().GetType(key);

                return (ILogger)Activator.CreateInstance(t, Params);
            }
            catch (Exception ex )
            {
                Log.Error(ex );
                throw;
            }
            
        }

        public static void ChangeLogConfig(string classLog)
        {
            try
            {
                
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["LogType"].Value = classLog;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("LogType");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        
        }

        public static void ChangeLanguageConfig(string language)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Language"].Value = language;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("Language");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
           
        }

        public static string GetLanguageConfig()
        {
            try
            {
                return ConfigurationManager.AppSettings["Language"];
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
            
        }

        public static string GetFormatConfig()
        {
            try
            {
                return ConfigurationManager.AppSettings["Format"];
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public static void ChangeFormatConfig(string format)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Format"].Value = format;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("Format");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }

        }

    }
}
