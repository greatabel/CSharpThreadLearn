using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
namespace ThreadPoolLockExample
{
    public class DirtyPool
    {
        // Data held in this queue.
        public static Queue<string> _Operations
                          = new Queue<string>();

        // Status objects for printer delegate/thred
        // to know when to exit.
        bool OneEnded;
        bool TwoEnded;

        public static void ShowExample()
        {
            DirtyPool dp = new DirtyPool();
            dp.DoIt();
            // Sleep long enough so not to kill the threads.
            Thread.Sleep(10000);
        }

        public void SetData(string who)
        {
            Console.WriteLine(who + " is finished process");
            lock (_Operations)
                _Operations.Enqueue(who);
            

        }

        public void PrintData()
        {
            lock (_Operations)
                if (_Operations.Count > 0)
                    Console.WriteLine("out="+_Operations.Dequeue());

        }

        public void DoIt()
        {

            ThreadPool.QueueUserWorkItem(
                delegate // Anonomous Delegate For Creation 1
                {

                    for (int index = 0; index < 5; ++index)
                    {
                        Thread.Sleep(1500);
                        SetData("Pool 1: " + index);
                    }
                    OneEnded = true;
                }
            );

            ThreadPool.QueueUserWorkItem(
               delegate // Anonomous Delegate For Creation 2
               {
                   for (int index = 0; index < 5; ++index)
                   {
                       Thread.Sleep(1000);
                       
                       SetData("Pool 2: " + index);
                   }

                   TwoEnded = true;

               }
           );

            ThreadPool.QueueUserWorkItem(
                    delegate // Anonomous Delegate For Extraction & Printing
                    {
                        while (!(TwoEnded && OneEnded))
                            PrintData();

                        PrintData(); // Just in case...

                    }
                );

        }
        //---------------
        private object sync = new object();
        public List<string> IDList { get { return idList; } set { idList = value; } }
        private List<string> idList = new List<string>();

        public List<string> Calculate(int n)
        {
            int divide = idList.Count / 10;
            List<string> perList = new List<string>();
            for (int i = divide * n; i < divide * (n + 1); i++)
            {
                perList.Add(idList[i]);
            }
            return perList;

        }


        public static void AbelShowExample()
        {
            
            List<string> list = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                list.Add("test" + i);
            }
            DirtyPool dp = new DirtyPool();
            dp.IDList = list;
            dp.AbelTest();


            // Sleep long enough so not to kill the threads.
            Thread.Sleep(10000);
        }

        public void WriteDB(List<string> list,Object threadContext)
        {

            Console.WriteLine(threadContext.ToString() + " is writing db");
            
        }
        public void ThreadPoolCallback(Object threadContext)
        {
            System.Threading.Thread.Sleep(10000);
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} started...", threadIndex);
            List<string> mylist = Calculate(threadIndex);
            for (int i = 0; i < mylist.Count ; i++)
            {
                Console.WriteLine("thread {0} started...{1}", threadIndex,mylist[i]);  
            }

            lock (sync)
            {
                WriteDB(mylist,threadContext);
            }
            doneEvents[threadIndex].Set();

        }
        const int IDHandlerThreadCount = 5;

        ManualResetEvent[] doneEvents = new ManualResetEvent[IDHandlerThreadCount];
        public void AbelTest()
        {
            List<string> totalzipcodeList = new List<string>();
       
            for (int i = 0; i < IDHandlerThreadCount; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
              //  ThreadHelper f = new ThreadHelper(i, doneEvents[i]);
              //  fibArray[i] = f;
                ThreadPool.QueueUserWorkItem(ThreadPoolCallback, i);
              

            }
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All calculations are complete.");
        }

    }
}
