using System;
using System.Threading;

namespace Mutex_CH3
{
    class NETMutex
    {
        static Mutex myMutex;

        public void Run()
        {
            Console.WriteLine("In Run()" + " threadid="+Thread.CurrentThread.GetHashCode());
            myMutex.WaitOne();
            Console.WriteLine("Sleep 10 secs"+" threadid="+Thread.CurrentThread.GetHashCode());
            Thread.Sleep(10000);
            Console.WriteLine("End of Run()" + " threadid="+Thread.CurrentThread.GetHashCode());
            myMutex.ReleaseMutex();
        }
        static void Main(string[] args)
        {
            myMutex = new Mutex(true, "Test");
            NETMutex nm = new NETMutex();
            Thread t = new Thread(new ThreadStart(nm.Run));
            t.Start();
            Console.WriteLine("Main sleep 2 secs");
            Thread.Sleep(5000);
            Console.WriteLine("Main Thread work over");
            myMutex.ReleaseMutex();
            myMutex.WaitOne();

            Console.WriteLine("Main Before waitone");
            
            Console.WriteLine("Main :Lock owned by main");

            Console.ReadLine();

        }
    }
}
