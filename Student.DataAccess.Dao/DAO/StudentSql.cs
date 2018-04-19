using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using Student.Common.Logic.UtilsConfig;
using Student.DataAccess.Dao.Dao;
using Student.DataAccess.Dao.DaoInterfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace Student.DataAccess.Dao.DAO
{
    public class StudentSql<T> : IDao<T>, ICrud<T> where T : IVuelingObject
    {
        public static readonly ILogger Log = new AdapterLog4Net(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        private  SqlConnection _conn = null;
        private readonly string stringConection;
        public StudentSql()
        {
            stringConection = UtilsConfiguration.Desencriptacion();
        }
        public T Add(T entity)
        {
            try
            {
                Alumno alumno = entity as Alumno;
                var sql = "insert into dbo.Students  (UUID,Nombre,Apellido,Dni,DateRegistry,DateBorn,Edad) values (@UUID,@Nombre,@Apellido,@Dni,@Registro,@Nacimiento,@Edad);";
                using (_conn = new SqlConnection(stringConection))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql,_conn))
                    {
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@UUID", alumno.Guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        _cmd.Parameters.AddWithValue("@Apellido", alumno.Apellidos);
                        _cmd.Parameters.AddWithValue("@Dni", alumno.Dni);
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacieminto);
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro);
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();
                        _cmd.CommandText = "SELECT @@IDENTITY";

                        // Obtenga la última identificación insertada. 
                        alumno.Id = Convert.ToInt32(_cmd.ExecuteScalar());
                        Log.Debug($"Recuperamos el id {alumno.Id}");
                        return SelectByGuid( alumno.Guid);
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public int Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public T SelectByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
