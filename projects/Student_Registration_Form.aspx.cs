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
    public partial class Student_Registration_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Lbr_pmt_address.Visible = false;
            //Txt_pmt_address.Visible = false;
            Txt_updby.Text=Txt_USN.Text;

            if (!IsPostBack)
            {
                DDLDataSource();
                DeptDataSource();
                DDLDataSourcecourse();
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
        private void DDLDataSourcecourse()
        {
            DropDownList3.Items.Add(new ListItem("@--Select Course--@", ""));
            DropDownList3.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {

                string queryString = "select * from Course_Master";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "CourseName";
                DropDownList3.DataValueField = "CourseId";
                DropDownList3.DataBind();
            }
        }





        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            //SqlCommand Updatecmd = new SqlCommand();
            SqlCommand Updatecmd = new SqlCommand("Insert_Student_Config", conn);
            if (Txt_USN.Text == "" || Txt_Pwd.Text == "" || Txt_lname.Text == "" || Txt_mname.Text == "" || Txt_mname.Text == "" || Txt_fname.Text == "" || Rd_male.Text == "" || Rd_female.Text == "" || Txt_cntc.Text == "" || Txt_mail.Text == "" || DropDownList3.Text == "")
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "fill all the fields";
            }
            else
            {
                
                
                
                Updatecmd.CommandType = CommandType.StoredProcedure;
               // Updatecmd.CommandText = "insert into Student_Config(USN,Password,Last_Name,Middle_Name,First_Name,Gender,Phone,Email,DepartmentId,CollegeId,CourseId,Date_Of_Birth,Present_Address,Permenant_Address,Same_As_Cur_Add,Gap_In_Studies,Is_Verified,Is_Active,Updated_Date,Updated_By,LoginType)Values(@USN,@Password,@Last_Name,@Middle_Name,@First_Name,@Gender,@Phone,@Email,@DepartmentId,@CollegeId,@CourseId,@Date_Of_Birth,@Present_Address,@Permenant_Address,@Same_As_Cur_Add,@Gap_In_Studies,@Is_Verified,@Is_Active,@Updated_Date,@Updated_By,@LoginType)";
                Updatecmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Txt_USN.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = Txt_Pwd.Text.Trim();
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
                Updatecmd.Parameters.AddWithValue("@CourseId", SqlDbType.Int).Value = DropDownList3.SelectedItem.Value;
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
                conn.Open();
                Updatecmd.ExecuteNonQuery();
                /*try
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
                    lblErrMsg.Text = "could not be saved or Fill all the Fields";
                }
                finally
                {
                    conn.Close();
                }*/
            }
        }
        protected void Rd_gap_yes_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        protected void Rd_yes_prsnt_CheckedChanged(object sender, EventArgs e)
        {
            if (Rd_yes_prsnt.Checked == true)
            {
                Txt_pmt_address.Text = Txt_paddress.Text;
            }
           

        }
    }
}


           