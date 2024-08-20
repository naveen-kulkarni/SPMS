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
    public partial class Pool_Campus_Recruitment_Test_Result : System.Web.UI.Page
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
                DDlCmpName.Items.Add(new ListItem("@--Select College Name--@", ""));
                DDlCmpName.AppendDataBoundItems = true;

                string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connstr);
                string query = " select * from Pool_Campus_Company_College_Config p,Company_Master m,Pool_Campus_Recruitment_Plan_Master c where m.CompanyId=p.CompanyId and c.PoolCampusCompanyCollegeId=p.PoolCampusCompanyCollegeId;";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DDlCmpName.DataSource = ds;
                DDlCmpName.DataTextField = "CompanyName";
                DDlCmpName.DataValueField = "PoolCampusPlacementTestId";
                DDlCmpName.DataBind();

            }

        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Test_Result_Update.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Test_Result_Delete.aspx");
     
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
     
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Test_Result.aspx");
     
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("INSERT INTO Pool_Campus_Recruitment_Test_Result(PoolCampusPlacementTestId,StudentId,Result,Description,Updated_Date,Updated_By) VALUES(@PoolCampusPlacementTestId,@StudentId,@Result,@Description,@Updated_Date,@Updated_By)", conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@PoolCampusPlacementTestId", DDlCmpName.Text);
            cmd.Parameters.AddWithValue("@StudentId", TxtStudentId.Text);
            cmd.Parameters.AddWithValue("@Result", TxtResult.Text);
           // cmd.Parameters.AddWithValue("@WebSite", TxtWebSite.Text);
            cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
            cmd.Parameters.AddWithValue("@Updated_Date",DateTime.Now);

            cmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);

            conn.Open();
            cmd.ExecuteNonQuery();

            TxtStudentId.Text = "";
            TxtResult.Text = "";
           // TxtContactNo.Text = "";
            //TxtWebSite.Text = "";
            TxtDescription.Text = "";
            //TxtUpdatedDate.Text = "";
            //TxtUpdatedBy.Text = "";
        }

        protected void BtnShowAll_Click(object sender, EventArgs e)
        {

            this.TxtResult.Visible = false;
            this.TxtStudentId.Visible = false;

            this.LblResult.Visible = false;
            this.LblStudentId.Visible = false;
            this.TxtDescription.Visible = false;
            this.LblCmpName.Visible = false;
            this.BtnDelete.Visible = false;
            this.DDlCmpName.Visible = false;
            //this.DDLCollName.Visible = false;
            //this.DDLDept.Visible = false;
            this.BtnAdd.Visible = false;
            this.BtnShowAll.Visible = false;
            // this.LblCollegeAddress.Visible = false;
            //this.LblCollegeName.Visible = false;
            //this.LblContactNo.Visible = false;
            //this.LblWebSite.Visible = false;
            this.LblDescription.Visible = false;
            //this.LblCompName.Visible = false;
            this.BtnEdit.Visible = false;
             
            this.BtnBack.Visible = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select r.result,m.companyname,s.studentid from Pool_Campus_Eligible_Students s, Company_Master m,Pool_Campus_Company_College_Config c,Pool_Campus_Recruitment_Plan_Master rm,Pool_Campus_Recruitment_Test_Result r where m.CompanyId=c.CompanyId and c.PoolCampusCompanyCollegeId=rm.PoolCampusCompanyCollegeId and rm.PoolCampusPlacementTestId=r.PoolCampusPlacementTestId and s.StudentId=r.StudentId and  r.Is_Active=1 ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Recruitment_Test_Result");
            //grdsched.DataSourceID = null;
            GrdStudent_Det.DataSource = ds;
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