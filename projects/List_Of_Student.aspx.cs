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
    public partial class List_Of_Student : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                DDLDataSource();
                DDLDataDeptSource();
                LblMsg.Visible = false;

            }
        }

        private void DDLDataDeptSource()
        {
            DropDownList1.Items.Add(new ListItem("@--Select Department--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Department_Master";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Dept_Name";
            DropDownList1.DataValueField = "DepartmentId";
            DropDownList1.DataBind();
            try
            {
                if (a == 1)
                { }
            }
            catch (Exception)
            {
                LblMsg.Visible = true;
                LblMsg.Text = "connection doesnot exist";
            }
            finally
            {
                conn.Close();
                LblMsg.Visible = false;
            }  
        }

        private void DDLDataSource()
        {
            DropDownList3.Items.Add(new ListItem("@--Select USN--@", ""));
            DropDownList3.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Student_Config where Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "USN";
            DropDownList3.DataValueField = "USN";
            DropDownList3.DataBind();
            try
            {
                if (a == 1)
                { }
                else
                {
                    LblMsg.Visible = true;
                    LblMsg.Text = "Data doesnot exist";
                }
                
            }
            catch (Exception)
            {
                LblMsg.Visible = true;
                LblMsg.Text = "connection doesnot exist";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (DropDownList1.Text == "ALL")
            {
                string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connString);
                string queryString = "SELECT s.USN,s.First_Name,s.Middle_Name,s.Last_Name,d.Dept_Name,s.Gender,s.Phone,s.Email,s.Date_Of_Birth,s.Present_Address,s.Permenant_Address from Student_Config s,Department_Master d where s.Is_Active=1 and d.DepartmentId=s.DepartmentId";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                conn.Open();
                int a = comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);
                Grid_Student_Details.DataSource = dt;

                Grid_Student_Details.DataBind();
                try
                {
                    if (a == 1)
                    { }
                }
                catch (Exception)
                {
                    LblMsg.Visible = true;
                    LblMsg.Text = "connection doesnot exist";
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {                
                string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connString);
                string queryString = "SELECT s.USN,s.First_Name,s.Middle_Name,s.Last_Name,d.Dept_Name,s.Gender,s.Phone,s.Email,s.Date_Of_Birth,s.Present_Address,s.Permenant_Address from Student_Config s,Department_Master d where s.USN='" + DropDownList3.SelectedItem.Text + "' and d.Dept_Name='" + DropDownList1.SelectedItem.Text+ "' and d.DepartmentId=s.DepartmentId ";
                SqlCommand comm = new SqlCommand(queryString, conn);
                comm.Parameters.AddWithValue("@Dept_Name", DropDownList1.SelectedItem.Text);
                comm.Parameters.AddWithValue("@USN", DropDownList3.SelectedItem.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                conn.Open();
               int a= comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da.Fill(dt);
                Grid_Student_Details.DataSource = dt;

                Grid_Student_Details.DataBind();
                try
                {
                    if (a == 1)
                    {
                    }
                    else
                    {
                        LblMsg.Visible = true;
                        LblMsg.Text = "Data doesnot exist";
                    }
                }
                catch (Exception)
                {
                    LblMsg.Visible = true;
                    LblMsg.Text = "connection doesnot exist";
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}
        