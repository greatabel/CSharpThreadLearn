using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ObjectPool_CH3
{
    public abstract class ObjectPool
    {
        //last checkout time of any object from the pool
        private long _lastCheckOut;

        //hashtable of the checkout objects
        private static Hashtable locked;

        //hashtable of available objects
        private static Hashtable unlocked;

        //clean-up 
        internal static long GARBAGE_INTERVAL = 90 * 1000; //90 seconds

        static ObjectPool()
        {
            locked = Hashtable.Synchronized(new Hashtable());
            unlocked = Hashtable.Synchronized(new Hashtable());
        }
        internal ObjectPool()
        {
            _lastCheckOut = System.DateTime.Now.Ticks;

            //create a time to track the expired object for cleanup
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Enabled = true;
            aTimer.Interval = GARBAGE_INTERVAL;
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(CollectGarbage);
        }
        protected abstract object Create();

        protected abstract bool Validate(object o);
        protected abstract void Expire(object o);

        internal object GetObjectFromPool()
        {
            long now = System.DateTime.Now.Ticks;
            _lastCheckOut = now;
            object o = null;
            lock (this)
            {
                try
                {
                    //author didn't handle empty situation
                    if (unlocked.Count <= 0)
                    {
                        o = Create();
                        locked.Add(o, now);
                    }
                    foreach (DictionaryEntry myEntry in unlocked)
                    {
                        o = myEntry.Key;
                        if (Validate(o))
                        {
                            unlocked.Remove(o);
                            locked.Add(o, now);
                            return (o);
                        }
                        else
                        {
                            unlocked.Remove(o);
                            Expire(o);
                            o = null;
                        }
                    }
                }
                catch (Exception)
                {
                    o = Create();
                    locked.Add(o, now);
                }
            }
            return o;
        }

        internal void ReturnObjectToPool(object o)
        {
            if (o != null)
            {
                lock (this)
                {
                    locked.Remove(o);
                    unlocked.Add(o, System.DateTime.Now.Ticks);
                }
            }
        }
        private void CollectGarbage(object sender, System.Timers.ElapsedEventArgs ea)
        {
            lock (this)
            {
                object o;
                long now = System.DateTime.Now.Ticks;
                IDictionaryEnumerator e = unlocked.GetEnumerator();
                try
                {
                    while (e.MoveNext())
                    {
                        o = e.Key;
                        if(now-((long)unlocked[o])>GARBAGE_INTERVAL)
                        {
                            unlocked.Remove(o);
                            Expire(o);
                            o = null;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
