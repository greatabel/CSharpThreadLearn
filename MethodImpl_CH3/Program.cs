using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MethodImpl_CH3
{
    class MI
    {
        /// <summary>
        /// this attribute
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void doSomeWorkSync()
        {
            Console.WriteLine("doSomeWorkSync()" + "--Lock held by Thread" + Thread.CurrentThread.GetHashCode());

            Thread.Sleep(5 * 1000);
            Console.WriteLine("doSomeWorkSync()" + "--Lock released by Thread" + Thread.CurrentThread.GetHashCode());
        }


        public void doSomeWorkNoSync()
        {
            Console.WriteLine("doSomeWorkNoSync()" + "--Entered released by Thread" + Thread.CurrentThread.GetHashCode());

            Thread.Sleep(5 * 1000);
            Console.WriteLine("doSomeWorkNoSync()" + "--Leaving released by Thread" + Thread.CurrentThread.GetHashCode());
        }
        [STAThread]
        static void Main(string[] args)
        {
            MI m = new MI();
            //Delegate for Non-sync operation
            ThreadStart tsNoSyncDelegate = new ThreadStart(m.doSomeWorkNoSync);

            ThreadStart tsSyncDelegate = new ThreadStart(m.doSomeWorkSync);

            Thread t1 = new Thread(tsNoSyncDelegate);
            Thread t2 = new Thread(tsNoSyncDelegate);

            t1.Start();
            t2.Start();

            Thread t3 = new Thread(tsSyncDelegate);
            Thread t4 = new Thread(tsSyncDelegate);
            t3.Start();
            t4.Start();

            Console.ReadLine();
        }
    }
}
