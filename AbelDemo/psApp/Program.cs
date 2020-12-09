using System;
using System.Text.RegularExpressions;


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

        public string department {set;get;}
        public string password {set;get;}
        public GoodAdmin(string department, string password)
        {   
            this.department = department;
            this.password = password;
        }
    }

    public class FinanceAdmin: Administrator
    {   

        public string department {set;get;}
        public string password {set;get;}
        public FinanceAdmin(string department, string password)
        {   
            this.department = department;
            this.password = password;
        }
    }



    class Program
    {
        public static bool checkPaswword(string myString)
        {
            string pattern = @"(?=(.*[a-z]))(?=(.*[A-Z]))(?=(.*\d))(?=(.*[ !""#$%&'()*+,-./:;<=>?@\[\]\^_`{|}~]))^.{8,16}$";
            Regex regex = new Regex(pattern);
            bool r = regex.IsMatch(myString);
            // Console.WriteLine(r);
            return r;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("输入姓名:");
            string name = Console.ReadLine();

            Console.WriteLine("输入部门(进货部门/管理部门):");
            string department = Console.ReadLine();
            string password = "";
            do
            {
                Console.WriteLine("输入密码:");

                password = Console.ReadLine();
                if (password.Length < 8 || password.Length > 16) 
                {
                    Console.WriteLine("密码长度不对，请至少输入8-16位密码");
                }
                if (checkPaswword(password) != true)
                {
                    Console.WriteLine("密码复杂度不够，请至少输入小写字母/大写字母/数字/特殊符号中的3组");
                }


            } while (checkPaswword(password) != true);
            // Console.WriteLine("输入密码:");
            // string password = Console.ReadLine();

            if (department == "进货部门" )
            {
                Console.WriteLine("你拥有[进货部门]权限");
                GoodAdmin good_admin = new GoodAdmin(department, password);
                good_admin.Name = name;
                Console.WriteLine("Hello World {0} {1} {2}", 
                    good_admin.Name,good_admin.department, good_admin.password);

            } 
            if (department == "管理部门")
            {
                Console.WriteLine("你拥有[管理部门]权限");
                FinanceAdmin finance_admin = new FinanceAdmin(department, password);
                finance_admin.Name = name;
                Console.WriteLine("Hello World {0} {1} {2}", 
                    finance_admin.Name,finance_admin.department, finance_admin.password);
            }
            if (department != "进货部门" &&  department != "管理部门")
            {
                Console.WriteLine("你不属于进货部门或者管理部门!");
            }


            // Console.WriteLine("Hello World {0} {1} {2}", name,department, password);

            Administrator admin = new Administrator(name);
            System.Threading.Thread.Sleep(3000); 


        }
    }
}
