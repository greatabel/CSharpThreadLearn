using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGenThreadPool_CH5
{
    public struct  Stats
    {
        public int maxThreads;
        public int minThreads;
        public int maxIdleTime;
        public int numThreads;
        public int pendingJobs;
        public int jobsInProcess;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Max Threads=");
            sb.Append(maxThreads);
            sb.Append("\nMinThreads=");
            sb.Append(minThreads);
            sb.Append("\nMaxIdleTime=");
            sb.Append(maxIdleTime);
            sb.Append("\npending Jobs=");
            sb.Append(pendingJobs);
            sb.Append("\nIn Progress=");
            sb.Append(jobsInProcess);

            return sb.ToString();
           // return base.ToString();
        }
    }
}
