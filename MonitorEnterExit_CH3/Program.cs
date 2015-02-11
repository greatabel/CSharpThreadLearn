using System;
using System.Threading;

namespace MonitorEnterExit_CH3
{
    class EnterExit
    {
        private int result = 0;

        public void NonCriticalSection()
        {
            Console.WriteLine("Entered Thread's HashCode=" + Thread.CurrentThread.GetHashCode());
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Result=" + result++ + " ThreadID=" + Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
            }
        }

        public void CriticalSection()
        {
            Monitor.Enter(this);
            Console.WriteLine("Enter thread's hashcode=" + Thread.CurrentThread.GetHashCode());
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Result=" + result++ + " ThreadID=" + Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
            }
            Console.WriteLine("Exiting thread's hashcode=" + Thread.CurrentThread.GetHashCode());
            Monitor.Exit(this);
        }
        static void Main(string[] args)
        {
            EnterExit e = new EnterExit();

            if (args.Length > 0)
            {
                Thread nt1 = new Thread(new ThreadStart(e.NonCriticalSection));
                nt1.Start();
                Thread nt2 = new Thread(new ThreadStart(e.NonCriticalSection));
                nt2.Start();
            }
            else
            {
                Thread nt1 = new Thread(new ThreadStart(e.CriticalSection));
                nt1.Start();
                Thread nt2 = new Thread(new ThreadStart(e.CriticalSection));
                nt2.Start();
            }

        }
    }
}
