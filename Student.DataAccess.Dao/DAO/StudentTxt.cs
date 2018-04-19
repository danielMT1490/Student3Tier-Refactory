using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using Student.Common.Logic.UtilsConfig;
using Student.DataAccess.Dao.Dao;
using Student.DataAccess.Dao.DaoInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.DAO
{
    public class StudentTxt<T> : IDao<T> where T : IVuelingObject
    {
        private  readonly string Path = UtilsFile.ExistsFile(UtilsConfiguration.GetFormatConfig());
        private  readonly ILogger Log = UtilsConfiguration.InstanceLog(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        public T Add(T entity)
        {
            Log.Debug("");
            try
            {
                using (var sw = new StreamWriter(Path))
                {
                    sw.WriteLine(entity.ToString());
                }
                return SelectByGuid(entity.Guid);
                
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            };
        }

        public List<T> ReadAll()
        {
            try
            {
                Log.Debug("");
                Type t = Assembly.GetExecutingAssembly().GetType(typeof(T).Name);
                List<T> students = new List<T>();
                string linea;
                using (var sr = new StreamReader(Path))
                {
                    while ((linea=sr.ReadLine())!=null)
                    {
                        string[] props = linea.Split(',');
                        var entity = Activator.CreateInstance(t, props);
                        students.Add((T)entity);
                    }
                    return students;
                }
            }
            catch (Exception ex )
            {
                Log.Error(ex );
                throw;
            }
        }

        public T SelectByGuid(Guid guid)
        {
            try
            {
                Log.Debug("");
                List<T> students = ReadAll();
                foreach (var item in students)
                {
                    if (item.Guid == guid) return item;
                }
                return default(T) ;
            }
            catch (Exception ex)
            {
                Log.Error(ex );
                throw;
            }
        }
    }
}
