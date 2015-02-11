using System;
using System.Threading;

namespace Static_CH3
{
    class ThreadStatic
    {
        [System.ThreadStaticAttribute()]
        public static int x = 1;
        public static int y = 1;
        public void Run()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread t2 = Thread.CurrentThread;
                x++;
                y++;
                Console.WriteLine("i=" + i +
                     " Thread.ID=" + t2.GetHashCode() +
                     "  x(static attribute)=" + x +
                      " y=" + y);
                Thread.Sleep(1000);
            }
        }
    }
    class MainAPP
    {
        static void Main(string[] args)
        {
            ThreadStatic tS = new ThreadStatic();
            Thread t1=new Thread(new ThreadStart(tS.Run));
            Thread t2 = new Thread(new ThreadStart(tS.Run));
            t1.Start();
            t2.Start();

            Console.ReadLine();
        }
    }
}
