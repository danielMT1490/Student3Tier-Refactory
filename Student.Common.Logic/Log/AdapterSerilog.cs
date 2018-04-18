using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Enums;

namespace Student.Common.Logic.Log
{
    public class AdapterSerilog : ILogger
    {
        private Serilog.ILogger logger { get; set; }
        
        public AdapterSerilog(TypeFormat typeFormat)
        {
            var pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LogSerilog.txt";
            logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Async(sink => sink.RollingFile(@"Logs\StudentsLog-SeriLog.txt"))
                        .WriteTo.Async(sink => sink.Console())
                        .CreateLogger();
        }
        public void Debug(object message)
        {
            logger.Debug((string)message);
        }

        public void Error(Exception ex)
        {
            logger.Error($"{ex.Message} , {ex.StackTrace}");
        }

        public void Info(object message)
        {
            logger.Information((string)message);
        }

        public void Warn(object message)
        {
           logger.Warning((string)message);
        }
    }
}
