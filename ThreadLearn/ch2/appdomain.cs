using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadLearn
{
public    class MyAppDomain
    {
    public AppDomain Domain;
    public int ThreadId;

    public void SetDomainData(string vName, string vValue)
    {
        Domain.SetData(vName, (object)vValue);
       /* System.AppDomain.GetCurrentThreadId已过时,请使用System.Threading.Thread.CurrentThread.ManagedThreadId   代替.在2003里已有许多替代了1.1或精简版的了. */
       
         
        ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
       // ThreadId = AppDomain.GetCurrentThreadId();

    }
    public string GetDomainData(string name)
    {
        return (string)Domain.GetData(name);
    }
     public   static void Main(string[] args)
        {
         //1.set appdomain
            string DataName = "MyData";
            string DataValue = "Some Data to be stored";

            Console.WriteLine("Retrieving current domain");
            MyAppDomain Obj = new MyAppDomain();
            Obj.Domain = AppDomain.CurrentDomain;
            Console.WriteLine("Setting domain data");
            Obj.SetDomainData(DataName, DataValue);

            Console.WriteLine("Getting domain data");
            Console.WriteLine("The Data found for key'" + DataName + "'is'" + Obj.GetDomainData(DataName)
                + "' running on thread id:" + Obj.ThreadId);
            Console.ReadLine();

         
          
        }
    }
}
