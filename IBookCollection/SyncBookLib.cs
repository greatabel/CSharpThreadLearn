using System;
using System.Threading;
using System.Collections;

namespace IBookCollection
{
   sealed  class SyncBookLib:BookLib
    {
       private object syncRoot;
       private object booklib;

       internal SyncBookLib(IBookCollection acc)
       {
           booklib = acc;
           syncRoot = acc.SyncRoot;
       }
       public override void Clear()
       {
           lock (syncRoot)
           {
               base.Clear();
           }
       }
       public override void Add(Book b)
       {
           lock (syncRoot)
           {
               base.Add(b);
           }
       }

       public override Book GetBook(string ISBN)
       {
           lock (syncRoot)
           {
               return base.GetBook(ISBN);
           }
       }
       public override bool IsSynchronized
       {
           get
           {
               return(true);
           }
       }
       public override object SyncRoot
       {
           get
           {
               return syncRoot;
           }
       }

    }
}
