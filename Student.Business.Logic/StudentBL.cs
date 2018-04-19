using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Enums;
using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using Student.Common.Logic.UtilsConfig;
using Student.DataAccess.Dao.Dao;
using Student.DataAccess.Dao.DAO;
using Student.DataAccess.Dao.DaoInterfaces;
using Student.DataAccess.Dao.Factory;
using Student.DataAccess.Dao.Singleton;

namespace Student.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        public static readonly ILogger Log = new AdapterLog4Net(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        private readonly FactoryDao<Alumno> FactoryDao;

        public StudentBL()
        {
            FactoryDao = new FactoryDao<Alumno>((TypeFormat)Enum.Parse(typeof(TypeFormat), UtilsConfiguration.GetFormatConfig()));
        }

        #region Crud
        public Alumno Add(Alumno alumno)
        {
            try
            {
                alumno.Edad = Age.AreAge(alumno.Nacieminto,alumno.Registro);
                Log.Debug("");
                var _ICreate = FactoryDao.FactoryFormat();
                return _ICreate.Add(alumno);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }

        }

        public int Delete(Guid guid)
        {
            try
            {
                Log.Debug("");
                var _IDelete = (ICrud<Alumno>)FactoryDao.FactoryFormat();
                return _IDelete.Delete(guid);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public List<Alumno> GetAll()
        {
            try
            {
                Log.Debug("");
                var _IRead = FactoryDao.FactoryFormat();
                return _IRead.ReadAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public Alumno Update(Alumno alumno)
        {
            try
            {
                Log.Debug("");
                var _IUpdate = (ICrud<Alumno>)FactoryDao.FactoryFormat();
                return _IUpdate.Update(alumno);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        #endregion

        #region Select
        public List<Alumno> Select(Campo campo, string value)
        {
            Filtro fl;
            switch ((TypeFormat)Enum.Parse(typeof(TypeFormat), UtilsConfiguration.GetFormatConfig()))
            {
                case TypeFormat.txt:
                    var txt = new StudentTxt<Alumno>();
                    fl = new Filtro(txt.ReadAll());
                    return fl.Select(campo, value);
                case TypeFormat.json:
                    fl = new Filtro(SingletonJson<Alumno>.Instance.GetList());
                    return fl.Select(campo, value);
                case TypeFormat.xml:
                    fl = new Filtro(SingletonXml<Alumno>.Instance.GetList());
                    return fl.Select(campo, value);
                case TypeFormat.sql:
                    var sql = new StudentSql<Alumno>();
                    fl = new Filtro(sql.ReadAll());
                    return fl.Select(campo, value);
                default:
                    var df = new StudentTxt<Alumno>();
                    fl = new Filtro(df.ReadAll());
                    return fl.Select(campo, value);
            }
        } 
        #endregion
    }
}
