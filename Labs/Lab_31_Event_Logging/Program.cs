using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_31_Event_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog.WriteEntry("Application", "You are hacked", EventLogEntryType.Error, 5001, 1239);
        }
    }
}
