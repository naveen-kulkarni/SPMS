using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (Session["user"] != null)
            {
                string s = Session["user"].ToString();
                Txt_updby.Text = s;
            }
            else
            {
                Response.Redirect("Login_Placement.aspx");
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand("Insert_Student_Attendance",conn);
            Updatecmd.CommandType = CommandType.StoredProcedure;
            Updatecmd.Connection = conn;
            //Updatecmd.CommandText = "insert into Student_Attendance_Record(USN,AttendancePercentage,Is_Active,Updated_Date,Updated_By)Values(@USN,@AttendancePercentage,@Is_Active,@Updated_Date,@Updated_By)";
            Updatecmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@AttendancePercentage", SqlDbType.VarChar).Value = Txt_Attendance_Percentage.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value =DateTime.Now.Date.ToShortDateString();
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
            
            Updatecmd.Connection = conn;
            try
            {
                conn.Open();
                Updatecmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "could not be saved";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}