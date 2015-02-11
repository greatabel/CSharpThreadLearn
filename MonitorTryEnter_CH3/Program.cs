using System;
using System.Threading;
namespace MonitorTryEnter_CH3
{
    class TryEnter
    {
        private int result = 0;

        public void CriticalSection()
        {
            bool b = Monitor.TryEnter(this, 1000);
            Console.WriteLine("Enter thread's hashcode=" + Thread.CurrentThread.GetHashCode() + "Try Enter value=" + b);
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine("Result=" + result++ + " ThreadID=" + Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
            }
            Console.WriteLine("Exiting thread's hashcode=" + Thread.CurrentThread.GetHashCode());
            //if without if(b) sometimes tryenter is wrong ,the monitor.exit will be error.
            if (b)
                Monitor.Exit(this);
        }

        static void Main(string[] args)
        {
            TryEnter e = new TryEnter();
            Thread nt1 = new Thread(new ThreadStart(e.CriticalSection));
            nt1.Start();
            Thread nt2 = new Thread(new ThreadStart(e.CriticalSection));
            nt2.Start();

            Console.ReadLine();
        }
    }
}
