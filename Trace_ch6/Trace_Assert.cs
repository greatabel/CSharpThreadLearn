using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Trace_ch6
{
    class Trace_Assert
    {
        [STAThread]
        static void Main()
        {
            //create a thread
            Thread t;
            t = new Thread(new ThreadStart(DBThread));
            t.Start();
        }

        private static void DBThread()
        {
            //string strConnection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionStringForWEBMST"].ToString();
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringForWEBMST"].ConnectionString; 
            //create a connection object
            SqlConnection dbConn = new SqlConnection(strConnection);
         //   SqlCommand dbComm = new SqlCommand("select top 10 * from iGen_House_Info ",dbConn);
            SqlCommand dbComm = new SqlCommand("select top 10 * from iGen_House_Info ");
            SqlDataReader dr = null;

            Trace.WriteLine(DateTime.Now + "- Executing sql");
            try
            {
                dbConn.Open();
                //Assert that the connection failed
                Trace.Assert(dbConn.State == ConnectionState.Open, "Error", "Connection failed..");
                //execute sql
              //  dr = dbComm.ExecuteReader(CommandBehavior.CloseConnection);
                dr = dbComm.ExecuteReader();

                //assert that the statement execute ok
                Trace.Assert(dr != null, "Error", "The salDataReader is null!");
                while (dr.Read())
                {
                    Console.Write(dr["mls_num"].ToString());
                }
            }
            catch
            {
                //log the error to trace application
                Trace.Fail("An error occur in connecting to database");
            }
            finally
            {
                if ((dr.IsClosed == false) && (dr != null))
                    dr.Close();
            }


        }
    }
}
