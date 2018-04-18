using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Log
{
    public class AdapterLog4Net : ILogger
    {
        private ILog _Ilogger { get; set; }

        public AdapterLog4Net(Type type)
        {
            _Ilogger = LogManager.GetLogger(type);
        }
        public void Debug(object message)
        {
            _Ilogger.Debug(message);
        }

        public void Error(Exception ex)
        {
            _Ilogger.Error($",{ex.GetType().Name} , {ex.Message} , {ex.StackTrace}", ex);
        }

        public void Info(object message)
        {
            _Ilogger.Info(message); ;
        }

        public void Warn(object message)
        {
            _Ilogger.Warn(message);
        }
    }
}
