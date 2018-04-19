using Student.Common.Logic.Enums;
using Student.Common.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logic
{
    public interface IStudentBL
    {
        Alumno Add(Alumno alumno);
        List<Alumno> GetAll();
        int Delete(Guid guid);
        Alumno Update(Alumno alumno);
        List<Alumno> Select(Campo campo , string value);
    }
}
