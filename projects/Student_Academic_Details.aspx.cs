using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Project
{
    public partial class Student_Academic_Details : System.Web.UI.Page
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
            Pnl10th.Visible = false;
            pnldiploma.Visible = false;
            pnlpuc.Visible = false;
            pnlpg.Visible = false;
            pnlug.Visible = false;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            string query = "select USN from Student_Config";
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            //SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            conn.Open();
            //cmd.Connection = conn;


            if (DropDown_Academic.Text == "SSLC")
            {
                //cmd.CommandText = "insert into SSLC(USN,Year,Percentage,School,Board)values(@USN,@Year,@Percentage,@School,@Board)";
               //CommandType  = CommandType.StoredProcedure;
                
                SqlCommand cmd = new SqlCommand("Insert_SSLC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();
                cmd.Parameters.AddWithValue("@Year", SqlDbType.Int).Value = Txt_yr_Psng.Text.Trim();
                cmd.Parameters.AddWithValue("@Percentage", SqlDbType.VarChar).Value = Txt_pertge.Text.Trim();
                cmd.Parameters.AddWithValue("@School", SqlDbType.VarChar).Value = Txt_clg.Text.Trim();
                cmd.Parameters.AddWithValue("@Board", SqlDbType.VarChar).Value = Txt_brd.Text.Trim();
                dr = cmd.ExecuteReader();
                Lbl_msg.Text = "SSLC SAVED SUCCESSFULLY";
                Lbl_msg.Visible = true;

                string queryString = "Select * from SSLC";
                SqlCommand comm = new SqlCommand(queryString, conn);
                comm.Parameters.AddWithValue("USN", Txt_USN.Text.Trim());

                

            }

            else if (DropDown_Academic.Text == "Diploma")
            {
                SqlCommand cmd = new SqlCommand("Insert_Diploma", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
              
              //  cmd.CommandText = "insert into Diploma(USN,Diploma_Year,Diploma_Percentage,Diploma_Branch,Diploma_College,Diploma_University)values(@Diploma_USN,@Diploma_Year,@Diploma_Percentage,@Diploma_Branch,@Diploma_College,@Diploma_University)";
                cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();
                cmd.Parameters.AddWithValue("@Diploma_Year", SqlDbType.Int).Value = Txt_yr_Psng.Text.Trim();
                cmd.Parameters.AddWithValue("@Diploma_Percentage", SqlDbType.VarChar).Value = Txt_pertge.Text.Trim();
                cmd.Parameters.AddWithValue("@Diploma_Branch", SqlDbType.VarChar).Value = Txt_Branch.Text.Trim();
                cmd.Parameters.AddWithValue("@Diploma_College", SqlDbType.VarChar).Value = Txt_clg.Text.Trim();
                cmd.Parameters.AddWithValue("@Diploma_University", SqlDbType.VarChar).Value = Txt_brd.Text.Trim();
                dr = cmd.ExecuteReader();
                Lbl_msg.Text = "Diploma SAVED SUCCESSFULLY";
                Lbl_msg.Visible = true;
            }
            else if (DropDown_Academic.Text == "PUC")
            {
                SqlCommand cmd = new SqlCommand("Insert_PUC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.CommandText = "insert into PUC(USN,PUC_Year,PUC_Percentage,PUC_Branch,PUC_College,PUC_University)values(@USN,@PUC_Year,@PUC_Percentage,@PUC_Branch,@PUC_College,@PUC_University)";
                cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();
                cmd.Parameters.AddWithValue("@PUC_Year", SqlDbType.Int).Value = Txt_yr_Psng.Text.Trim();
                cmd.Parameters.AddWithValue("@PUC_Percentage", SqlDbType.VarChar).Value = Txt_pertge.Text.Trim();
                cmd.Parameters.AddWithValue("@PUC_Branch", SqlDbType.VarChar).Value = Txt_Branch.Text.Trim();
                cmd.Parameters.AddWithValue("@PUC_College", SqlDbType.VarChar).Value = Txt_clg.Text.Trim();
                cmd.Parameters.AddWithValue("@PUC_University", SqlDbType.VarChar).Value = Txt_brd.Text.Trim();
                dr = cmd.ExecuteReader();
                Lbl_msg.Text = "PUC SAVED SUCCESSFULLY";
                Lbl_msg.Visible = true;
            }
            else if (DropDown_Academic.Text == "UG")
            {
                SqlCommand cmd = new SqlCommand("Insert_UG", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                //cmd.CommandText = "insert into UG(USN,UG_Year,UG_Percentage,UG_Branch,UG_College,UG_University)values(@USN,@UG_Year,@UG_Percentage,@UG_Branch,@UG_College,@UG_University)";
                cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();
                cmd.Parameters.AddWithValue("@UG_Year", SqlDbType.Int).Value = Txt_yr_Psng.Text.Trim();
                cmd.Parameters.AddWithValue("@UG_Percentage", SqlDbType.VarChar).Value = Txt_pertge.Text.Trim();
                cmd.Parameters.AddWithValue("@UG_Class", SqlDbType.VarChar).Value = Txt_Branch.Text.Trim();
                cmd.Parameters.AddWithValue("@UG_College", SqlDbType.VarChar).Value = Txt_clg.Text.Trim();
                cmd.Parameters.AddWithValue("@UG_Branch", SqlDbType.VarChar).Value = Txt_Branch.Text.Trim();
                cmd.Parameters.AddWithValue("@UG_University", SqlDbType.VarChar).Value = Txt_brd.Text.Trim();
                dr = cmd.ExecuteReader();
                Lbl_msg.Text = "UG SAVED SUCCESSFULLY";
                Lbl_msg.Visible = true;
            }
            else if (DropDown_Academic.Text == "PG")
            {
                SqlCommand cmd = new SqlCommand("Insert_Student_Acadamics_Details", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.CommandText = "insert into Student_Acadamics_Details(USN,PG_Year,PG_Percentage,Is_Active,Updated_Date,Updated_By,PG_Class,PG_College,PG_University)values(@USN,@PG_Year,@PG_Percentage,@Is_Active,@Updated_Date,@Updated_By,@PG_Class,@PG_College,@PG_University)";
                cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();
                cmd.Parameters.AddWithValue("@PG_Year", SqlDbType.Int).Value = Txt_yr_Psng.Text.Trim();
                cmd.Parameters.AddWithValue("@PG_Percentage", SqlDbType.VarChar).Value = Txt_pertge.Text.Trim();
                cmd.Parameters.AddWithValue("@PG_Class", SqlDbType.VarChar).Value = Txt_Branch.Text.Trim();
                cmd.Parameters.AddWithValue("@PG_College", SqlDbType.VarChar).Value = Txt_clg.Text.Trim();
                cmd.Parameters.AddWithValue("@PG_University", SqlDbType.VarChar).Value = Txt_brd.Text.Trim();
                cmd.Parameters.AddWithValue("@Is_Active", SqlDbType.VarChar).Value = 1;
                cmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.VarChar).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
                dr = cmd.ExecuteReader();
                Lbl_msg.Text = "PG SAVED SUCCESSFULLY";
                Lbl_msg.Visible = true;
            }
            else
            {
                Lbl_msg.Text = "Login Failed! Invalid User name or Password";
                Lbl_msg.Visible = true;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Pnl10th.Visible = true;
            
             string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
              SqlConnection conn = new SqlConnection(connectionstring);
              string queryString = "Select * from SSLC where USN='" + Txt_USN.Text + "'";
              SqlCommand comm = new SqlCommand(queryString, conn);
              comm.Parameters.AddWithValue("USN", Txt_USN.Text.Trim());
              SqlDataAdapter da = new SqlDataAdapter(comm);
              DataTable dt = new DataTable();
              da.Fill(dt);
              if (dt != null && dt.Rows.Count > 0)
              {

                  Txt_10yer.Text = dt.Rows[0]["Year"].ToString();
                  txt_10perc.Text = dt.Rows[0]["Percentage"].ToString();
                  txt_10school.Text = dt.Rows[0]["School"].ToString();
                  txt_10brd.Text = dt.Rows[0]["Board"].ToString();

                           
                                 
               }
            
        }

        protected void btn_diploma_Click(object sender, EventArgs e)
        {
            pnldiploma.Visible = true;
            
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
              SqlConnection conn = new SqlConnection(connectionstring);
              string queryString = "Select * from Diploma where USN='" + Txt_USN.Text + "'";
              SqlCommand comm = new SqlCommand(queryString, conn);
              comm.Parameters.AddWithValue("USN", Txt_USN.Text.Trim());
              SqlDataAdapter da = new SqlDataAdapter(comm);
              DataTable dt = new DataTable();
              da.Fill(dt);
              if (dt != null && dt.Rows.Count > 0)
              {
                  txt_dpbrnch.Text = dt.Rows[0]["Diploma_Branch"].ToString();
                  txt_dpyr.Text = dt.Rows[0]["Diploma_Year"].ToString();
                  txt_dpper.Text = dt.Rows[0]["Diploma_Percentage"].ToString();
                  txt_dpcollege.Text = dt.Rows[0]["Diploma_College"].ToString();
                  txt_dpbrd.Text = dt.Rows[0]["Diploma_University"].ToString();
              }
        }

        protected void btn_puc_Click(object sender, EventArgs e)
        {
            pnlpuc.Visible = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
              SqlConnection conn = new SqlConnection(connectionstring);
              string queryString = "Select * from PUC where USN='" + Txt_USN.Text + "'";
              SqlCommand comm = new SqlCommand(queryString, conn);
              comm.Parameters.AddWithValue("USN", Txt_USN.Text.Trim());
              SqlDataAdapter da = new SqlDataAdapter(comm);
              DataTable dt = new DataTable();
              da.Fill(dt);
              if (dt != null && dt.Rows.Count > 0)
              {

                  txt_12brnch.Text = dt.Rows[0]["PUC_Branch"].ToString();
                  txt_12yr.Text = dt.Rows[0]["PUC_Year"].ToString();
                  txt_12per.Text = dt.Rows[0]["PUC_Percentage"].ToString();
                  txt_12coll.Text = dt.Rows[0]["PUC_College"].ToString();
                  txt_12uni.Text = dt.Rows[0]["PUC_University"].ToString();

              }
        }

        protected void btn_ug_Click(object sender, EventArgs e)
        {
            pnlug.Visible = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
              SqlConnection conn = new SqlConnection(connectionstring);
              string queryString = "Select * from UG where USN='" + Txt_USN.Text + "'";
              SqlCommand comm = new SqlCommand(queryString, conn);
              comm.Parameters.AddWithValue("USN", Txt_USN.Text.Trim());
              SqlDataAdapter da = new SqlDataAdapter(comm);
              DataTable dt = new DataTable();
              da.Fill(dt);
              if (dt != null && dt.Rows.Count > 0)
              {

                  txt_gdbrch.Text = dt.Rows[0]["UG_Branch"].ToString();
                  txt_gdyr.Text = dt.Rows[0]["UG_Year"].ToString();
                  txt_gdper.Text = dt.Rows[0]["UG_Percentage"].ToString();
                  txt_gdclg.Text = dt.Rows[0]["UG_College"].ToString();
                  txt_gdunst.Text = dt.Rows[0]["UG_University"].ToString();
              }

        }

        protected void btn_pg_Click(object sender, EventArgs e)
        {
            pnlpg.Visible = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
              SqlConnection conn = new SqlConnection(connectionstring);
              string queryString = "Select * from Student_Acadamics_Details where USN='" + Txt_USN.Text + "'";
              SqlCommand comm = new SqlCommand(queryString, conn);
              comm.Parameters.AddWithValue("USN", Txt_USN.Text.Trim());
              SqlDataAdapter da = new SqlDataAdapter(comm);
              DataTable dt = new DataTable();
              da.Fill(dt);
              if (dt != null && dt.Rows.Count > 0)
              {
                  txt_pgbrch.Text = dt.Rows[0]["PG_Class"].ToString();
                  txt_pgyr.Text = dt.Rows[0]["PG_Year"].ToString();
                  txt_pgper.Text = dt.Rows[0]["PG_Percentage"].ToString();
                  txt_pgclg.Text = dt.Rows[0]["PG_College"].ToString();
                  txt_pgunst.Text = dt.Rows[0]["PG_University"].ToString();
              }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}
      