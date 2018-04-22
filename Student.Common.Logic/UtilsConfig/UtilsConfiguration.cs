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
        public static readonly ILogger Log;
        static UtilsConfiguration()
        {
           Log  = UtilsConfiguration.CerateInstanceLog(System.Reflection.MethodBase.GetCurrentMethod().GetType());
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
                var format= ConfigurationManager.AppSettings["Format"];
                return format;
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

        public static string Desencriptacion()
        {
            try
            {
                Log.Debug("");
                var valueAppConfig = ConfigurationManager.AppSettings["Database"];
                var encriptconnection = Environment.GetEnvironmentVariable(valueAppConfig, EnvironmentVariableTarget.User);
                byte[] desencriptar = Convert.FromBase64String(encriptconnection);
                return Encoding.Unicode.GetString(desencriptar);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
          
        }

        public  static ILogger CerateInstanceLog(Type type)
        {
            var key = ConfigurationManager.AppSettings["Log"];
            
            Type t = Assembly.GetExecutingAssembly().GetType(key);

            object[] mParam = new object[] { type };
            return (ILogger)Activator.CreateInstance(t, mParam);
        }

        public static void ChangeLog(string log)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Log"].Value = log;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("Log");
        }

        

    }
}
