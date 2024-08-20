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
    public partial class For_Student_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loaddepart();
        }
        public void loaddepart()
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
            if (!IsPostBack)
            {
                DDLDataSource();
                grd_varifydata();
            }
        }

        private void grd_varifydata()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select USN from Student_Config where Is_Verified=0",conn);
            

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);

            grd_varify.DataSource = ds;
            grd_varify.DataBind();
        }
        private void DDLDataSource()
        {
            DropDownList1.Items.Add(new ListItem("@--Select USN--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Student_Config where Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "USN";
            DropDownList1.DataValueField = "USN";
            DropDownList1.DataBind();
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
        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Student_Config where USN=@USN and Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("USN", DropDownList1.SelectedItem.Value);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                TextBox1.Text = dt.Rows[0]["USN"].ToString();
                Txt_lname.Text = dt.Rows[0]["Last_Name"].ToString();
                Txt_mname.Text = dt.Rows[0]["Middle_Name"].ToString();
                Txt_fname.Text = dt.Rows[0]["First_Name"].ToString();
                Txt_Gender.Text = dt.Rows[0]["Gender"].ToString();

                Txt_cntc.Text = dt.Rows[0]["Phone"].ToString();
                Txt_mail.Text = dt.Rows[0]["Email"].ToString();
                Txt_dept.Text = dt.Rows[0]["DepartmentId"].ToString();
                Txt_clgid.Text = dt.Rows[0]["CollegeId"].ToString();
                Txt_crsid.Text = dt.Rows[0]["CourseId"].ToString();
                Txt_dob.Text = dt.Rows[0]["Date_Of_Birth"].ToString();
                Txt_paddress.Text = dt.Rows[0]["Present_Address"].ToString();
                Txt_pmt_address.Text = dt.Rows[0]["Permenant_Address"].ToString();
                Txt_sameas.Text = dt.Rows[0]["Same_As_Cur_Add"].ToString();
                Txt_gap_Study.Text = dt.Rows[0]["Gap_In_Studies"].ToString();


            }
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




















        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            Panel_delete.Visible = false;
            Panel_Search.Visible = true;
            Panel_view.Visible = false;
        }

        protected void Btn_View_Click(object sender, EventArgs e)
        {
            PNL_EDIT_AND_SEARCH.Visible = false;
            Panel_delete.Visible = false;
            Panel_Search.Visible = false;
            Panel_view.Visible = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("select USN,First_Name,Last_Name,Gender,Phone,Email,Present_Address,LoginType from Student_Config", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grid_All_Student.DataSource = ds;
            Grid_All_Student.DataBind();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            Panel_delete.Visible = true;
            Panel_Search.Visible = false;
            Panel_view.Visible = false;
        }

        protected void Btn_Del_Click(object sender, EventArgs e)
        {

            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("update Student_Config set Is_Active = 0 where USN = '" + Txt_USN.Text + "' ", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != -1)
            {
                FetchProductData();
                PNL_EDIT_AND_SEARCH.Visible = true;
            }
        }


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            PNL_EDIT_AND_SEARCH.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /* if (Txt_gap_Study.Text==1)
             {
                 Response.Redirect("Gap_In_Study.aspx");
             }
                 else
             {
                 Response.Redirect("Student_Academic_Details.aspx");
             }*/

        }

        protected void Btn_not_Verify_Click(object sender, EventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("update Student_Config set Is_Verified = 1 where USN = '" + TextBox1.Text + "' ", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("College_Admin_Home_Page.aspx");
        }

        protected void Btn_View_gap_Click(object sender, EventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Gap_In_Study where USN = @USN", conn);
            cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grid_gap.DataSource = ds;
            Grid_gap.DataBind();
        }

        protected void Btn_Academic_Click(object sender, EventArgs e)
        {
            Grid_gap.Visible = false;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Year,Percentage,School,Board from SSLC where USN = @USN", conn);
            cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            grid_Acd.DataSource = ds;
            grid_Acd.DataBind();
        }

        protected void btn_diploma_Click(object sender, EventArgs e)
        {

            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Diploma_Year,Diploma_Percentage,Diploma_College,Diploma_Branch,Diploma_University from Diploma where USN = @USN", conn);
            cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grd_diploma.DataSource = ds;
            Grd_diploma.DataBind();
        }

        protected void btn_puc_Click(object sender, EventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select PUC_Year,PUC_Percentage,PUC_College,PUC_Branch,PUC_University from PUC where USN = @USN", conn);
            cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grd_puc.DataSource = ds;
            Grd_puc.DataBind();
        }

        protected void btn_ug_Click(object sender, EventArgs e)
        {

            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select UG_Year,UG_Percentage,UG_College,UG_Branch,UG_University from UG where USN = @USN", conn);
            cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grd_ug.DataSource = ds;
            Grd_ug.DataBind();
        }

        protected void btn_pg_Click(object sender, EventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select PG_Year,PG_Percentage,PG_College,PG_Class,PG_University from Student_Acadamics_Details where USN = @USN", conn);
            cmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Close();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Grd_pg.DataSource = ds;
            Grd_pg.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}

        
        
        

        
    
