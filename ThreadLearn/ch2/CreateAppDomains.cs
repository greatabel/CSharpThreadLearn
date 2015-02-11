using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadLearn
{
  public  class CreateAppDomains
    {
        //2.创建新的AppDomain

      public static void CommonCallBack()
      {
          AppDomain Domain;
          Domain = AppDomain.CurrentDomain;
          Console.WriteLine("The value'" + Domain.GetData("DomainKey") + "'was found in " + Domain.FriendlyName.ToString() +
              " running on thread id" + System.Threading.Thread.CurrentThread.ManagedThreadId);

      }
      static void Main()
      {
          AppDomain DomainA;
          DomainA = AppDomain.CreateDomain("MyDomainA");
          string StringA = "DomainA Value";
          DomainA.SetData("DomainKey", StringA);

          CommonCallBack();
          CrossAppDomainDelegate delegateA = new CrossAppDomainDelegate(CommonCallBack);
          DomainA.DoCallBack(delegateA);
          Console.ReadLine();

      }

    }
}
