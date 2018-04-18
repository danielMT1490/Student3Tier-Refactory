using Student.Common.Logic.Enums;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Utils
{
    public static class FileUtils
    {
        public static string ExistsFile(TypeFormat typeFormat)
        {
            try
            {
                var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Registro.{typeFormat}");
                if (!File.Exists(path)) File.Create(path);
                return path;
            }
            catch ( Exception ex )
            {

                throw;
            }
        }
    }
}
