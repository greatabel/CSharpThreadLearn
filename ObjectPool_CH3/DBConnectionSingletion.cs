using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace ObjectPool_CH3
{
   public sealed  class DBConnectionSingletion:ObjectPool
    {
       private DBConnectionSingletion() { }

       public static readonly DBConnectionSingletion Instance = new DBConnectionSingletion();
       private static string _connectionString=@"server=(local);uid=sa;pwd=1024;database=Maintenance;Connect Timeout=300";

       public static string ConnectionString
       {
           set { _connectionString = value; }
           get { return _connectionString; }
       }

       protected override object Create()
       {
           SqlConnection temp = new SqlConnection(_connectionString);
           temp.Open();
           return temp;
           //throw new NotImplementedException();
       }

       protected override bool Validate(object o)
       {
           try
           {
               SqlConnection temp = (SqlConnection)o;
               return(
                   !((temp.State.Equals(System.Data.ConnectionState.Closed)))
                   );
           }
           catch (SqlException)
           {
               return false;
           }
           //throw new NotImplementedException();
       }

       protected override void Expire(object o)
       {
           try
           {
               ((SqlConnection)o).Close();
           }
           catch (SqlException)
           {

           }
           //throw new NotImplementedException();
       }
       public SqlConnection BorrowDBConnection()
       {
           try
           {
               return ((SqlConnection)base.GetObjectFromPool());
           }
           catch (SqlException e)
           {
               throw e;
           }
       }
       public void ReturnDBConnection(SqlConnection c)
       {
           base.ReturnObjectToPool(c);
       }
    }
}
