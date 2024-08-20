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
    public partial class StudentEdit : System.Web.UI.Page
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
         if (!IsPostBack)
            {
                
                DDLDataSource();
                DeptDataSource();
            }
            
            
        }
        private void DeptDataSource()
        {
            DropDownList2.Items.Add(new ListItem("@--Select College--@", ""));
            DropDownList2.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT * from College_Master";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "CollegeName";
                DropDownList2.DataValueField = "CollegeId";
                DropDownList2.DataBind();
            }
        }

        private void DDLDataSource()
        {
            DropDownList1.Items.Add(new ListItem("@--Select Department--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {

                string queryString = "select * from Department_Master";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "Dept_Name";
                DropDownList1.DataValueField = "DepartmentId";
                DropDownList1.DataBind();
            }
        }

        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Student_Config where USN=@USN and Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("USN", TextBox2.Text.Trim());
            conn.Open();
            int a = comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                Txt_lname.Text = dt.Rows[0]["Last_Name"].ToString();
                Txt_mname.Text = dt.Rows[0]["Middle_Name"].ToString();
                Txt_fname.Text = dt.Rows[0]["First_Name"].ToString();

                Txt_cntc.Text = dt.Rows[0]["Phone"].ToString();
                Txt_mail.Text = dt.Rows[0]["Email"].ToString();
                DropDownList1.Text = dt.Rows[0]["DepartmentId"].ToString();
                DropDownList2.Text = dt.Rows[0]["CollegeId"].ToString();
                Txt_crsid.Text = dt.Rows[0]["CourseId"].ToString();
                Txt_dob.Text = dt.Rows[0]["Date_Of_Birth"].ToString();
                Txt_paddress.Text = dt.Rows[0]["Present_Address"].ToString();
                Txt_pmt_address.Text = dt.Rows[0]["Permenant_Address"].ToString();
                
                
                

                
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

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            FetchProductData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand Updatecmd = new SqlCommand();
            Updatecmd.Connection = conn;
           // Updatecmd.CommandText = "insert into Student_Config(USN,Password,Last_Name,Middle_Name,First_Name,Gender,Phone,Email,DepartmentId,CollegeId,CourseId,Date_Of_Birth,Present_Address,Permenant_Address,Same_As_Cur_Add,Gap_In_Studies,Gap_In_Study_Id,Is_Verified,Is_Active,Updated_Date,Updated_By,LoginType)Values(@USN,@Password,@Last_Name,@Middle_Name,@First_Name,@Gender,@Phone,@Email,@DepartmentId,@CollegeId,@CourseId,@Date_Of_Birth,@Present_Address,@Permenant_Address,@Same_As_Cur_Add,@Gap_In_Studies,@Gap_In_Study_Id,@Is_Verified,@Is_Active,@Updated_Date,@Updated_By,@LoginType)";
           Updatecmd.CommandText = "update Student_Config set Last_Name=@Last_Name,Middle_Name=@Middle_Name,First_Name=@First_Name,Gender=@Gender,Phone=@Phone,Email=@Email,DepartmentId=@DepartmentId,CollegeId=@CollegeId,CourseId=@CourseId,Date_Of_Birth=@Date_Of_Birth,Present_Address=@Present_Address,Permenant_Address=@Permenant_Address,Same_As_Cur_Add=@Same_As_Cur_Add,Gap_In_Studies=@Gap_In_Studies,Is_Verified=0,Is_Active=1,Updated_Date=@Updated_Date,Updated_By=@Updated_By,LoginType=@LoginType where USN='"+TextBox2.Text+"'";
            //Updatecmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = TextBox2.Text.Trim();
            //Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = Txt_Pwd.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Last_Name", SqlDbType.VarChar).Value = Txt_lname.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Middle_Name", SqlDbType.VarChar).Value = Txt_mname.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@First_Name", SqlDbType.VarChar).Value = Txt_fname.Text.Trim();
            if (Rd_male.Checked == true)
            {
                Updatecmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = Rd_male.Text.Trim();
            }
            else
            {
                Updatecmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = Rd_female.Text.Trim();
            }
            Updatecmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Txt_cntc.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = Txt_mail.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@DepartmentId", SqlDbType.Int).Value = DropDownList1.SelectedItem.Value;
            Updatecmd.Parameters.AddWithValue("@CollegeId", SqlDbType.Int).Value = DropDownList2.SelectedItem.Value;
            Updatecmd.Parameters.AddWithValue("@CourseId", SqlDbType.Int).Value = Txt_crsid.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Date_Of_Birth", SqlDbType.DateTime).Value = Txt_dob.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Present_Address", SqlDbType.VarChar).Value = Txt_paddress.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Permenant_Address", SqlDbType.VarChar).Value = Txt_pmt_address.Text.Trim();
            if (Rd_yes_prsnt.Checked == true)
            {
                Updatecmd.Parameters.AddWithValue("@Same_As_Cur_Add", SqlDbType.Bit).Value = 1;
            }
            else
            {
                Updatecmd.Parameters.AddWithValue("@Same_As_Cur_Add", SqlDbType.Bit).Value = 0;
            }
            
            if (Rd_gap_yes.Checked == true)
            {
                Updatecmd.Parameters.AddWithValue("@Gap_In_Studies", SqlDbType.Bit).Value = 1;
            }
            else
            {
                Updatecmd.Parameters.AddWithValue("@Gap_In_Studies", SqlDbType.Bit).Value = 0;
            }
            
            Updatecmd.Parameters.AddWithValue("@Is_Verified", SqlDbType.Int).Value = 0;
            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now;
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@LoginType", SqlDbType.VarChar).Value = DropDown_Login_Id.Text.Trim();
            Updatecmd.Connection = conn;
            try
            {
                conn.Open();
                Updatecmd.ExecuteNonQuery();
                if (Rd_gap_yes.Checked == true)
                {
                    Response.Redirect("Gap_In_Study.aspx");
                }
                else
                {
                    Response.Redirect("Student_Academic_Details.aspx");
                }
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

        protected void Rd_yes_prsnt_CheckedChanged(object sender, EventArgs e)
        {
            if (Rd_yes_prsnt.Checked == true)
            {
                Txt_pmt_address.Text = Txt_paddress.Text;
            }
        }

        protected void Rd_gap_yes_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Rd_gap_no_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Rd_no_prmnt_CheckedChanged(object sender, EventArgs e)
        {
            Txt_pmt_address.Text = "";
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}