using System;

namespace psApp
{   
    public class Administrator
    {
        string _name;
        public string Name
        {
            get{return  _name;}
            set{_name=value;}
        }

        public Administrator() 
        {

        }

        public Administrator(string name)
        {
            this.Name=name;
        }  

    }

    public class GoodAdmin: Administrator
    {   

        public string department;
        public string password;
        public GoodAdmin(string department, string password)
        {   
            department = department;
            password = password;
        }
    }

    public class FinanceAdmin: Administrator
    {   

        public string department;
        public string password;
        public FinanceAdmin(string department, string password)
        {   
            department = department;
            password = password;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入姓名:");
            string name = Console.ReadLine();

            Console.WriteLine("输入部门:");
            string department = Console.ReadLine();

            Console.WriteLine("输入密码:");
            string password = Console.ReadLine();

            Console.WriteLine("Hello World {0} {1} {2}", name,department, password);

            Administrator admin = new Administrator(name);


        }
    }
}
