using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Final_Report_SMPS
{
    public partial class Pool_Campus_Eligible_Student_Delete : System.Web.UI.Page
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
                DDLStudentId.Items.Add(new ListItem("@--Select Student Id--@", ""));
                DDLStudentId.AppendDataBoundItems = true;

                string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connstr);
                string query = "select * from Pool_Campus_Eligible_Students where Is_Active=1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DDLStudentId.DataSource = ds;
                DDLStudentId.DataTextField = "StudentId";
                // DDLStudentId.DataValueField = "PoolCampusCollegeID";
                DDLStudentId.DataBind();

            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Eligible_Student.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("update  Pool_Campus_Eligible_Students set Is_Active=0 where StudentId = '" + DDLStudentId.Text + "' ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Eligible_Students");
            GrdStudent_Det.DataSourceID = null;
            //Response.Redirect("Other_College_Detail.aspx");
            //grdsched.DataSource = ds;
            GrdStudent_Det.DataBind();
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");

        }
    }
}