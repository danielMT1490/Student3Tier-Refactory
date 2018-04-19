using Student.Common.Logic.Enums;
using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logic
{
    public class Filtro
    {
         public static readonly ILogger Log = new AdapterLog4Net(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        public List<Alumno> Students { get; set; }

        public Filtro(List<Alumno> SingeltonList)
        {
            Students = SingeltonList;
        }


        public List<Alumno> Select(Campo campo, string value)
        {
            switch (campo)
            {
                case Campo.Guid:
                    return SelectGuid(value);
                case Campo.ID:
                    return SelectId(value);
                case Campo.Nombre:
                    return SelectNombre(value);
                case Campo.Apellidos:
                    return SelectApellido(value);
                case Campo.Edad:
                    return SelectEdad(value);
                case Campo.Fecha_de_Nacimiento:
                    return SelectDateBorn(value);
                case Campo.Fecha_de_Registro:
                    return SelectDateRegistry(value);
                default:
                    return Students;
            }
        }
        private List<Alumno> SelectGuid(string value)
        {
            var alumnosfiltrado =
                from alumno in Students
                where alumno.Guid == Guid.Parse(value)
                select alumno;
            return alumnosfiltrado.ToList();
        }
        private List<Alumno> SelectId(string value)
        {
            var alumnosfiltrado =
                from alumno in Students
                where alumno.Id == Convert.ToInt32(value)
                select alumno;
            return alumnosfiltrado.ToList();
        }
        private List<Alumno> SelectNombre(string value)
        {
            var alumnosfiltrado =
                from alumno in Students
                where alumno.Nombre == value
                select alumno;
            return alumnosfiltrado.ToList();
        }
        private List<Alumno> SelectApellido(string value)
        {
            var alumnosfiltrado =
                from alumno in Students
                where alumno.Apellidos == value
                select alumno;
            return alumnosfiltrado.ToList();
        }
        private List<Alumno> SelectEdad(string value)
        {
            var alumnosfiltrado =
                from alumno in Students
                where alumno.Edad == Convert.ToInt32(value)
                select alumno;
            return alumnosfiltrado.ToList();
        }
        private List<Alumno> SelectDateBorn(string value)
        {
            var alumnosfiltrado =
                from alumno in Students
                where alumno.Nacieminto == Convert.ToDateTime(value)
                select alumno;
            return alumnosfiltrado.ToList();
        }
        private List<Alumno> SelectDateRegistry(string value)
        {
            var alumnosfiltrado =
                from alumno in Students
                where alumno.Registro == Convert.ToDateTime(value)
                select alumno;
            return alumnosfiltrado.ToList();
        }
    }
    
}
