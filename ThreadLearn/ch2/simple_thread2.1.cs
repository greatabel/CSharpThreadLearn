using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ThreadLearn
{
  public  class SimpleThread
    {
      public void SimpleMethod()
      {
          int i = 5;
          int x = 10;
          int result = i * x;
          Console.WriteLine("The code calculated the value" +
              result.ToString() + " from thread ID:" +
              System.Threading.Thread.CurrentThread.ManagedThreadId);
      }
      static void Main()
      {
          //calling the method from our current thread
          SimpleThread simpleThread = new SimpleThread();
          simpleThread.SimpleMethod();

          //calling on a new thread
          ThreadStart ts = new ThreadStart(simpleThread.SimpleMethod);
          Thread t = new Thread(ts);
          t.Start();
          Console.ReadLine();
      }

    }
}
