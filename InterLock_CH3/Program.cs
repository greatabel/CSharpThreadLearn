using System;
using System.Threading;

namespace InterLock_CH3
{
    class AbelInterLocked
    {
        public ManualResetEvent a = new ManualResetEvent(false);
        private int l = 5;

        public void Run(object s)
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + "'s run() state="+s);
            Interlocked.Increment(ref l);
            Console.WriteLine("Thread={0} i={1}", Thread.CurrentThread.GetHashCode(), l);

        }
    }
    public class MainApp
    {

        static void Main(string[] args)
        {
            ManualResetEvent mR = new ManualResetEvent(false);
            AbelInterLocked aL = new AbelInterLocked();
            for (int i = 0; i <= 10; i++)
            {
               // Console.WriteLine("In Main i=" + i);
                ThreadPool.QueueUserWorkItem(new WaitCallback(aL.Run), i);
                    
            }
            mR.WaitOne(10000, true);
            Console.WriteLine("all over");
            Console.ReadLine();
        }
    }
}
