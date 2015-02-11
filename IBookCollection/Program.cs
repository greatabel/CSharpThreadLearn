using System;
using System.Threading;
using System.Collections;

namespace IBookCollection
{

    public class Book
    {
        public string Name;
        public string ISBN;
        public string Author;
        public string Publisher;
    }


    class Test
    {
        private static BookLib acc;
        private static int n = 0;

        static void Run()
        {
            for (int i = 0; i < 2; i++)
            {
                Book bk = new Book();
                bk.Author = "Abel";
                bk.Name = "Great Abel's book" + i;
                bk.Publisher = "Wrox";
                bk.ISBN = (n++).ToString();
                acc.Add(bk);
            }
        }
        static void Main(string[] args)
        {
            acc = new BookLib();
            if (args.Length > 0)
            {
                acc = acc.Synchronized();
                //or BookLib.Synchronized(acc);
            }

            Thread[] threads ={
                                  new Thread(new ThreadStart(Run)),
                                  new Thread(new ThreadStart(Run)),
                                  new Thread(new ThreadStart(Run))
                             };
            foreach (Thread t in threads)
            {
                t.Start();
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            for (int i = 0; i < n; i++)
            {
                Book bk = acc.GetBook(i.ToString());
                if (bk != null)
                {
                    Console.WriteLine("Book:" + bk.Name);
                    Console.WriteLine("ISBN:" + bk.ISBN);
                    Console.WriteLine("Publisher:" + bk.Publisher);
                    Console.WriteLine("Author:" + bk.Author);
                }
                
            }
            Console.WriteLine("TotalNumber of books added " + n);
            Console.ReadLine();

        }

    }
}
