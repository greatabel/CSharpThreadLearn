using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ThreadLearn
{
public	class ThreadState
	{
    static void WorkerFunction()
    {
        string ThreadState;
        for (int i = 0; i < 50000; i++)
        {
            if (i % 5000 == 0)
            {
                ThreadState = Thread.CurrentThread.ThreadState.ToString();
                Console.WriteLine("Worker:" + ThreadState);
            }
        }
        Console.WriteLine("Worker Function Complete");
    }

    static void Main()
    {
        string ThreadState;
        Thread t = new Thread(new ThreadStart(WorkerFunction));
        t.Start();
        while (t.IsAlive)
        {
            Console.WriteLine("Still waiting. I'm going back to sleep");
            Thread.Sleep(200);
        }
        ThreadState = t.ThreadState.ToString();
        Console.WriteLine("Done!Thread state is " + ThreadState);
        Console.ReadLine();
    }

	}
}
