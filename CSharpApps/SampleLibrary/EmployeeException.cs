using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{

    public class EmployeeException : Exception
    {
        public EmployeeException() { }
        public EmployeeException(string message) : base(message) 
        {
            EventLog log = new EventLog("AQ-Nov", Environment.MachineName, Assembly.GetExecutingAssembly().FullName);
            log.WriteEntry(message,
                EventLogEntryType.Error);
        }
        public EmployeeException(string message, Exception inner) : base(message, inner) 
        {
            EventLog log = new EventLog("AQ-Nov", Environment.MachineName, Assembly.GetExecutingAssembly().FullName);
            log.WriteEntry($"{message}, System Message: {inner.Message}",
                EventLogEntryType.Error);
        }
        
    }
}
