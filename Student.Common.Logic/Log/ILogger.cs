using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Log
{
    public interface ILogger
    {
        void Error(Exception ex);
        void Debug(object message);
        void Info(object message);
        void Warn(object message);
    }
}
