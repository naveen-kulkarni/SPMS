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
    public partial class CompanyChart : System.Web.UI.Page
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
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";

            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select CompanyName,Branch,xvalues,yvalues from chart", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "chart");
            //grdsched.DataSourceID = null;
            Grid.DataSource = ds;
            Grid.DataBind();
            conn.Close();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("insert into chart (CompanyName,Branch,xvalues,yvalues)values(@CompanyName,@Branch,@xvalues,@yvalues)", conn);
            //SqlCommand cmd = new SqlCommand("Save_chart", conn);
           cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CompanyName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Branch", SqlDbType.VarChar).Value = TextBox2.Text.Trim();
            cmd.Parameters.AddWithValue("@xvalues", SqlDbType.VarChar).Value = TextBox3.Text.Trim();
            cmd.Parameters.AddWithValue("@yvalues", SqlDbType.Int).Value = TextBox4.Text.Trim();
            cmd.Parameters.AddWithValue("@chartid", SqlDbType.Int).Value = TextBox5.Text.Trim();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";

            Response.Redirect("CompanyChart.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("companyprofile.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Chart2.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company_Eligibility_Criteria.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}
