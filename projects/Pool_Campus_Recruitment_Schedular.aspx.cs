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
    public partial class Schedule_Pool_Campus_Test : System.Web.UI.Page
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
           
            this.BtnBack.Visible = false;
            //this.TxtUpdatedDate.Visible = false;
            //this.LblUpdatedDate.Visible = false;
            //TxtUpdatedDate.Text = DateTime.Now.Date.ToShortDateString();

            //Add.Attributes.Add("onclick", "javascript:alert('Hi,Succesfully added');");
            //Update.Attributes.Add("onclick", "javascript:alert('Hi, Succesfully Updated');");
            if (!IsPostBack)
            {
                DDLCmpName();
            }
        }

        private void DDLCmpName()
        {
            DDLCompanyName.Items.Add(new ListItem("@--Select Company Name--@", ""));
            DDLCompanyName.AppendDataBoundItems = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(" select * from Pool_Campus_Company_College_Config p,Company_Master m,Pool_Campus_Recruitment_Plan_Master c where m.CompanyId=p.CompanyId and c.PoolCampusCompanyCollegeId=p.PoolCampusCompanyCollegeId ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLCompanyName.DataSource = dt;
            DDLCompanyName.DataTextField = "CompanyName";
            DDLCompanyName.DataValueField = "PoolCampusPlacementTestId";
            DDLCompanyName.DataBind();

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TxtDate. Text = Calendar1.SelectedDate.ToShortDateString();
             
        }

        

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("INSERT INTO Pool_Campus_Recruitment_Plan_Schedular(PoolCampusPlacementTestId,TestDate,TestStatus,Updated_Date,Updated_By) VALUES(@PoolCampusPlacementTestId,@TestDate,@TestStatus,@Updated_Date,@Updated_By)", conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PoolCampusPlacementTestId", DDLCompanyName.Text);
                cmd.Parameters.AddWithValue("@TestDate", TxtDate.Text);
                cmd.Parameters.AddWithValue("@TestStatus", TxtTestStatus.Text);
                cmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);

                cmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);


                conn.Open();
                cmd.ExecuteNonQuery();
                TxtDate.Text = "";
            TxtTestStatus.Text="";
            //TxtUpdatedBy.Text = "";
            //TxtUpdatedDate.Text = "";


                
        }    
        
              
         
        

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Schedular_Delete.aspx");
       
             
        }

        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            this.LblCollName.Visible = false;
             this.LdlDate.Visible = false;
             this.LblTestStatus.Visible = false;
             //this.LblUpdatedBy.Visible = false;
             //this.LblUpdatedDate.Visible = false;
             //this.TxtUpdatedDate.Visible = false;
             //this.TxtUpdatedBy.Visible = false;
             this.TxtTestStatus.Visible = false;
             this.TxtDate.Visible = false;
             this.DDLCompanyName.Visible = false;
            this.BtnAdd.Visible = false;
            this.BtnDelete.Visible = false;
            this.BtnUpdate.Visible = false;
            this.BtnShowAll.Visible = false;
            this.TxtDate.Visible = false;
            this.ImageButton1.Visible = false;
            
            this.BtnBack.Visible = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select m.companyname,s.testdate,s.teststatus,s.Updated_Date,s.Updated_By from Company_Master  m,Pool_Campus_Company_College_Config c,Pool_Campus_Recruitment_Plan_Master rm,Pool_Campus_Recruitment_Plan_Schedular s where m.CompanyId=c.CompanyId and c.PoolCampusCompanyCollegeId=rm.PoolCampusCompanyCollegeId and rm.PoolCampusPlacementTestId=s.PoolCampusPlacementTestId and s.Is_Active=1 ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Recruitment_Plan_Schedular");
            //grdsched.DataSourceID = null;
            GrdStudent_Det. DataSource = ds;
            GrdStudent_Det. DataBind();
            conn.Close();

        }

         

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Schedular.aspx");
        }

        

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        

        protected void BtnUpdate_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Schedular_Update.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");

        }

                    
        
    }
}