using System;
using System.Threading;

namespace ReadWriteLock
{
    public class ReadWrite
    {
        private ReaderWriterLock rwl;
        private int x, y;

        public ReadWrite()
        {
            rwl = new ReaderWriterLock();
        }
        public void ReadInts( int a,  int b)
        {
            rwl.AcquireReaderLock(Timeout.Infinite);
            try
            {
                a = this.x;
                b = this.y;
            }
            finally
            {
                rwl.ReleaseReaderLock();
            }
        }
        public void WriteInts(ref int a,ref int b)
        {
            rwl.AcquireWriterLock(Timeout.Infinite);
            try
            {
                this.x = a;
                this.y = b;
                Console.WriteLine("Write x=" + this.x + " y=" + this.y + "thread.id=" + Thread.CurrentThread.GetHashCode());

            }
            finally
            {
                rwl.ReleaseWriterLock();
            }

        }
    }
    class RWApp
    {
        private ReadWrite rw = new ReadWrite();
        int a = 0;
        int b = 1000;
        private void Write()
        {

            Console.WriteLine("write");
            for (int i = 0; i < 5; i++)
            {
                a++; 
                b++;
                this.rw.WriteInts(ref a,ref  b);
                Thread.Sleep(1000);
            }
        }
        private void Read()
        {

            Console.WriteLine("read");
            for (int i = 0; i < 5; i++)
            {
                this.rw.ReadInts(a,  b);
                Console.WriteLine("Read a=" + a + " b=" + b + "thread.id=" + Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            RWApp e = new RWApp();
            Thread wt1 = new Thread(new ThreadStart(e.Write));
            wt1.Start();
            Thread wt2 = new Thread(new ThreadStart(e.Write));
            wt2.Start();

         
            Thread rt1 = new Thread(new ThreadStart(e.Read));
            rt1.Start();
            Thread rt2 = new Thread(new ThreadStart(e.Read));
            rt2.Start();

            Console.ReadLine();
        }
    }
}
