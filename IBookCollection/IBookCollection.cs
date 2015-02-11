using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBookCollection
{
  public   interface IBookCollection
    {
        void Clear();
        void Add(Book n);
        Book GetBook(string ISBN);
        bool IsSynchronized { get; }
        object SyncRoot { get; }

    }
}
