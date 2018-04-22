using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Exceptions
{
    public class ExceptionDao : Exception
    {
        public ExceptionDao() { }
        public ExceptionDao(string message) : base(message) { }
        public ExceptionDao(string message, Exception inner) : base(message, inner) { }
        
    }

}
