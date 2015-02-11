using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading ;

namespace TestGenThreadPool_CH5
{
  public   class ThreadElement
    {
      private bool _idle;
      private Thread _thread;

      public ThreadElement(Thread th)
      {
          this._thread = th;
          this._idle = true;

      }
      public bool Idle
      {
          get { return this._idle; }
          set { this._idle = value; }

      }
      public Thread GetMyThread() { return this._thread; }

    }
}
