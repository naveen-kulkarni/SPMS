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
    public partial class Pool_Campus_Company_Config : System.Web.UI.Page
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
           
            //TxtUpdatedDate.Text = DateTime.Now.Date.ToShortDateString();
            //this.TxtUpdatedDate.Visible = false;
            //this.LblUpdatedDate.Visible = false;
            this.BtnBack.Visible = false;
            if (!IsPostBack)
            {
                DDLCollegeName();
                DDLCompanyName();
                DDLDepartmentName();
            }
        }

        private void DDLDepartmentName()
        {
            DDLDept.Items.Add(new ListItem("@--Select Department Name--@", ""));
            DDLDept.AppendDataBoundItems = true;

            string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connstr);
            string query = "select * from Department_Master where Is_Active=1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DDLDept.DataSource = ds;
            DDLDept.DataTextField = "Dept_Name";
            DDLDept.DataValueField = "DepartmentId";
            DDLDept.DataBind();
        }

        private void DDLCompanyName()
        {
            DDLCmpName.Items.Add(new ListItem("@--Select Company Name--@", ""));
            DDLCmpName.AppendDataBoundItems = true;

            string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connstr);
            string query = "select * from Company_Master where Is_Active=1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DDLCmpName.DataSource = ds;
            DDLCmpName.DataTextField = "CompanyName";
            DDLCmpName.DataValueField = "CompanyId";
            DDLCmpName.DataBind();
        }

        private void DDLCollegeName()
        {

            DDLCollName.Items.Add(new ListItem("@--Select College Name--@", ""));
            DDLCollName.AppendDataBoundItems = true;

            string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connstr);
            string query = "select * from Pool_Campus_College_Master where Is_Active=1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DDLCollName.DataSource = ds;
            DDLCollName.DataTextField = "CollegeName";
            DDLCollName.DataValueField = "PoolCampusCollegeID";
            DDLCollName.DataBind();
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("INSERT INTO  Pool_Campus_Company_College_Config(PoolCampusCollegeId, CompanyId,DepartmentId,Description,Updated_Date,Updated_By) VALUES(@PoolCampusCollegeId, @CompanyId,@DepartmentId,@Description,@Updated_Date,@Updated_By)", conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@PoolCampusCollegeId", DDLCollName.Text);
            cmd.Parameters.AddWithValue("@CompanyId", DDLCmpName.Text);
            cmd.Parameters.AddWithValue("@DepartmentId", DDLDept.Text);
            //cmd.Parameters.AddWithValue("@WebSite", TxtWebSite.Text);
            cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
            cmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);

             cmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);

            conn.Open();
            cmd.ExecuteNonQuery();

            //TxtCollAddress.Text = "";
            //TxtCollName.Text = "";
            //TxtContactNo.Text = "";
           // TxtWebSite.Text = "";
            TxtDescription.Text = "";
            //TxtUpdatedDate.Text = "";
            //TxtUpdatedBy.Text = "";

        }

        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            //this.TxtCollName.Visible = false;
            //this.TxtCollAddress.Visible = false;
            this.LblDept .Visible = false;
            this .LblCollName.Visible = false;
            this.TxtDescription.Visible = false;
            this.LblCmpName .Visible = false;
            //this.BtnDelete.Visible = false;
            this.DDLCmpName.Visible = false;
            this.DDLCollName.Visible = false;
            this.DDLDept.Visible = false;
            this.BtnAdd.Visible = false;
            this.BtnShowAll.Visible = false;
           // this.LblCollegeAddress.Visible = false;
            //this.LblCollegeName.Visible = false;
            //this.LblContactNo.Visible = false;
            //this.LblWebSite.Visible = false;
            this.LblDescription.Visible = false;
            //this.LblCompName.Visible = false;
            //this.BtnEdit.Visible = false;
            //this.LblUpdatedBy.Visible = false;
            //this.LblUpdatedDate.Visible = false;
            //this.TxtUpdatedBy.Visible = false;
            //this.TxtUpdatedDate.Visible = false;
            this.BtnBack.Visible = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(" select m.companyname,p.collegename ,d.dept_Name ,c.Description , c.Updated_Date,c.Updated_By from Company_Master m,Pool_Campus_College_Master p ,Pool_Campus_Company_College_Config c ,department_Master d where m.CompanyId=c.CompanyId and c.PoolCampusCollegeId=p.PoolCampusCollegeId and d.departmentid=c.departmentid and c.Is_Active=1 ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Company_College_Config");
            //grdsched.DataSourceID = null;
            GrdCompany_Detail.DataSource = ds;
            GrdCompany_Detail.DataBind();
            conn.Close();
        }

        
        protected void BtnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Company_Config.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");

        }

         
    }
}