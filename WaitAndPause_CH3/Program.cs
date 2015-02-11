using System;
using System.Threading;

namespace WaitAndPause_CH3
{
    public class LockMe { }
    public class WaitPalse1
    {
        private int result = 0;
        private LockMe _IM;


        public WaitPalse1(LockMe l)
        {
            _IM = l;
        }

        public void CriticalSection()
        {
            Monitor.Enter(this._IM);
            Console.WriteLine("WaitPaulse1 Enter thread's hashcode=" + Thread.CurrentThread.GetHashCode());
            for (int i = 0; i <= 5; i++)
            {
                Monitor.Wait(this._IM);

                Console.WriteLine("WaitPaulse1:WorkingUp ThreadID=" + Thread.CurrentThread.GetHashCode() + " result=" + result++);
                Monitor.Pulse(this._IM);
            }
            Console.WriteLine("WaitPaulse1 Exiting thread's hashcode=" + Thread.CurrentThread.GetHashCode());
            Monitor.Exit(this._IM);
        }
    }
    public class WaitPalse2
    {
        private int result = 0;
        private LockMe _IM;


        public WaitPalse2(LockMe l)
        {
            _IM = l;
        }

        public void CriticalSection()
        {
            Monitor.Enter(this._IM);
            Console.WriteLine("WaitPaulse2 Enter thread's hashcode=" + Thread.CurrentThread.GetHashCode());
            for (int i = 0; i <= 5; i++)
            {
                Monitor.Pulse(this._IM);

                Console.WriteLine("WaitPaulse2:WorkingUp ThreadID=" + Thread.CurrentThread.GetHashCode()+" result="+result++);
                Monitor.Wait(this._IM);
            }
            Console.WriteLine("WaitPaulse2 Exiting thread's hashcode=" + Thread.CurrentThread.GetHashCode());
            Monitor.Exit(this._IM);
        }
    }
    class ClassForMain
    {
        static void Main(string[] args)
        {
            LockMe l = new LockMe();
            WaitPalse1 e1 = new WaitPalse1(l);
            WaitPalse2 e2 = new WaitPalse2(l);

            Thread nt1 = new Thread(new ThreadStart(e1.CriticalSection));
            nt1.Start();
            Thread nt2 = new Thread(new ThreadStart(e2.CriticalSection));
            nt2.Start();

            Console.ReadLine();
        }
    }
}
