using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Final_Report_SMPS
{
    public partial class Update_Other_College_Detail : System.Web.UI.Page
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
            BtnEdit.Attributes.Add("onclick", "javascript:alert('Updated successfully');");
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
            DDLCollegeName. Items.Add(new ListItem("@--Select College Name--@", ""));
            DDLCollegeName.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Pool_Campus_College_Master where Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
             int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLCollegeName.DataSource = dt;
            DDLCollegeName.DataTextField = "CollegeName";
            DDLCollegeName.DataValueField = "PoolCampusCollegeId";
            DDLCollegeName.DataBind();
            //try
            //{
            //    if (a == 1)
            //    { }
            //}
            //catch (Exception)
            //{
            //    LblErrorMsg.Visible = true;
            //    LblErrorMsg.Text = "connection doesnot exist";
            //}
            //finally
            //{
            //    conn.Close();
            //} 
        }
        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Pool_Campus_College_Master WHERE PoolCampusCollegeId=@PoolCampusCollegeId ";
            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("@PoolCampusCollegeId", DDLCollegeName.SelectedItem.Value);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                //DDLCmpName.Text = dt.Rows[0]["CompanyNameId"].ToString();
                TxtCollAddrs. Text = dt.Rows[0]["CollegeAddress"].ToString();
                TxtContactNo. Text = dt.Rows[0]["ContactNumber"].ToString();
                TxtWebSite .Text = dt.Rows[0]["WebSite"].ToString();
                TxtDescription. Text = dt.Rows[0]["Description"].ToString();
                //TxtUpdatedDate.Text = dt.Rows[0]["Updated_Date"].ToString();
                //TxtUpdatedBy.Text = dt.Rows[0]["Updated_By"].ToString();
            }
            //try
            //{
            //    if (a == 1)
            //    { }
            //}
            //catch (Exception)
            //{
            //    LblErrorMsg.Visible = true;
            //    LblErrorMsg.Text = "connection doesnot exist";
            //}

            //finally
            //{
            //    conn.Close();
            //}
        }
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
           
            
           

            if (DDLCollegeName.Text == "")
            {

                string alert = "<script language=javascript>" + "alert('Please select the college to Update');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                Response.Redirect("Pool_Campus_College_Master_Update.aspx");
                return;
            }


           // string UserID = "1";
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Pool_Campus_College_Master set    CollegeAddress=@CollegeAddress, ContactNumber=@ContactNumber, WebSite=@WebSite, Description=@Description, Is_Active=1, Updated_Date=@Updated_Date, Updated_By=@Updated_By where PoolCampusCollegeId=@PoolCampusCollegeId", conn);
            //UpdateCmd.CommandType = CommandType.Text;
            UpdateCmd.Parameters.AddWithValue("@PoolCampusCollegeId", DDLCollegeName.Text);
            UpdateCmd.Parameters.AddWithValue("@CollegeAddress", TxtCollAddrs.Text);
            UpdateCmd.Parameters.AddWithValue("@ContactNumber", TxtContactNo.Text);
            UpdateCmd.Parameters.AddWithValue("@WebSite", TxtWebSite.Text);
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
            da.Fill(ds, "Pool_Campus_College_Master");
            //GridView1.DataSourceID = null;
            //GridView1.DataSource = ds;
            //grdsched.DataBind();
            conn.Close();
            Response.Redirect("Pool_Campus_College_Master_Update.aspx");
            return;
            
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_College_Master.aspx");
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        protected void DDLCollegeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLCollegeName. SelectedIndex != -1)
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
