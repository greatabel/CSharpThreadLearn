using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGenThreadPool_CH5
{
   public  class GenPool
    {
       private Object _lock;
       private GenThreadPoolImpl _gn;

       public GenPool(Object lock_, GenThreadPoolImpl gn)
       {
           this._lock = lock_;
           this._gn = gn;
       }

       public void Run()
       {

       }
    }
}
