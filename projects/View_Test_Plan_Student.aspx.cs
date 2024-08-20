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
    public partial class For_Student : System.Web.UI.Page
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
                
                DDLDataSourcefetch();
            }
        }

        private void DDLDataSourcefetch()
        {
            DropDownList1.Items.Add(new ListItem("@--Select Company--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                string queryString = "SELECT * FROM recruitment r,Company_Master c where c.CompanyId=r.CompanyId";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "CompanyName";
                DropDownList1.DataValueField = "CompanyId";
                DropDownList1.DataBind();
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex!=0)
            {

                FetchProductData();
            }
        }

        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT * FROM recruitment r,Company_Master cm,Recruitment_Plan_Schedular rp WHERE  r.CompanyId=cm.CompanyId and rp.CompanyId=r.CompanyId and r.CompanyId=@CompanyId";
                SqlCommand comm = new SqlCommand(queryString, conn);
                //SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("CompanyId", SqlDbType.Int).Value = DropDownList1.Text.Trim();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null)
                {
                    DropDownList1.SelectedValue = dt.Rows[0]["CompanyId"].ToString();
                    TextDate.Text = dt.Rows[0]["TestDate"].ToString();
                    Texttime.Text = dt.Rows[0]["TestTime"].ToString();
                    TextBox3.Text = dt.Rows[0]["Test_Place"].ToString();
                    CheckBox1.Checked = (bool)dt.Rows[0]["apptitude"];
                    CheckBox2.Checked = (bool)dt.Rows[0]["group_discussion"];
                    CheckBox3.Checked = (bool)dt.Rows[0]["technical_round1"];
                    CheckBox4.Checked = (bool)dt.Rows[0]["technical_round2"];
                    CheckBox5.Checked = (bool)dt.Rows[0]["technical_round3"];
                    CheckBox6.Checked = (bool)dt.Rows[0]["telephone_interview1"];
                    CheckBox7.Checked = (bool)dt.Rows[0]["telephone_interview2"];
                    CheckBox8.Checked = (bool)dt.Rows[0]["hr_round1"];
                    CheckBox9.Checked = (bool)dt.Rows[0]["hr_round2"];
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}

          