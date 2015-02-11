using System;
using System.Threading;

namespace NonSignalEvent
{
    public class NonSignaledManual
    {
        static void Main(string[] args)
        {
            ManualResetEvent mansig;
            mansig = new ManualResetEvent(false);
            Console.WriteLine("ManualResetEvent Before WaitOne...");
            bool b = mansig.WaitOne(1000, false);
            Console.WriteLine("ManualResetEvent After WaitOne.." + b);
            Console.WriteLine("--------------------");

            Console.WriteLine("ManualResetEvent(true)");
            mansig = new ManualResetEvent(true);
            Console.WriteLine("ManualResetEvent Before WaitOne...");
            b = mansig.WaitOne(1000, false);
            Console.WriteLine("ManualResetEvent After WaitOne... " + b);
            Console.WriteLine("--------------------");
            ManualResetEvent manRE;
            manRE = new ManualResetEvent(true);
            bool state = manRE.WaitOne(1000, true);
            Console.WriteLine("ManualResetEvent after waitOne... " + state);
            state = manRE.WaitOne(4000, true);
            Console.WriteLine("ManualResetEvent after waitOne... " + state);
            //change state 
            manRE.Reset();
            state = manRE.WaitOne(5000, true);
            Console.WriteLine("After reset() ManualResetEvent after waitOne " + state);

            Console.WriteLine("--------------------");
           
            manRE = new ManualResetEvent(true);
             state = manRE.WaitOne(1000, true);
            Console.WriteLine("ManualResetEvent after waitOne... " + state);
            //change state 
            manRE.Set();
            state = manRE.WaitOne(5000, true);
            Console.WriteLine("After reset() ManualResetEvent after waitOne " + state);

            Console.WriteLine("--------------------");
            AutoResetEvent aRE = new AutoResetEvent(true);
            Console.WriteLine("AutoResetEvent(true) Before WaitOne");
            state = aRE.WaitOne(1000, true);
            Console.WriteLine("AutoResetEventAfter WaitOne "+state);
            state = aRE.WaitOne(5000, true);
            Console.WriteLine("AutoResetEvent After WaitOne Again " + state);

            Console.ReadLine();
        }
    }
}
