using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace ObjectPool_CH3
{
    class ProgramTest
    {
        static void Main(string[] args)
        {
            DBConnectionSingletion pool;
            pool = DBConnectionSingletion.Instance;

            //set connectionstring 
            DBConnectionSingletion.ConnectionString = @"server=(local);uid=sa;pwd=1024;database=Maintenance;Connect Timeout=300";

            //Borrow the sqlconnection object from the pool
            SqlConnection myConnection = pool.BorrowDBConnection();

       
            //return the connection to the pool after using it
            pool.ReturnDBConnection(myConnection);

            Console.ReadLine();
        }
    }
}
