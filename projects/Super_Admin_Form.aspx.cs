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
    public partial class Super_Admin_Form : System.Web.UI.Page
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
                DDLDataCollege();
            }
        }

        private void DDLDataCollege()
        {
            Dd_CollegId.Items.Add(new ListItem("--Select College--", ""));
            Dd_CollegId.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            //string queryString = "SELECT * FROM Company_Master where Is_Active=1";
            string queryString = "SELECT * from College_Master where Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Dd_CollegId.DataSource = dt;
            Dd_CollegId.DataTextField = "CollegeName";
            Dd_CollegId.DataValueField = "CollegeId";
            Dd_CollegId.DataBind();
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

        private void DDLDataSource()
        {
            Dd_Role.Items.Add(new ListItem("--Select Role--", ""));
            Dd_Role.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Role_Master where Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            Dd_Role.DataSource = dt;
            Dd_Role.DataTextField = "RoleName";
            Dd_Role.DataValueField = "RoleId";
            Dd_Role.DataBind();
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

        protected void btnclgmaster_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        protected void btnrole_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
        }

        protected void btnuser_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
        }


       

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            //SqlCommand Updatecmd = new SqlCommand();
            conn.Open();
            SqlCommand Updatecmd = new SqlCommand("Insert_College_Master", conn);
            Updatecmd.CommandType = CommandType.StoredProcedure;
            Updatecmd.Connection = conn;
            //Updatecmd.CommandText = "insert into College_Master(CollegeName,CollegeAddress,ContactNumber,WebSite,Description,Is_Active,Updated_Date,Updated_By)values(@CollegeName,@CollegeAddress,@ContactNumber,@WebSite,@Description,@Is_Active,@Updated_Date,@Updated_By)";
            Updatecmd.Parameters.AddWithValue("@CollegeName", SqlDbType.VarChar).Value = Txt_ClgName.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Login_ID", SqlDbType.VarChar).Value = txt_lgn.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = txt_pwd.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Login_Type", SqlDbType.VarChar).Value = dl_lgntype.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@CollegeAddress", SqlDbType.VarChar).Value = Txt_Clg_Address.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@ContactNumber", SqlDbType.VarChar).Value = Txt_Phone.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@WebSite", SqlDbType.VarChar).Value = Txt__Website.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Txt_Description.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now.Date.ToShortDateString();
            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value =1;
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
            Updatecmd.ExecuteNonQuery();
            conn.Close();

        }


        protected void Btn_Add_Role_Click(object sender, EventArgs e)
        {
            
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
           // SqlCommand Updatecmd = new SqlCommand();
            conn.Open();
            SqlCommand Updatecmd = new SqlCommand("Insert_Role_Master", conn);
            Updatecmd.CommandType = CommandType.StoredProcedure;
            
            Updatecmd.Connection = conn;
            //Updatecmd.CommandText = "insert into Role_Master(RoleName,Description,Is_Active,Updated_Date,Updated_By)values(@RoleName,@Description,@Is_Active,@Updated_Date,@Updated_By)";
            Updatecmd.Parameters.AddWithValue("@RoleName", SqlDbType.VarChar).Value = Txt_role.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Txt_role_Description.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value =DateTime .Now .Date.ToShortDateString();
            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
            Updatecmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void Btn_Add_User_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            //SqlCommand Updatecmd = new SqlCommand();
            conn.Open();
            SqlCommand Updatecmd = new SqlCommand("Insert_User_Master", conn);
            Updatecmd.CommandType = CommandType.StoredProcedure;            
            conn.Open();
            Updatecmd.Connection = conn;
            //Updatecmd.CommandText = "insert into Users_Master(UserName,UserPassword,RoleId,CollegeId,Description,Is_Active,Updated_Date,Updated_By)values(@UserName,@UserPassword,@RoleId,@CollegeId,@Description,@Is_Active,@Updated_Date,@Updated_By)";

            Updatecmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = Txt_User_Name.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@UserPassword", SqlDbType.VarChar).Value = Txt_User_Password.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@RoleId", SqlDbType.Int).Value = Dd_Role.SelectedItem.Value;
            Updatecmd.Parameters.AddWithValue("@CollegeId", SqlDbType.Int).Value = Dd_CollegId.SelectedItem.Value;
            Updatecmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Txt__User_Description.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now.Date.ToShortDateString();
            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
            Updatecmd.ExecuteNonQuery();
            Txt_User_Name.Text = "";
            Dd_Role.Text = "";
            Dd_CollegId.Text = "";
            Txt__User_Description.Text = "";
            Txt_updby.Text = "";

            conn.Close();

        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand();
            conn.Open();
            Updatecmd.Connection = conn;
            Updatecmd.CommandText = "Update College_Master set Is_Active=0 where CollegeName=@CollegeName";
            Updatecmd.Parameters.AddWithValue("@CollegeName", SqlDbType.VarChar).Value = Txt_ClgName.Text.Trim();
            Updatecmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand();
            Updatecmd.CommandText = "Select * from College_Master where CollegeName=@CollegeName and Is_Active=1";
            SqlDataAdapter da = new SqlDataAdapter(Updatecmd);
            Updatecmd.Parameters.AddWithValue("@CollegeName", SqlDbType.VarChar).Value = Txt_ClgName.Text.Trim();
            conn.Open();
            Updatecmd.Connection = conn;
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            
            if (dt != null && dt.Rows.Count > 0)
            {
               
                Txt_Clg_Address.Text = dt.Rows[0]["CollegeAddress"].ToString();
                Txt_Phone.Text = dt.Rows[0]["ContactNumber"].ToString();
                Txt__Website.Text = dt.Rows[0]["WebSite"].ToString();
                Txt_Description.Text = dt.Rows[0]["Description"].ToString();
                Updatecmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void Btn_Delete_Role_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand();
            conn.Open();
            Updatecmd.Connection = conn;
            Updatecmd.CommandText = "Update Role_Master set Is_Active=0 where RoleName=@RoleName";
            Updatecmd.Parameters.AddWithValue("@RoleName", SqlDbType.VarChar).Value = Txt_role.Text.Trim();
            Updatecmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void Btn_Delete_User_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand();
            conn.Open();
            Updatecmd.Connection = conn;
            Updatecmd.CommandText = "Update Users_Master set Is_Active=0 where UserName=@UserName ";
            Updatecmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = Txt_User_Name.Text.Trim();
            Updatecmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void Btn_Search_Role_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand();
            Updatecmd.CommandText = "Select * from Role_Master where RoleName=@RoleName and Is_Active=1";
            SqlDataAdapter da = new SqlDataAdapter(Updatecmd);
            Updatecmd.Parameters.AddWithValue("@RoleName", SqlDbType.VarChar).Value = Txt_role.Text.Trim();
            conn.Open();
            Updatecmd.Connection = conn;
            Updatecmd.ExecuteNonQuery();
            
            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            if (dt != null && dt.Rows.Count > 0)
            {
                Txt_role_Description.Text = dt.Rows[0]["Description"].ToString();

               
            }
            
        }

        protected void Btn_search_User_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand();
            Updatecmd.CommandText = "Select * from Users_Master u,Role_Master ,College_Master  where UserName=@UserName and u.Is_Active=1";
            Updatecmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = Txt_User_Name.Text.Trim();
            Updatecmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(Updatecmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Open();
            if (dt != null && dt.Rows.Count > 0)
            {
                Updatecmd.ExecuteNonQuery();
                conn.Close();
                Txt__User_Description.Text = dt.Rows[0]["Description"].ToString();
                Dd_Role.SelectedItem.Text = dt.Rows[0]["RoleName"].ToString();
                Dd_CollegId.SelectedItem.Text = dt.Rows[0]["CollegeName"].ToString();
                Txt__User_Description.Text = dt.Rows[0]["CollegeId"].ToString();
            }
        }

        protected void Btn_View_Click(object sender, EventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select CollegeName,Login_ID,Password,ContactNumber,CollegeAddress,WebSite from College_Master where Is_Active=1", conn);
            

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grd_College.DataSource = ds;
            Grd_College.DataBind();
        }

        protected void Btn_role_View_Click(object sender, EventArgs e)
        {
           string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select RoleName,Description from Role_Master where Is_Active=1", conn);
            

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grd_Role.DataSource = ds;
            Grd_Role.DataBind(); 
        }

        protected void Btn_user_view_Click(object sender, EventArgs e)
        {
            
                string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select UserName,UserPassword,Description from Users_Master where Is_Active=1", conn);
           

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grd_User.DataSource = ds;
            Grd_User.DataBind(); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}