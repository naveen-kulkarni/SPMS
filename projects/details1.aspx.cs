using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Project
{
    public partial class details1 : System.Web.UI.Page
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
            }
            if (!IsPostBack)
            {
                DDADataSource();
            }

        }
        private void DDLDataSource()
        {
            DropDownList1.Items.Add(new ListItem("@--Select Company--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                string queryString = "SELECT * FROM chart";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "CompanyName";
                DropDownList1.DataValueField = "CompanyName";
                DropDownList1.DataBind();
            }
        }
        private void DDADataSource()
        {
            DropDownList2.Items.Add(new ListItem("@--Select Branch--@", ""));
            DropDownList2.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                string queryString = "SELECT * FROM chart";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "Branch";
                DropDownList2.DataValueField = "Branch";
                DropDownList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            string queryString = "SELECT * FROM chart where CompanyName=@CompanyName and Branch=@Branch";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet dt = new DataSet();
            comm.Parameters.AddWithValue("CompanyName", DropDownList1.SelectedItem.Value);
            comm.Parameters.AddWithValue("Branch", DropDownList2.SelectedItem.Value);
            da.Fill(dt);
            Chart1.DataSource = dt;
            Chart1.Series["Series1"].XValueMember = "xvalues";
            Chart1.Series["Series1"].YValueMembers = "yvalues";
            Chart1.DataBind();
            Chart1.Visible = true;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();

            }
            catch (Exception)
            {
                lbl_Err.Visible = true;
                lbl_Err.Text = "Data Missmatch";

            }
            finally
            {
                conn.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("List_Of_Company.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}



