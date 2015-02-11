using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadPoolLockExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DirtyPool.AbelShowExample();

            Console.WriteLine("enter key to end");
            Console.ReadLine();
        }
    }
}
