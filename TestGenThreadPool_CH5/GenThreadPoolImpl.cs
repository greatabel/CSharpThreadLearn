using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;

namespace TestGenThreadPool_CH5
{
    public class GenThreadPoolImpl : IThreadPool
    {
        private int _maxThreads;
        private int _minThreads;
        private int _maxIdleTime;
        private static bool _debug;
        private ArrayList _pendingJobs;
        private ArrayList _availableThreads;

        public bool Debug
        {
            get { return _debug; }
            set { _debug = value; }
        }
        public ArrayList PendingJobs
        {
            get { return this._pendingJobs; }
            set { this._pendingJobs = value; }
        }
        public ArrayList AvailableThreads
        {
            get { return this._availableThreads; }
            set { this._availableThreads = value; }
        }
        public int MaxIdleTime
        {
            get { return this._maxIdleTime; }
            set { this._maxIdleTime = value; }
        }
        public int MaxThreads
        {
            get { return this._maxThreads; }
            set { this._maxThreads = value; }
        }
        public int MinThreads
        {
            get { return this._minThreads; }
            set { this._minThreads = value; }
        }

        public GenThreadPoolImpl()
        {
            _maxThreads = 1;
            _minThreads = 0;
            _maxIdleTime = 300;
            this.PendingJobs = ArrayList.Synchronized(new ArrayList());

            this.AvailableThreads = ArrayList.Synchronized(new ArrayList());

            _debug = false;
        }

        public GenThreadPoolImpl(int maxThreads, int minThreads, int maxIdleTime)
        {
            _maxThreads = maxThreads;
            _minThreads = minThreads;
            _maxIdleTime = maxIdleTime;

            this._pendingJobs = ArrayList.Synchronized(new ArrayList());
            this._availableThreads = ArrayList.Synchronized(new ArrayList());
            _debug = false;

            InitAvailableThreads();
            
        }
        public GenThreadPoolImpl(int maxThreads, int minThreads, int maxIdleTime,bool debug_)
        {
            _maxThreads = maxThreads;
            _minThreads = minThreads;
            _maxIdleTime = maxIdleTime;

            this._pendingJobs = ArrayList.Synchronized(new ArrayList());
            this._availableThreads = ArrayList.Synchronized(new ArrayList());
            _debug = debug_;

            InitAvailableThreads();

        }
        private void InitAvailableThreads()
        {
            if (this._minThreads > 0)
                for (int i = 0; i < this._minThreads; i++)
                {
                    Thread t = new Thread(new ThreadStart(new GenPool(this, this).Run));

                    ThreadElement e = new ThreadElement(t);
                    e.Idle = true;
                    _availableThreads.Add(e);
                }
            Console.WriteLine("Initilized the ThreadPool." + "number of available threads:" + this._availableThreads.Count);
        }

        public void AddJob(Thread job)
        {
            if (job == null) return;

            lock (this)
            {
                _pendingJobs.Add(job);

                int index = FindFirstIdleThread();

                if (_debug)
                    Console.WriteLine("First Idle thread is " + index);


                

                
            }
        }
        public int FindIdleThreadCount()
        {
            int idleThreads = 0;
            for (int i = 0; i < _availableThreads.Count; i++)
            {
                if (((ThreadElement)_availableThreads[i]).Idle)
                    idleThreads++;
            }
            return idleThreads;
        }

        public int FindFirstIdleThread()
        {
            for (int i = 0; i < _availableThreads.Count; i++)
            {
                if (((ThreadElement)_availableThreads[i]).Idle)
                    return i;
            }
            return -1;
        }
        public int FindThread()
        {
            for (int i = 0; i < _availableThreads.Count; i++)
            {
                if (((ThreadElement)_availableThreads[i]).GetMyThread().Equals(Thread.CurrentThread))
                    return i;
            }
            return -1;
        }

    }



}
