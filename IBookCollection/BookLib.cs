using System;
using System.Threading;
using System.Collections;

namespace IBookCollection
{
    public class BookLib : IBookCollection
    {
        internal Hashtable bk = new Hashtable(10);

        public virtual void Clear()
        {
            this.bk.Clear();
        }
        public virtual void Add(Book b)
        {
            Console.WriteLine("Add book for ThreadID:" + Thread.CurrentThread.GetHashCode());
            Thread.Sleep(1000);
            bk.Add(b.ISBN, b);
        }
        public virtual Book GetBook(string ISBN)
        {
            Console.WriteLine("Getting Book for ThreadID:" + Thread.CurrentThread.GetHashCode());
            return (Book)bk[ISBN];

        }
        public virtual bool IsSynchronized
        {
            get { return (false); }
        }
        public virtual object SyncRoot
        {
            get { return (this); }
        }
        public BookLib Synchronized()
        {
            return Synchronized(this);
        }
        public static BookLib Synchronized(BookLib bc)
        {
            if (bc == null)
            {
                throw new ArgumentNullException("bc");
            }
            if (bc.GetType() == typeof(SyncBookLib))
            {
                throw new InvalidOperationException("BookLib reference is already synchronized");
            }
            return new SyncBookLib(bc);
            
        }
        public static IBookCollection Synchronized(IBookCollection acc)
        {
            if (acc == null)
            {
                throw  new ArgumentNullException("acc");
            }
            if(acc.GetType()==typeof(SyncBookLib))
            {
                throw new InvalidOperationException("Booklib reference is already synchronized.");
            }
            return new SyncBookLib(acc);

        }

    }
}
