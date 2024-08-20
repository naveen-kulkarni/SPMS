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
    public partial class Pool_Campus_Company_Placement_Criteria : System.Web.UI.Page
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
            }
        }

        private void DDLCompanyName()
        {
            
            DDlCmpName.Items.Add(new ListItem("@--Select Company Name--@", ""));
            DDlCmpName.AppendDataBoundItems = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Pool_Campus_Company_College_Config p,Company_Master m where m.CompanyId=p.CompanyId; ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDlCmpName.DataSource = dt;
            DDlCmpName.DataTextField = "CompanyName";
            DDlCmpName.DataValueField = "PoolCampusCompanyCollegeId";
            DDlCmpName.DataBind();

        }
 
        

       
        

         

        
        
        

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Company_Criteria_Update.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Company_Criteria_Delete.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Company_Placement_Criteria.aspx");
        }

        protected void BtnHome_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("INSERT INTO Pool_Campus_Company_Placement_Criteria(PoolCampusCompanyCollegeId,CutOffType,CutOffTenth,CutOffTwelth,CutOffDegree,GapInYearsAllowedFlag,BackLogAllowedFlag,Description,Updated_Date,Updated_By) VALUES(@PoolCampusCompanyCollegeId,@CutOffType,@CutOffTenth,@CutOffTwelth,@CutOffDegree,@GapInYearsAllowedFlag,@BackLogAllowedFlag,@Description,@Updated_Date,@Updated_By)", conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@PoolCampusCompanyCollegeId", DDlCmpName.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@CutOffType", TxtCutOfType.Text);
            cmd.Parameters.AddWithValue("@CutOffTenth", TxtCutOfTenth.Text);
            cmd.Parameters.AddWithValue("@CutOffTwelth", TxtCutOfTwelth.Text);
            cmd.Parameters.AddWithValue("@CutOffDegree", TxtCutOfDegree.Text);
            if (RDTrue.Checked == true)
            {
               cmd.Parameters.AddWithValue("@GapInYearsAllowedFlag", true);
            }
            else
            {
                cmd.Parameters.AddWithValue("@GapInYearsAllowedFlag",false);
            }

            if (RdBackLogAllowedYes.Checked== true)
            {
                cmd.Parameters.AddWithValue("@BackLogAllowedFlag",  true);
            }
            else
            {
                cmd.Parameters.AddWithValue("@BackLogAllowedFlag", false);
            }
            cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
            cmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);

            cmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            TxtCutOfType.Text = "";
            TxtCutOfTenth.Text = "";
            TxtCutOfTwelth.Text = "";
            TxtCutOfDegree.Text = "";
            TxtDescription.Text = "";
            //TxtUpdatedDate.Text = "";
            //TxtUpdatedBy.Text = "";
        }

        protected void BtnShowAll_Click(object sender, EventArgs e)
        {

            this.LblCutOfType.Visible = false;
            this.LblCutOfTenth.Visible = false;
            this.LblCutOfTwelth.Visible = false;
            this.LblCutOfDegree.Visible = false;
            this.LblBackInYears.Visible = false;
            this.LblBackLogAllowed.Visible = false;
            this.TxtDescription.Visible = false;
            this.LblCmpName.Visible = false;
            this.BtnDelete.Visible = false;
            this.TxtCutOfType.Visible = false;
            this.DDlCmpName.Visible = false;
            this.TxtCutOfDegree.Visible = false;
            this.TxtCutOfTwelth.Visible = false;
            this.TxtCutOfTenth.Visible = false;
            this.RdBackLogAllowedYes.Visible = false;
            this.RdBackLogNotAllowed.Visible = false;
            this.RDTrue.Visible = false;
            this.RDFalse.Visible = false;


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
            SqlCommand cmd = new SqlCommand(" select m.companyname,pc.cutofftype,pc.CutOffTenth,pc.CutOffTwelth,pc.CutOffDegree,pc.BackLogAllowedFlag,pc.GapInYearsAllowedFlag,pc.Description,pc.Updated_Date ,pc.Updated_By from Company_Master m,Pool_Campus_Company_College_Config c,Pool_Campus_Company_Placement_Criteria  pc where m.CompanyId=c.CompanyId and c.PoolCampusCompanyCollegeId=pc.PoolCampusCompanyCollegeId and pc.Is_Active=1 ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "dbo.Pool_Campus_Company_Placement_Criteria");
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