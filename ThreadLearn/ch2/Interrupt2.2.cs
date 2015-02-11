using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadLearn.ch2
{
	class Interrupt2
    {
        public static Thread sleeper;
        public static Thread worker;

        public static void SleepingThread()
        {
            Console.WriteLine();
            Console.WriteLine("#Entering SleepingThread");
            for (int i = 0; i < 50; i++)
            {
                Console.Write(i + " ");
                //因为线程一旦被Interrupt，再想sleep会引发ThreadInterruptedException异常。
                try
                {
                    if (i == 10 || i == 20 || i == 30)
                    {
                        Thread.Sleep(10);
                        Console.WriteLine("Go to sleep at " + i);
                    }
                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine("ex=" + ex.ToString());
                }
            }
            Console.WriteLine();

            Console.WriteLine("#Exiting SleepingThread");
        }

        public static void AwakeTheThread()
        {
            Console.WriteLine();

            Console.WriteLine("@Entering AwakeTheThread");
            for (int i = 51; i < 100; i++)
            {
                Console.Write(i + " ");
                if (sleeper.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                {
                    Console.WriteLine();

                    Console.WriteLine("@Interrupting the sleeping thread");
                    sleeper.Interrupt();
                }
            }
            Console.WriteLine();

            Console.WriteLine("@Exiting AwakeTheThread");
        }
        public static void Main()
        {
            Console.WriteLine("Entering the void Main!");
            sleeper = new Thread(new ThreadStart(SleepingThread));
            worker = new Thread(new ThreadStart(AwakeTheThread));

            

            sleeper.Start();
            worker.Start();
            Console.WriteLine("Exiting the void Main!");
            Console.ReadLine();
        }

    }
}
