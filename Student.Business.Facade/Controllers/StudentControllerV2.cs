using Student.Business.Logic;
using Student.Common.Logic.Log;
using Student.Common.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace Student.Business.Facade.Controllers
{
    public class StudentControllerV2 : ApiController
    {
        public readonly ILogger Log;
        public readonly IStudentBL studentBl;

        public StudentControllerV2(ILogger log, IStudentBL studentbl)
        {
            this.Log = log;
            this.studentBl = studentbl;
        }

        [HttpGet()]
        public IHttpActionResult GetAll()
        {
            Thread.Sleep(1000);
            return Ok(studentBl.GetAll());
        }

        [HttpDelete()]
        public IHttpActionResult Detele(string guid)
        {
            Thread.Sleep(1000);
            return Ok(studentBl.Delete(Guid.Parse(guid)));
        }

        [HttpPost()]
        public IHttpActionResult Add(Alumno alumno)
        {
            Thread.Sleep(1000);
            return Ok(studentBl.Add(alumno));
        }

        [HttpPut()]
        public IHttpActionResult Update(Alumno alumno)
        {
            Thread.Sleep(1000);
            return Ok(studentBl.Update(alumno));
        }
    }
}