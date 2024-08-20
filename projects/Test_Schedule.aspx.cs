using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace Project
{
    public partial class Test_Schedule : System.Web.UI.Page
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
                loaddepart();
                

               
           
        }

       /* private void BindControlvalues()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select c.CompanyId,r.TestDate,r.TestTime,r.Test_Place from Recruitment_Plan_Schedular r,Company_Master where r.CompanyId=" + userid, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            //lblUsername.Text = ds.Tables[0].Rows[0][1].ToString();
            //txtfname.Text = ds.Tables[0].Rows[0][2].ToString();
            //txtlname.Text = ds.Tables[0].Rows[0][3].ToString();
            //txtemail.Text = ds.Tables[0].Rows[0][4].ToString();
            Drp_dwn_Company.Text = ds.Tables[0].Rows[0]["CompanyId"].ToString();
            TextDate.Text = ds.Tables[0].Rows[0]["TestDate"].ToString();
            Texttime.Text = ds.Tables[0].Rows[0]["TestTime"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["Test_Place"].ToString();
            //Txt_PlacementId.Text = ds.Tables[0].Rows[0]["PlacementTestId"].ToString();
            //Txt_Status.Text = ds.Tables[0].Rows[0]["TestStatus"].ToString();
        }*/

       /* private void BindGridview()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Recruitment_Plan_Schedular r,Company_Master c where r.CompanyId=c.CompanyId", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridLoad.DataSource = ds;
            GridLoad.DataBind();
        }*/        
        public void loaddepart()
        {
            
            if (!IsPostBack)
            {
                DDLDataSource();
                DDLDatacompany();
           /*     BindGridview();
               BindControlvalues();*/
                
            }
        }
        private void DDLDataSource()
        {
            Drp_dwn_Company.Items.Add(new ListItem("@--Select Company which are to be Scheduled--@", ""));
            Drp_dwn_Company.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Company_Master where Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            Drp_dwn_Company.DataSource = dt;
            Drp_dwn_Company.DataTextField = "CompanyName";
            Drp_dwn_Company.DataValueField = "CompanyId";
            Drp_dwn_Company.DataBind();
            try
            {
                if (a == 1)
                { }
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "connection doesnot exist";
            }
            finally
            {
                conn.Close();
            }
        }
        private void DDLDatacompany()
        {

            DropDownList1.Items.Add(new ListItem("@--List Of Company Which are already Scheduled or Edit--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            //string queryString = "SELECT * FROM Company_Master where Is_Active=1";
            string queryString = "SELECT * from Company_Master cm,Recruitment_Plan_Schedular r WHERE r.CompanyId=cm.CompanyId and r.Is_Active=1 order by r.TestDate";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "CompanyName";
            DropDownList1.DataValueField = "CompanyId";
            DropDownList1.DataBind();
            try
            {
                
                    conn.Open();
                    comm.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "connection doesnot exist";
            }
            finally
            {
                conn.Close();
            }
        }


        private void FetchProductDataCompany()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "select cm.CompanyName, r.Updated_Date,r.Updated_By,r.Test_Place,r.TestDate,r.TestTime from Recruitment_Plan_Schedular r,Company_Master cm where cm.CompanyName=@CompanyName and r.CompanyId=cm.CompanyId and r.Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("CompanyName",DropDownList1.SelectedItem.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                Drp_dwn_Company.SelectedItem.Text = dt.Rows[0]["CompanyName"].ToString();
                TextDate.Text = dt.Rows[0]["TestDate"].ToString();
                Texttime.Text = dt.Rows[0]["TestTime"].ToString();
                TextBox3.Text = dt.Rows[0]["Test_Place"].ToString();
                
                Txt_updby.Text = dt.Rows[0]["Updated_By"].ToString();
            }

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "saved successfully";
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "could not be saved";
            }
            finally
            {
                conn.Close();
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextDate.Text.Replace("&nbsp;", "").Trim() == "" || Texttime.Text.Replace("&nbsp;", "").Trim() == "" || TextBox3.Text.Replace("&nbsp;", "").Trim() == "" || Drp_dwn_Company.Text.Replace("&nbsp;", "").Trim() == "")
            {
                string alert = "<script language=javascript>" + "alert('Data Required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                return;
            }

            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            
            SqlCommand Updatecmd = new SqlCommand("Save_Recruitment_Plan_Schedular", conn);
            Updatecmd.CommandType = CommandType.StoredProcedure;
            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
            Updatecmd.Parameters.AddWithValue("@CompanyId", SqlDbType.Int).Value = Drp_dwn_Company.SelectedItem.Value;
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now;
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@TestDate", SqlDbType.Date).Value = TextDate.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@TestTime", SqlDbType.Time).Value = Texttime.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Test_Place", SqlDbType.VarChar).Value = TextBox3.Text.Trim();
           
            
           
            Updatecmd.Connection = conn;
            TextDate.Text = "";
            Texttime.Text = "";
            TextBox3.Text = "";
            Drp_dwn_Company.Text = "";
            Txt_updby.Text = "";
            conn.Open();
            Updatecmd.ExecuteNonQuery();
            /*try
            {
                conn.Open();
                Updatecmd.ExecuteNonQuery();
                lblErrMsg.Visible = true;
                Response.Redirect("Test_Schedule.aspx");
                lblErrMsg.Text = "saved successfully";
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "could not be saved, Fill all the Fields";
            }
            finally
            {

                conn.Close();
            }*/
        }
           
        
        protected void delbutton_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);

            string queryString = "Update Recruitment_Plan_Schedular set Is_Active=0 where CompanyId = @CompanyId";
            SqlCommand Delcmd = new SqlCommand(queryString, conn);
            Delcmd.CommandType = CommandType.Text;
            Delcmd.Parameters.AddWithValue("@CompanyId",SqlDbType.Int).Value= DropDownList1.SelectedItem.Value;

            conn.Open();
            Delcmd.ExecuteNonQuery();
            TextDate.Text = "";
            Texttime.Text = "";
            TextBox3.Text = "";
            Drp_dwn_Company.Text = "";
            Txt_updby.Text = "";

            try
            {

                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Record Deleted successfully";
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "could not be deleted";
            }
            finally
            {

                conn.Close();
            }
        }
        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            TextDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Texttime.Text = Calendar1.SelectedDate.ToShortTimeString();
            Calendar1.Visible = false;
        }
        protected void calbutton_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void CLRBUTTON_Click1(object sender, EventArgs e)
        {
            TextDate.Text = "";
            Texttime.Text = "";
            TextBox3.Text = "";
            Drp_dwn_Company.Text = "";
            
            Txt_updby.Text = "";
            Response.Redirect("Test_Schedule.aspx");
        }
       

        protected void Img_Select_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void Img_Selects_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void Img_Schedule_Click(object sender, ImageClickEventArgs e)
        {

        }

       

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedIndex != -1)
            {
                FetchProductDataCompany();
            }
        }

        protected void Drp_dwn_Company_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Btn_SndMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("Send_Mail.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }       
    }
    
}

  