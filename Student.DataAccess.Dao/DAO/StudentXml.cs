using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using Student.Common.Logic.UtilsConfig;
using Student.DataAccess.Dao.Dao;
using Student.DataAccess.Dao.DaoInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Student.DataAccess.Dao.DAO
{
    
    public class StudentXml<T> : IDao<T> where T : IVuelingObject
    {
        private  readonly ILogger Log = new AdapterLog4Net(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        private  readonly string Path = UtilsFile.ExistsFile(UtilsConfiguration.GetFormatConfig());
        public T Add(T entity)
        {
            Log.Debug("");
            try
            {
                List<T> students = ReadAll();
                students.Add(entity);
                XmlSerializer serialXml = new XmlSerializer(typeof(List<T>));
                using (var sw = new StreamWriter(Path))
                {
                    serialXml.Serialize(sw,students);
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
                List<T> students;

                using (var sr = new StreamReader(Path))
                {
                    XmlSerializer serialXml = new XmlSerializer(typeof(List<T>));
                    var listjson = sr.ReadToEnd();
                    if (listjson.Length > 0)
                    {
                        StringReader str = new StringReader(listjson);
                        students = (List<T>)serialXml.Deserialize(str);
                        return students;
                    }
                    return students = new List<T>();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
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
                return default(T);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
