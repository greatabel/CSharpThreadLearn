using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
namespace ThreadLearn
{
   public class ThreadStartBranching
    {
       enum UserClass
       {
           ClassAdmin,
           ClassUser
       }
       static void AdminMethod()
       {
           Console.WriteLine("Admin Method");
       }
       static void UserMethod()
       {
           Console.WriteLine("User Method");
       }
       static void ExecuteFor(UserClass uc)
       {
           ThreadStart ts;
           ThreadStart tsAdmin = new ThreadStart(AdminMethod);
           ThreadStart tsUser = new ThreadStart(UserMethod);

           if (uc == UserClass.ClassAdmin)
               ts = tsAdmin;
           else
               ts = tsUser;

           Thread t = new Thread(ts);
           t.Start();
          

       }
       static void Main()
       {
           //execute in the context of an admin user
           ExecuteFor(UserClass.ClassAdmin);

           //execute in the context of a regular user
           ExecuteFor(UserClass.ClassUser);
           Console.ReadLine();

       }


    }
}
