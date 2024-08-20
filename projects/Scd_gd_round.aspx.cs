using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    public partial class Scd_gd_round : System.Web.UI.Page
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
        public void loaddepart()
        {
            if (!IsPostBack)
            {
                DDLDataSource();
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT sc.First_Name,sc.Middle_Name,sc.Last_Name,sc.Phone,sc.Email,sc.DepartmentId, cm.CompanyName FROM Wrt_Tst_Result wr,Company_Master cm, Student_Config sc WHERE wr.USN=@USN and cm.CompanyId=wr.CompanyId";

            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("USN", SqlDbType.VarChar).Value = Text_USN.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {

                Txt_fname.Text = dt.Rows[0]["First_Name"].ToString();
                Txt_mname.Text = dt.Rows[0]["Middle_Name"].ToString();
                Txt_lname.Text = dt.Rows[0]["Last_Name"].ToString();
                Txt_cntc.Text = dt.Rows[0]["Phone"].ToString();
                Txt_mail.Text = dt.Rows[0]["Email"].ToString();
                Text_Dept.Text = dt.Rows[0]["DepartmentId"].ToString();
                Drp_dwn_Company.SelectedItem.Text = dt.Rows[0]["CompanyName"].ToString();


            }

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Data as been Fetched";
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Their is no Data in the List";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void calbutton_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            TextDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Texttime.Text = Calendar1.SelectedDate.ToShortTimeString();
            Calendar1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);

            //string queryString = "insert into Schedule_GD_Round(USN,CompanyId,Test_Date,Test_Time,Test_Place,Test_Type,Description,Is_Active,Updated_Date,Updated_By)values(@USN,@CompanyId,@Test_Date,@Test_Time,@Test_Place,@Test_Type,@Description,@Is_Active,@Updated_Date,@Updated_By)";
            //SqlCommand Updatecmd = new SqlCommand(queryString, conn);
            SqlCommand Updatecmd = new SqlCommand("Save_Schedule_GD_Round", conn);
            Updatecmd.CommandType = CommandType.StoredProcedure;


            Updatecmd.CommandType = CommandType.Text;
            Updatecmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Text_USN.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@CompanyId", SqlDbType.Int).Value = Drp_dwn_Company.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Test_Date", SqlDbType.Date).Value = TextDate.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Test_Time", SqlDbType.Time).Value = Texttime.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Test_Place", SqlDbType.VarChar).Value = TextBox3.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Test_Type", SqlDbType.VarChar).Value = Txt_Status.Text.Trim();

            Updatecmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Txt_Desc.Text.Trim();

            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
            
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now;
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
            Updatecmd.Connection = conn;
            TextDate.Text = "";
            Texttime.Text = "";
            TextBox3.Text = "";
            Txt_Desc.Text = "";
            
            Txt_Status.Text = "";

            Txt_updby.Text = "";



            try
            {
                conn.Open();
                Updatecmd.ExecuteNonQuery();
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Common objCommon = new Common();
            objCommon.SendMail(txtToMail.Text, txtSubject.Text, txtMailContent.Text, "FromMail", "FromPassword");

            lblStatus.Visible = true;
            lblStatus.Text = "Mail Sent Succcessfully";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }

        protected void Btn_del_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);

            string queryString = "Update Schedule_GD_Round set Is_Active=0 where USN= @USN";
            SqlCommand Delcmd = new SqlCommand(queryString, conn);
            Delcmd.CommandType = CommandType.Text;
            Delcmd.Parameters.AddWithValue("@USN", SqlDbType.Int).Value = Text_USN.Text.Trim();

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
    }
}