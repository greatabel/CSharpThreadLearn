using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
namespace ThreadLearn
{
    public class thread_ajust_thread
    {
        public static void Main()
        {
            Console.WriteLine("Entering the main ......");
            int j;
            Car myCar = new Car();
            Thread worker = new Thread(new ThreadStart(myCar.StartTheEngine));
            worker.Start();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine("Main function is working."+i);
            }
            Console.WriteLine("Exiting the main...");
            Console.ReadLine();
        }
    }
   public class Car
    {
        
        public void StartTheEngine()
        {
            Console.WriteLine("###Starting the engine!");
            Thread batt = new Thread(new ThreadStart(CheckTheBattery));
            Thread fuel = new Thread(new ThreadStart(CheckTheFuel));
            Thread eng = new Thread(new ThreadStart(CheckTheEngine));

            batt.Start();
            fuel.Start();
            eng.Start();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("<------- engine starting ------>"+i);
            }
            Console.WriteLine("###Stopping the engine!");
        }

        private void CheckTheBattery()
        {
            Console.WriteLine("Checking the battery!");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Checking the battery ,waiting" + i);

            }
            Console.WriteLine("Finished checking the battery!");
        }
        private void CheckTheFuel()
        {
            Console.WriteLine("Checking the fuel!");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Checking the fuel ,waiting" + i);

            }
            Console.WriteLine("Finished checking the fuel!");
        }
        private void CheckTheEngine()
        {
            Console.WriteLine("Checking the engine!");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Checking the engine ,waiting" + i);

            }
            Console.WriteLine("Finished checking the engine!");
        }

    }
}
