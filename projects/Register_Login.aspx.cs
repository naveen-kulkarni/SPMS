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
    public partial class Register_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
              if (!IsPostBack)
            {
                DDLDataSource();
                DeptDataSource();
            }
            
            
        }
        private void DeptDataSource()
        {
            DropDownList2.Items.Add(new ListItem("@--Select College--@", ""));
            DropDownList2.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT * from College_Master";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "CollegeName";
                DropDownList2.DataValueField = "CollegeId";
                DropDownList2.DataBind();
            }
        }

        private void DDLDataSource()
        {
            DropDownList1.Items.Add(new ListItem("@--Select Department--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {

                string queryString = "select * from Department_Master";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "Dept_Name";
                DropDownList1.DataValueField = "DepartmentId";
                DropDownList1.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand();
            conn.Open();
            Updatecmd.Connection = conn;
            Updatecmd.CommandText = "insert into Register_Table(User_Name,Password,DepartmentId,CollegeId,E_mail,Contact_No,LoginType)Values(@User_Name,@Password,@DepartmentId,@CollegeId,@E_mail,@Contact_No,@LoginType)";
            Updatecmd.Parameters.AddWithValue("@User_Name", SqlDbType.VarChar).Value = Txt_User.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = Txt_Pwd.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@CollegeId", SqlDbType.Int).Value = DropDownList2.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@DepartmentId", SqlDbType.Int).Value = DropDownList1.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@E_mail", SqlDbType.VarChar).Value = Txt_mail.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Contact_No", SqlDbType.VarChar).Value = Txt_phone.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@LoginType", SqlDbType.VarChar).Value = DropDown_Login_Type.Text.Trim();
            Updatecmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}