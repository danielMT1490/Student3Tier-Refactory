using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Student.Common.Logic.Models
{
    public class Alumno : IVuelingObject
    {
        #region Propiedades
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public DateTime Nacieminto { get; set; }
        public DateTime Registro { get; set; }
        #endregion

        #region Constructores

        public Alumno()
        {
            this.Guid = Guid.NewGuid();
        }

        public Alumno(Guid guid, int Id, string dni ,string nombre, string apellidos, int edad, DateTime nacimiento, DateTime registro)
        {
            this.Guid = guid;
            this.Id = Id;
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
            this.Nacieminto = nacimiento;
            this.Registro = registro;
        }
        #endregion

        #region ToStrings

        public override string ToString()
        {
            StringBuilder Sbt = new StringBuilder();
            string studentserializer = String.Format($"{Guid},{Id},{Dni},{Nombre},{Apellidos},{Edad},{Nacieminto.ToShortDateString()},{Registro.ToShortDateString()}");
            return Sbt.Insert(0, studentserializer, 1).ToString();
        }


        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        } 
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            return obj is Alumno student &&
                   Id == student.Id &&
                   Nombre == student.Nombre &&
                   Apellidos == student.Apellidos &&
                   Dni == student.Dni && Guid == student.Guid
                   && student.Edad == Edad;
        }

        public override int GetHashCode()
        {
            var hashCode = -818402288;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Guid.ToString());
            return hashCode;
        } 
        #endregion
    }
}
