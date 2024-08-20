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
    public partial class Pool_Campus_Recruitment_Schedular_Delete : System.Web.UI.Page
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
                DDLCompanyName.Items.Add(new ListItem("@--Select College Name--@", ""));
                DDLCompanyName.AppendDataBoundItems = true;

                string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connstr);
                string query = " select * from Company_Master m, Pool_Campus_Recruitment_Plan_Master r,Pool_Campus_Recruitment_Plan_Schedular s,Pool_Campus_Company_College_Config p where m.CompanyId=p.CompanyId and   p.PoolCampusCompanyCollegeId=r.PoolCampusCompanyCollegeId and r.PoolCampusPlacementTestId=s.PoolCampusPlacementTestId and s.Is_Active=1";
 
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DDLCompanyName.DataSource = ds;
                DDLCompanyName.DataTextField = "CompanyName";
                DDLCompanyName.DataValueField = "PoolCampusPlacementTestId";
                DDLCompanyName.DataBind();

            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Schedular.aspx");
       
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("update  Pool_Campus_Recruitment_Plan_Schedular set Is_Active=0 where  PoolCampusPlacementTestId = '" + DDLCompanyName.Text + "' ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Recruitment_Plan_Schedular");
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