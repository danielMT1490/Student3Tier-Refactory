using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using Student.Common.Logic.UtilsConfig;
using Student.DataAccess.Dao.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Singleton
{
    public sealed class SingletonXml<T> where T : IVuelingObject
    {
        public static readonly ILogger Log = new AdapterLog4Net(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        private static SingletonXml<T> instance = null;
        private static readonly object padlock = new object();
        private List<T> students { get; set; }

        public SingletonXml()
        {
            students = new List<T>();
            Load();
        }
        public void Load()
        {
            Log.Debug("");
            var Js = new StudentJson<T>();
            students = Js.ReadAll();
        }
        public List<T> GetList()
        {
            Log.Debug("");
            return students;
        }

        public static SingletonXml<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonXml<T>();
                        }
                    }
                }
                return instance;
            }
        }


    }
}

