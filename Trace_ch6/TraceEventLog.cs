using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace Trace_ch6
{
    class TraceEventLog
    {
        static void Main()
        {
           // Console.Write("test ");
            //create a trace listener for the event log
            EventLogTraceListener eltl=new EventLogTraceListener("TraceLog");

            //如果想删除默认侦听器
            Trace.Listeners.RemoveAt(0);
            
            //当必须向文本文件或者控制台写入跟踪信息
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            Trace.Listeners.Add(eltl);

            Trace.WriteLine("Entered in Main");
        }
    }
}
