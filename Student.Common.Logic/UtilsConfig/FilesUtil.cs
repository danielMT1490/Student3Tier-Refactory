using Student.Common.Logic.Enums;
using Student.Common.Logic.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.UtilsConfig
{
    public static class UtilsFile
    {
        public static  readonly ILogger Log = new AdapterLog4Net(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        public static string ExistsFile(string format)
        {
            
            try
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Registro.{format}");
                if (!File.Exists(path)) File.Create(path);
                return path;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
