using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Trace_ch6
{
    class Program
    {
        static void WorkerMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Worker Thread:" + i.ToString());
                Trace.WriteLine(i + "status is :t.ThreadState" + Thread.CurrentThread.ThreadState);
            }
        }
        static void Main()
        {
            ThreadStart ts = new ThreadStart(WorkerMethod);
            Thread t = new Thread(ts);
            //use trace
            Trace.WriteLine("state="+t.ThreadState);
            t.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Primary Thread:" + i.ToString());
                
            }
            Trace.WriteLine("state=" + t.ThreadState);
            Console.ReadLine();
        }
    }
}
