using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ThreadLearn
{
public	class DoSomethingThread
	{
    static void WorkerMethod()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine("Worker Thread:" + i.ToString());
        }
    }
    static void Main()
    {
        ThreadStart ts = new ThreadStart(WorkerMethod);
        Thread t = new Thread(ts);
        t.Start();
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine("Primary Thread:" + i.ToString());
        }
        Console.ReadLine();
    }

	}
}
