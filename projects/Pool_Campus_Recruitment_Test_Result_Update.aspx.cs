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
    public partial class Pool_Campus_Recruitment_Test_Result_Update : System.Web.UI.Page
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
            DDlCmpName.Items.Add(new ListItem("@--Select College Name--@", ""));
            DDlCmpName.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "select * from Pool_Campus_Company_College_Config p,Company_Master m,Pool_Campus_Recruitment_Plan_Master c,Pool_Campus_Recruitment_Test_Result rt where m.CompanyId=p.CompanyId and p.PoolCampusCompanyCollegeId=c.PoolCampusCompanyCollegeId and rt.PoolCampusPlacementTestId=c.PoolCampusPlacementTestId and rt.Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDlCmpName.DataSource = dt;
            DDlCmpName.DataTextField = "CompanyName";
            DDlCmpName.DataValueField = "PoolCampusPlacementTestId";
            DDlCmpName.DataBind();
            
             
        }
        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Pool_Campus_Recruitment_Test_Result WHERE PoolCampusPlacementTestId=@PoolCampusPlacementTestId and Is_Active=1 ";
            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("@PoolCampusPlacementTestId", DDlCmpName.SelectedItem.Value);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                 TxtStudentId.Text = dt.Rows[0]["StudentId"].ToString();
                TxtResult.Text = dt.Rows[0]["Result"].ToString();
                TxtDescription.Text = dt.Rows[0]["Description"].ToString();
                //TxtUpdatedDate.Text = dt.Rows[0]["Updated_Date"].ToString();
                //TxtUpdatedBy.Text = dt.Rows[0]["Updated_By"].ToString();
            }
             
                conn.Close();
            }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Test_Result.aspx");
        }
        




        

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
     
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Pool_Campus_Recruitment_Test_Result set PoolCampusPlacementTestId=@PoolCampusPlacementTestId,   StudentId=@StudentId, Result=@Result , Description=@Description, Is_Active=1, Updated_Date=@Updated_Date, Updated_By=@Updated_By where PoolCampusPlacementTestId=@PoolCampusPlacementTestId", conn);
            UpdateCmd.CommandType = CommandType.Text;
            UpdateCmd.Parameters.AddWithValue("@PoolCampusPlacementTestId", DDlCmpName.Text);
            UpdateCmd.Parameters.AddWithValue("@StudentId", TxtStudentId.Text);
            UpdateCmd.Parameters.AddWithValue("@Result", TxtResult.Text);
            //UpdateCmd.Parameters.AddWithValue("@WebSite", TxtWebSite.Text);
            UpdateCmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
            UpdateCmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);
            UpdateCmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);
            conn.Open();
            UpdateCmd.ExecuteNonQuery();
            string aler = "<script language=javascript>" + "alert('Updated Successfully');" + "</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = UpdateCmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Recruitment_Test_Result");
            //GridView1.DataSourceID = null;
            //GridView1.DataSource = ds;
            //grdsched.DataBind();
            conn.Close();
            Response.Redirect("Pool_Campus_Recruitment_Test_Result.aspx");
            return;
        }

 

        protected void DDlCmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDlCmpName.SelectedIndex != -1)
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