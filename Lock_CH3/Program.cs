using System;
using System.Threading;

namespace Lock_CH3
{
    class LockWord
    {
        private int result = 0;

        public void CriticalSection()
        {
            lock (this)
            {
                Console.WriteLine("Enter thread's hashcode=" + Thread.CurrentThread.GetHashCode() );
                for (int i = 0; i <= 3; i++)
                {
                    Console.WriteLine("Result=" + result++ + " ThreadID=" + Thread.CurrentThread.GetHashCode());
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Exiting thread's hashcode=" + Thread.CurrentThread.GetHashCode());
                //if without if(b) sometimes tryenter is wrong ,the monitor.exit will be error.
            }
        }

        static void Main(string[] args)
        {
            LockWord e = new LockWord();
            Thread nt1 = new Thread(new ThreadStart(e.CriticalSection));
            nt1.Start();
            Thread nt2 = new Thread(new ThreadStart(e.CriticalSection));
            nt2.Start();

            Console.ReadLine();
        }
    }
}
