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
    public partial class PooL_Campus_Company_Criteria_Update : System.Web.UI.Page
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
            //if (!IsPostBack)
            {
                DDLCmpName();
            }
        }

        private void DDLCmpName()
        {
            DDlCompanyName.Items.Add(new ListItem("@--Select College Name--@", ""));
            DDlCompanyName.AppendDataBoundItems = true;

            string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connstr);
            string query = " select * from  Company_Master m ,Pool_Campus_Company_Placement_Criteria p,  Pool_Campus_Company_College_Config c where c.CompanyId=m.CompanyId and  c.PoolCampusCompanyCollegeId=p.PoolCampusCompanyCollegeId   and p.Is_Active=1 ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DDlCompanyName.DataSource = ds;
            DDlCompanyName.DataTextField = "CompanyName";
            DDlCompanyName.DataValueField = "PoolCampusCompanyCollegeId";
            DDlCompanyName.DataBind();
        }


        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Pool_Campus_Company_Placement_Criteria WHERE PoolCampusCompanyCollegeId=@PoolCampusCompanyCollegeId  and Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("@PoolCampusCompanyCollegeId", DDlCompanyName.SelectedItem.Value);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                //DDLCmpName.Text = dt.Rows[0]["CompanyNameId"].ToString();
                TxtCutOfType.Text = dt.Rows[0]["CutOffType"].ToString();
                TxtCutOfTenth.Text = dt.Rows[0]["CutOffTenth"].ToString();
                TxtCutOfTwelth.Text = dt.Rows[0]["CutOffTwelth"].ToString();
                TxtCutOfDegree.Text = dt.Rows[0]["CutOffDegree"].ToString();
               // RdYes.Checked = (bool)dt.Rows[0]["GapInYearsAllowedFlag"];//.ToString();
                //RdNo.Checked = (bool)dt.Rows[0]["GapInYearsAllowedFlag"];//.ToString();
                //RdBackLogAllowedYes.Checked = (bool)dt.Rows[0]["BackLogAllowedFlag"];//.ToString();
                //RdBackLogNotAllowed.Checked = (bool)dt.Rows[0]["BackLogAllowedFlag"];//.ToString();
           
                TxtDescription.Text = dt.Rows[0]["Description"].ToString();
                //TxtUpdatedDate.Text = dt.Rows[0]["Updated_Date"].ToString();
                //TxtUpdatedBy.Text = dt.Rows[0]["Updated_By"].ToString();

            }
            /*try
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
            }*/
        }



        

        
        protected void BtnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Company_Placement_Criteria.aspx");
       
        }

        protected void BtnHome_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
      
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            if (DDlCompanyName.Text == "")
            {

                string alert = "<script language=javascript>" + "alert('Please select the college to Update');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                Response.Redirect("Pool_Campus_Company_Criteria_Update.aspx");
                return;
            }


            // string UserID = "1";
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Pool_Campus_Company_Placement_Criteria set CutOffType=@CutOffType, CutOffTenth=@CutOffTenth, CutOffTwelth=@CutOffTwelth,CutOffDegree=@CutOffDegree, GapInYearsAllowedFlag=@GapInYearsAllowedFlag,BackLogAllowedFlag =@BackLogAllowedFlag, Description=@Description, Is_Active=1, Updated_Date=@Updated_Date, Updated_By=@Updated_By where  PoolCampusCompanyCollegeId='" + DDlCompanyName.SelectedItem.Value + "'", conn);
            UpdateCmd.CommandType = CommandType.Text;
           // UpdateCmd.Parameters.AddWithValue("@PoolCampusCompanyCollegeId", SqlDbType.Int).Value = DDlCompanyName.SelectedItem.Text;
            
            UpdateCmd.Parameters.AddWithValue("@CutOffType", TxtCutOfType. Text);
            UpdateCmd.Parameters.AddWithValue("@CutOffTenth",  TxtCutOfTenth. Text);
            UpdateCmd.Parameters.AddWithValue("@CutOffTwelth", TxtCutOfTwelth .Text);
            UpdateCmd.Parameters.AddWithValue("@CutOffDegree", TxtCutOfDegree. Text);
            if (RdYes. Checked == true)
            {
                UpdateCmd.Parameters.AddWithValue("@GapInYearsAllowedFlag", true);
            }
            else
            {
                UpdateCmd.Parameters.AddWithValue("@GapInYearsAllowedFlag", false);
            }

            if (RdBackLogAllowedYes.Checked == true)
            {
                UpdateCmd.Parameters.AddWithValue("@BackLogAllowedFlag",SqlDbType.Bit).Value=1;
            }
            else
            {
                UpdateCmd.Parameters.AddWithValue("@BackLogAllowedFlag",SqlDbType.Bit).Value=0;
            }
            UpdateCmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
            UpdateCmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);
            UpdateCmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);
            conn.Open();
            UpdateCmd.ExecuteNonQuery();
            string aler = "<script lbanguage=javascript>" + "alert('Updated Successfully');" + "</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = UpdateCmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Company_Placement_Criteria");
            //GridView1.DataSourceID = null;
            //GridView1.DataSource = ds;
            //grdsched.DataBind();
            conn.Close();
            Response.Redirect("Pool_Campus_Company_Placement_Criteria.aspx");
            return;
        }

         

        protected void DDlCompanyName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (DDlCompanyName.SelectedIndex != -1)
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