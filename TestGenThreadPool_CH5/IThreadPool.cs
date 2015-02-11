using System;
using System.Threading;


namespace TestGenThreadPool_CH5
{
  public interface  IThreadPool
    {
      void AddJob(System.Threading.Thread jobToRun);
      Stats GetStats();
    }
}
