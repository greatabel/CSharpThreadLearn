using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ThreadLearn
{
  public  class thread_priorityII2
    {
        public static Thread worker;
        public static Thread worker2;
        public static void FindPriority()
        {
            Console.WriteLine("Name:" + worker.Name);

            Console.WriteLine("State:" + worker.ThreadState.ToString());
            Console.WriteLine("Priority:" + worker.Priority.ToString());
        }
        public static void FindPriority2()
        {
            Console.WriteLine("Name:" + worker2.Name);

            Console.WriteLine("State:" + worker2.ThreadState.ToString());
            Console.WriteLine("Priority:" + worker2.Priority.ToString());
        }
        public static void Main()
        {
            Console.WriteLine("Entering void Main()");
            worker = new Thread(new ThreadStart(FindPriority));
            worker2 = new Thread(new ThreadStart(FindPriority2));

            //let's give a name to the thread
            worker.Name = "FindPriority() Thread";
            worker2.Name = "FindPriority() Thread2 ";

            //give the new thread highest priority
            worker2.Priority = System.Threading.ThreadPriority.Highest;

            worker.Start();
            worker2.Start();
            Console.WriteLine("Exiting the Main()");
            Console.ReadLine();
        }

    }
}
