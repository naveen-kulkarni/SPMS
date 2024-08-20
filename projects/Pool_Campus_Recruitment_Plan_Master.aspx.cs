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
    public partial class Pool_Campus_Recruitment_Plan_Master : System.Web.UI.Page
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
           
            //this.TxtUpdatedDate.Visible = false;
            //this.LblUpdatedDate.Visible = false;
            //TxtUpdatedDate.Text = DateTime.Now.Date.ToShortDateString();
            this.BtnBack.Visible = false;
            if (!IsPostBack)
            {
                DDLCompanyName();
                DDLTestTypeShow();
            }
        }

        private void DDLCompanyName()
        {
            DDLCmpName.Items.Add(new ListItem("@--Select Topic--@", ""));
            DDLCmpName.AppendDataBoundItems = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Pool_Campus_Company_College_Config p,Company_Master m where m.CompanyId=p.CompanyId; ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLCmpName.DataSource = dt;
            DDLCmpName.DataTextField = "CompanyName";
            DDLCmpName.DataValueField = "PoolCampusCompanyCollegeId";
            DDLCmpName.DataBind();
        }
        private void DDLTestTypeShow()
        {
            DDLTestType.Items.Add(new ListItem("@--Select Topic--@", ""));
            DDLTestType.AppendDataBoundItems = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Recruitment_TestS_Master; ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLTestType.DataSource = dt;
            DDLTestType.DataTextField = "TestType";
            DDLTestType.DataValueField = "TestTypeID";
            DDLTestType.DataBind();
        }
 

         
         

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("INSERT INTO  Pool_Campus_Recruitment_Plan_Master(PoolCampusCompanyCollegeId, TestTypeID ,Updated_Date,Updated_By) VALUES( @PoolCampusCompanyCollegeId, @TestTypeID ,@Updated_Date,@Updated_By)", conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@PoolCampusCompanyCollegeId", DDLCmpName.Text);
            cmd.Parameters.AddWithValue("@TestTypeID", DDLTestType.Text);
            cmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);

            cmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);

            conn.Open();
            cmd.ExecuteNonQuery();

            //TxtCollAddress.Text = "";
            //TxtCollName.Text = "";
            //TxtContactNo.Text = "";
            // TxtWebSite.Text = "";
            //TxtDescription.Text = "";
            //TxtUpdatedDate.Text = "";
            //TxtUpdatedBy.Text = "";
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Plan_Master.aspx");
        }

        protected void BtnShowAll_Click(object sender, EventArgs e)
        {

             
            this.LblCmpName.Visible = false;
            //this.BtnDelete.Visible = false;
            this.DDLCmpName.Visible = false;
            this.DDLTestType.Visible = false;
             
            this.BtnAdd.Visible = false;
            this.BtnShowAll.Visible = false;
            this.LblTestType.Visible = false;
            //this.BtnEdit.Visible = false;
            //this.LblUpdatedBy.Visible = false;
            //this.LblUpdatedDate.Visible = false;
            //this.TxtUpdatedBy.Visible = false;
            //this.TxtUpdatedDate.Visible = false;
            this.BtnBack.Visible = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(" select m.companyname,r.testtype,rm.Updated_Date,rm.Updated_By from Company_Master m,Pool_Campus_Company_College_Config c ,Pool_Campus_Recruitment_Plan_Master rm,Recruitment_Tests_Master r where rm.TestTypeID=r.TestTypeID and m.CompanyId=c.CompanyId and c.PoolCampusCompanyCollegeId=rm.PoolCampusCompanyCollegeId and rm.Is_Active=1 ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Recruitment_Plan_Master");
            //grdsched.DataSourceID = null;
            GrdCompany_Master.DataSource = ds;
            GrdCompany_Master.DataBind();
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