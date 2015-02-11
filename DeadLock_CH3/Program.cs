using System;
using System.Threading;
namespace DeadLock_CH3
{
    class DL
    {
        int field_1 = 0;
        private object lock_1 = new int[1];

        int field_2 = 0;
        private object lock_2 = new int[1];

        public void First(int val)
        {
            lock (lock_1)
            {
                Console.WriteLine("First :acquired lock_1:" + Thread.CurrentThread.GetHashCode() + " Now sleeping");
                Thread.Sleep(1000);
                Console.WriteLine("First :wanting lock_2");
                lock (lock_2)
                {
                    Console.WriteLine("First :acquired lock_2:" + Thread.CurrentThread.GetHashCode() + " Now sleeping");
                    field_1 = val;
                    field_2 = val;
                }
            }

        }
        public void Second(int val)
        {
            lock (lock_2)
            {
                Console.WriteLine("First :acquired lock_2:" + Thread.CurrentThread.GetHashCode() + " Now sleeping");
                Thread.Sleep(1000);
                Console.WriteLine("First :wanting lock_1");
                lock (lock_1)
                {
                    Console.WriteLine("First :acquired lock_1:" + Thread.CurrentThread.GetHashCode() + " Now sleeping");
                    field_1 = val;
                    field_2 = val;
                }
            }
        }

    }
    class MainApp
    {
        DL d = new DL();
        static void Main(string[] args)
        {
            MainApp m = new MainApp();
            Thread t1 = new Thread(new ThreadStart(m.Run1));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(m.Run2));
            t2.Start();

        }
        public void Run1()
        {
            this.d.First(10);


        }
        public void Run2()
        {
            this.d.Second(10);
        }
    }
}
