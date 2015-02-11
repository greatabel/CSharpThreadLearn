using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ThreadLearn.ch2
{
    public class ExecutionOrder
    {
        static Thread t1;
        static Thread t2;
        static int iIncr;
        public static void WriteFinished(string threadName)
        {
            switch (threadName)
            {
                case "T1":                   
                case "T2":
                    Console.WriteLine();
                    Console.WriteLine(threadName+" Finished");
                    break;

            }
        }

        public static void Increment()
        {
            for (long i = 1; i <= 1000000; i++)
            {
                if (i % 100000 == 0)
                    Console.WriteLine("{" + Thread.CurrentThread.Name + "}"+iIncr.ToString());
            }
            iIncr++;
            WriteFinished(Thread.CurrentThread.Name);
        }
        public static void Main()
        {
            iIncr = 0;
            t1 = new Thread(new ThreadStart(Increment));
            t2 = new Thread(new ThreadStart(Increment));
            t1.Name = "T1";
            t2.Name = "T2";
            t1.Start();
            t2.Start();

            Console.ReadLine();

        }
    }
}
