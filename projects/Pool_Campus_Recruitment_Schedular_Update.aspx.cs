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
    public partial class Pool_Campus_Recruitment_Schedular_Update : System.Web.UI.Page
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
            loaddepart();

        }
        

        public void loaddepart()
        {
            if (!IsPostBack)
            {
                DDLDataSource();
            }
        }





        private void DDLDataSource()
        {
            DDLCompanyName.Items.Add(new ListItem("@--Select College Name--@", ""));
            DDLCompanyName.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "  select * from Company_Master m, Pool_Campus_Recruitment_Plan_Master r,Pool_Campus_Recruitment_Plan_Schedular s,Pool_Campus_Company_College_Config p where m.CompanyId=p.CompanyId and   p.PoolCampusCompanyCollegeId=r.PoolCampusCompanyCollegeId and r.PoolCampusPlacementTestId=s.PoolCampusPlacementTestId and s.Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLCompanyName.DataSource = dt;
            DDLCompanyName.DataTextField = "CompanyName";
            DDLCompanyName.DataValueField = "PoolCampusPlacementTestId";
            DDLCompanyName.DataBind();
            try
            {
                if (a == 1)
                { }
            }
            catch (Exception)
            {
                LblErrorMsg.Visible = true;
                LblErrorMsg.Text = "connection doesnot exist";
            }
            finally
            {
                conn.Close();
            }
        }
        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Pool_Campus_Recruitment_Plan_Schedular WHERE PoolCampusPlacementTestId=@PoolCampusPlacementTestId and Is_Active=1 ";
            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("@PoolCampusPlacementTestId", DDLCompanyName.SelectedItem.Value);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                  TxtTestDate.Text = dt.Rows[0]["TestDate"].ToString();
                TxtTestStatus.Text = dt.Rows[0]["TestStatus"].ToString();
                // TxtUpdatedDate.Text = dt.Rows[0]["Updated_Date"].ToString();
                //TxtUpdatedBy.Text = dt.Rows[0]["Updated_By"].ToString();
            }
            try
            {
                if (a == 1)
                { }
            }
            catch (Exception)
            {
                LblErrorMsg.Visible = true;
                LblErrorMsg.Text = "connection doesnot exist";
            }

            finally
            {
                conn.Close();
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Schedular.aspx");
       
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
       
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (DDLCompanyName.Text == "")
            {

                string alert = "<script language=javascript>" + "alert('Please select the college to Update');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                //Response.Redirect("Pool_Campus_College_Master_Update.aspx");
                return;
            }


            // string UserID = "1";
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Pool_Campus_Recruitment_Plan_Schedular set  PoolCampusPlacementTestId=@PoolCampusPlacementTestId, TestDate=@TestDate, TestStatus=@TestStatus,   Is_Active=1, Updated_Date=@Updated_Date, Updated_By=@Updated_By where PoolCampusPlacementTestId=@PoolCampusPlacementTestId", conn);
            UpdateCmd.CommandType = CommandType.Text;
            UpdateCmd.Parameters.AddWithValue("@PoolCampusPlacementTestId", DDLCompanyName.Text);
            UpdateCmd.Parameters.AddWithValue("@TestDate", TxtTestDate.Text);
            UpdateCmd.Parameters.AddWithValue("@TestStatus", TxtTestStatus.Text);
            //UpdateCmd.Parameters.AddWithValue("@Updated_Date", TxtUpdatedDate.Text);
            //UpdateCmd.Parameters.AddWithValue("@Updated_By", TxtUpdatedBy.Text);
            UpdateCmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);
            UpdateCmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);
            conn.Open();
            UpdateCmd.ExecuteNonQuery();
            TxtTestDate.Text = "";
            TxtTestStatus.Text = "";
            //TxtUpdatedBy.Text = "";
            //TxtUpdatedDate.Text = "";
            string aler = "<script language=javascript>" + "alert('Updated Successfully');" + "</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = UpdateCmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Recruitment_Plan_Schedular");
            //GridView1.DataSourceID = null;
            //GridView1.DataSource = ds;
            //grdsched.DataBind();
            conn.Close();
           // Response.Redirect("Pool_Campus_College_Master_Update.aspx");
            return;
        }

        protected void DDLCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLCompanyName.SelectedIndex != -1)
            {
                FetchProductData();
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