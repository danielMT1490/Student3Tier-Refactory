using Student.Business.Facade.Filters;
using Student.Business.Logic;
using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Student.Business.Facade.Controllers
{
    public class StudentController : ApiController
    {
        public readonly ILogger Log;
        public readonly IStudentBL studentBl;

        public StudentController(ILogger log , IStudentBL studentbl)
        {
            this.Log = log;
            this.studentBl = studentbl;
        }

        [BusinessFilter]
        [DatabaseFilter]
        [HttpGet()]
        public IHttpActionResult GetAll()
        {
            return Ok(studentBl.GetAll());
        }

        [BusinessFilter]
        [DatabaseFilter]
        [HttpDelete()]
        public IHttpActionResult Detele(string guid)
        {
            return Ok(studentBl.Delete(Guid.Parse(guid)));
        }

        [BusinessFilter]
        [DatabaseFilter]
        [HttpPost()]
        public IHttpActionResult Add(Alumno alumno)
        {
            return Ok(studentBl.Add(alumno));
        }

        [BusinessFilter]
        [DatabaseFilter]
        [HttpPut()]
        public IHttpActionResult Update(Alumno alumno)
        {
            return Ok(studentBl.Update(alumno));
        }

    }
}