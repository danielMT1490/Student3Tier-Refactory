using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using Student.Common.Logic.UtilsConfig;
using Student.DataAccess.Dao.Dao;
using Student.DataAccess.Dao.DaoInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Student.DataAccess.Dao.Exceptions;

namespace Student.DataAccess.Dao.DAO
{
    public class StudentJson<T> : IRepository<T> where T : IVuelingObject
    {
        private  readonly ILogger Log = UtilsConfiguration.CerateInstanceLog(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        private  readonly string Path = UtilsFile.ExistsFile(UtilsConfiguration.GetFormatConfig());
        public T Add(T entity)
        {
            Log.Debug("");
            try
            {
                List<T> students = ReadAll();
                students.Add(entity);
                var jsonSerialize = JsonConvert.SerializeObject(students);
                using (var sw = new StreamWriter(Path))
                {
                    sw.Write(jsonSerialize);
                }
                return SelectByGuid(entity.Guid);

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw new ExceptionDao("Exc`pcion en la capa Dao",ex);
            };
        }

        public int Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            try
            {
                Log.Debug("");
                List<T> students ;

                using (var sr = new StreamReader(Path))
                {
                    
                    var listjson = sr.ReadToEnd();
                    if (listjson.Length>0)
                    {
                        students = JsonConvert.DeserializeObject<List<T>>(listjson);
                        return students;
                    }
                    return students =new List<T>();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw new ExceptionDao("Exc`pcion en la capa Dao",ex);
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
                throw new ExceptionDao("Exc`pcion en la capa Dao",ex);
            }
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
