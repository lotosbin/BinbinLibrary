using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLog
{
    public interface ILogger
    {
        void Log(string level,string message, Exception exception);
    }
    public class ConsoleLogger:ILogger
    {
        #region Implementation of ILogger

        public void Log(string level, string message, Exception exception)
        {
            Console.Write(message);
        }

        #endregion
    }
}
