using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Trace_ch6
{
    public class BooleanSwitch_Usage
    {
        public  static BooleanSwitch bs;
        static void Main()
        {
            bs = new BooleanSwitch("MySwitch", "Enable/Disable tracing Function");

            FileStream fs = new FileStream("D:\\TextSwitch2012-08-06.log", FileMode.OpenOrCreate);
            Trace.Listeners.Add(new TextWriterTraceListener(fs));

            Trace.WriteLine((DateTime.Now + " enter main()"));
            Trace.WriteLineIf(bs.Enabled ,DateTime.Now+" test switch ");
          
            Console.Read();
            Trace.Close();

        }
    }
}
