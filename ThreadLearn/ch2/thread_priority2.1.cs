using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadLearn
{
   public class threadpriority2
    {
       public static Thread worker;
       public static void FindPriority(){
           Console.WriteLine("Name:"+worker.Name);

           Console.WriteLine("State:"+worker.ThreadState.ToString());
           Console.WriteLine("Priority:" + worker.Priority.ToString());
       }

       public static void Main(){
           Console.WriteLine("Entering void Main()");
           worker = new Thread(new ThreadStart(FindPriority));
           //let's give a name to the thread
           worker.Name = "FindPriority() Thread";
           worker.Start();
           Console.WriteLine("Exiting the Main()");
       }

    }
}
