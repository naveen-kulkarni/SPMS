using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Final_Crystal_Reports
{
    class DBConnection
    {
        public DBConnection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public SqlConnection GetDBConnection()
        {
            SqlConnection myConnection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Spms;Data Source=SYS2\\SQLEXPRESS");

            return myConnection;
        }
    }
}
