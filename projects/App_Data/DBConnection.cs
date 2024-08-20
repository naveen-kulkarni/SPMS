using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Project
{
    public class DBConnection
    {

        public DBConnection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public SqlConnection GetDBConnection()
        {

            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS");
            return conn;
        }
    }
}