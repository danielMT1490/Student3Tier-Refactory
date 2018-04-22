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
using Student.DataAccess.Dao.Exceptions;
using System.Reflection;

namespace Student.DataAccess.Dao.DAO
{
    public class StudentSql<T> : IRepository<T> where T : IVuelingObject
    {
        public static readonly ILogger Log = UtilsConfiguration.CerateInstanceLog(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        private  SqlConnection _conn = null;
        private readonly string stringConection;
        public StudentSql()
        {
            stringConection = "Data Source=LAPTOP-UVGFLCJ7;Initial Catalog=StudentDB;User id=sa;Password=Pa$$w0rd;";
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
                      
                       
                    }

                }
                return SelectByGuid(alumno.Guid);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw new ExceptionDao("Exc`pcion en la capa Dao",ex);
            }
        }

        public int Delete(Guid guid)
        {
            try
            {
                string sql = "Delete from Students where UUID = @UUID";
                using (_conn = new SqlConnection(stringConection))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _cmd.Parameters.AddWithValue("@UUID", guid);
                        return _cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex );
                throw new ExceptionDao("Exc`pcion en la capa Dao",ex);
            }
        }

        public List<T> ReadAll()
        {
            try
            {
                var sql = "Select * from dbo.Students;";
                List<T> students = new List<T>();
                using (_conn = new SqlConnection(stringConection))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();
                        using (SqlDataReader srd = _cmd.ExecuteReader())
                        {
                            while (srd.Read())
                            {
                                 object[] Student = new object[]
                                 {
                                    Guid.Parse(srd["UUID"].ToString()),
                                    Convert.ToInt32(srd["Id"].ToString()),
                                    srd["Dni"].ToString(),
                                    srd["Nombre"].ToString(),
                                    srd["Apellido"].ToString(),
                                    Convert.ToInt32(srd["Edad"].ToString()),
                                    Convert.ToDateTime(srd["DateRegistry"].ToString()),
                                    Convert.ToDateTime(srd["DateBorn"].ToString()),

                                 };
                                Type t = Assembly.GetExecutingAssembly().GetType(typeof(T).Name);
                                students.Add((T)Activator.CreateInstance(t, Student));
                            }
                            return students;

                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Log.Error(ex);

               throw new ExceptionDao("Excepcion en la capa Dao",ex);
            }
            catch (SqlException ex)
            {
                Log.Error(ex);

               throw new ExceptionDao("Excepcion en la capa Dao",ex);
            }
        }

        public T SelectByGuid(Guid guid)
        {
            string sql = $"select * from dbo.Students where UUID ={guid}";
            try
            {
                object[] Student;
                using (_conn = new SqlConnection(stringConection))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, _conn))
                    {
                        using (SqlDataReader srd = cmd.ExecuteReader())
                        {
                             Student = new object[]
                            {
                            Guid.Parse(srd["UUID"].ToString()),
                            Convert.ToInt32(srd["Id"].ToString()),
                            srd["Dni"].ToString(),
                            srd["Nombre"].ToString(),
                            srd["Apellido"].ToString(),
                            Convert.ToInt32(srd["Edad"].ToString()),
                            Convert.ToDateTime(srd["DateRegistry"].ToString()),
                            Convert.ToDateTime(srd["DateBorn"].ToString()),

                            };
                           
                        }
                    }
                }
                Type t = Assembly.GetExecutingAssembly().GetType(typeof(T).Name);
                return (T)Activator.CreateInstance(t, Student);

            }
            catch (SqlException ex)
            {
                Log.Error(ex);
                throw new ExceptionDao("Excepcion en la capa Dao",ex);
            }
            catch (InvalidOperationException ex)
            {
                Log.Error(ex);
               throw new ExceptionDao("Excepcion en la capa Dao",ex);
            }
        }

        public T Update(T entity)
        {
            try
            {
                Alumno alumno = entity as Alumno;
                var sql = $"update  dbo.Students set Nombre=@Nombre,Apellido=@Apellido,Dni=@Dni,DateRegistry=@Registro,DateBorn=@Nacimiento,Edad=@Edad where UUID = {alumno.Guid.ToString()};";
                using (_conn = new SqlConnection(stringConection))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        _cmd.Parameters.AddWithValue("@Apellido", alumno.Apellidos);
                        _cmd.Parameters.AddWithValue("@Dni", alumno.Dni);
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacieminto.ToString());
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro.ToString());
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                     
                        
                    }

                }
                return SelectByGuid(alumno.Guid);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw new ExceptionDao("Exc`pcion en la capa Dao", ex);
            }
        }
    }
}
