using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ThreadLearn.ch2
{
    public class Fibonacci
    {
        public Fibonacci(int n, ManualResetEvent doneEvent)
        {
            _n = n;
            _doneEvent = doneEvent;
        }
        public int N { get { return _n; } }
        private int _n;

        public int FibOfN { get { return _fibOfN; } }
        private int _fibOfN;

        private ManualResetEvent _doneEvent;

        public void ThreadPoolCallback(Object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} started...", threadIndex);
            _fibOfN = Calculate(_n);
            Console.WriteLine("thread {0} result calculated...", threadIndex);
            _doneEvent.Set();
        }

        public int Calculate(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return Calculate(n - 1) + Calculate(n - 2);
        }

    }
    public class ThreadPoolExample
    {
        static void Main()
        {
            const int FibonacciCalculations = 10;

            ManualResetEvent[] doneEvents = new ManualResetEvent[FibonacciCalculations];
            Fibonacci[] fibArray = new Fibonacci[FibonacciCalculations];
            Random r = new Random();

            Console.WriteLine("launching {0} tasks...", FibonacciCalculations);
            for (int i = 0; i < FibonacciCalculations; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                Fibonacci f = new Fibonacci(r.Next(20, 40), doneEvents[i]);
                fibArray[i] = f;
                ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
            }

            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All calculations are complete.");
            // Display the results...
            for (int i = 0; i < FibonacciCalculations; i++)
            {
                Fibonacci f = fibArray[i];
                Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
            }
            Console.ReadLine();
        }
    }
}
