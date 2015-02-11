using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
namespace Trace_ch6
{
  public   class MyTextWriterTraceListener
    {
    

        private static void WritingThread()
        {
            //setting indent level
            Trace.IndentLevel = 2;

            Trace.WriteLine((DateTime.Now+"- Entered WritingThread()"));
            Thread.Sleep(1000);
            Trace.WriteLine((DateTime.Now + "- slept for 1second in WritingThread()"));
            
        }
        static void Main()
        {
            FileStream fs = new FileStream("D:\\TextWrite2012-08-06.log", FileMode.OpenOrCreate);
            Trace.Listeners.Add(new TextWriterTraceListener(fs));

            Trace.WriteLine((DateTime.Now+" enter main()"));

            Thread t=new Thread((new ThreadStart(WritingThread)));
            t.Start();
            Console.Read();
            Trace.Close();


        }
    }
}
