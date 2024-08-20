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
    public partial class Pool_Campus_Eligible_Student_Update : System.Web.UI.Page
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
            DDCollegeName();
            //TxtUpdatedDate.Text = DateTime.Now.Date.ToShortDateString();
            if (!IsPostBack)
            {
                DDLStudentId.Items.Add(new ListItem("@--Select Student Id--@", ""));
                DDLStudentId.AppendDataBoundItems = true;

                string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connstr);
                string query = "select * from Pool_Campus_Eligible_Students where Is_Active=1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DDLStudentId.DataSource = ds;
                DDLStudentId.DataTextField = "StudentId";
                // DDLStudentId.DataValueField = "PoolCampusCollegeID";
                DDLStudentId.DataBind();

            }
        }

        private void DDCollegeName()
        {
            if (!IsPostBack)
            {
                DDLCollegeName.Items.Add(new ListItem("@--Select College Name--@", ""));
                DDLCollegeName.AppendDataBoundItems = true;

                string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connstr);
                string query = "select * from Pool_Campus_College_Master where Is_Active=1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DDLCollegeName.DataSource = ds;
                DDLCollegeName.DataTextField = "CollegeName";
                DDLCollegeName.DataValueField = "PoolCampusCollegeID";
                DDLCollegeName.DataBind();

            }
        }

             
            
        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Pool_Campus_Eligible_Students WHERE StudentId=@StudentId ";
            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("@StudentId", DDLStudentId.SelectedItem.Value);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                TxtFirstName.Text = dt.Rows[0]["First_Name"].ToString();
                TxtLastName.Text = dt.Rows[0]["Last_Name"].ToString();
                TxtMiddleName.Text = dt.Rows[0]["Middle_Name"].ToString();
                TxtGender.Text = dt.Rows[0]["Gender"].ToString();
               
                // RBMale.Text = dt.Rows[0]["Gender"].ToString();
               // RBFemale.Text = dt.Rows[0]["Gender"].ToString();
                TxtPhone.Text = dt.Rows[0]["Phone"].ToString();
                TxtEmail.Text = dt.Rows[0]["Email"].ToString();
                TxtDept.Text = dt.Rows[0]["Department"].ToString();
                TxtCourse.Text = dt.Rows[0]["Course"].ToString();
                TxtDOB.Text = dt.Rows[0]["Date_Of_Birth"].ToString();
                TxtPresentAddress.Text = dt.Rows[0]["Present_Address"].ToString();
                TxtPermanentAddress.Text = dt.Rows[0]["Permenant_Address"].ToString();
                //Rdyes.Checked =(bool) dt.Rows[0]["Same_As_Cur_Add"];//.ToString();
                //RdNo.Checked = (bool)dt.Rows[0]["Same_As_Cur_Add"];//.ToString();
                //TxtUpdatedDate.Text = dt.Rows[0]["Updated_Date"].ToString();
              //  TxtUpdatedBy.Text = dt.Rows[0]["Updated_By"].ToString();
            }
           /* try
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Eligible_Student.aspx");
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Pool_Campus_Eligible_Students set    First_Name=@First_Name,Last_Name=@Last_Name,Middle_Name=@Middle_Name,Gender=@Gender,Phone=@Phone,Email=@Email,Department=@Department,PoolCampusCollegeID=@PoolCampusCollegeID ,Course=@Course,Date_Of_Birth=@Date_Of_Birth,Present_Address=@Present_Address,Same_As_Cur_Add=@Same_As_Cur_Add,Permenant_Address=@Permenant_Address,Is_Active=1, Updated_Date=@Updated_Date, Updated_By=@Updated_By where StudentId=@StudentId", conn);
            //UpdateCmd.CommandType = CommandType.Text;
            UpdateCmd.Parameters.AddWithValue("@StudentId", DDLStudentId.Text);
            UpdateCmd.Parameters.AddWithValue("@First_Name", TxtFirstName.Text);
            UpdateCmd.Parameters.AddWithValue("@Last_Name", TxtLastName.Text);
            UpdateCmd.Parameters.AddWithValue("@Middle_Name", TxtMiddleName.Text);
            UpdateCmd.Parameters.AddWithValue("@Phone", TxtPhone.Text);
            UpdateCmd.Parameters.AddWithValue("@Gender", TxtGender.Text);
            UpdateCmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            UpdateCmd.Parameters.AddWithValue("@Department", TxtDept.Text);
            UpdateCmd.Parameters.AddWithValue("@Course", TxtCourse.Text);
            UpdateCmd.Parameters.AddWithValue("@Date_Of_Birth   ", TxtDOB.Text);
            UpdateCmd.Parameters.AddWithValue("@Present_Address", TxtPresentAddress.Text);
             
                  

                  if (Rdyes.Checked == true)
            {
                UpdateCmd.Parameters.AddWithValue("@Same_As_Cur_Add", Rdyes.Checked);
                //this.TxtPermanentAddress.Visible = false;
                //cmd.Parameters.AddWithValue("@Permanent_Address", TxtPresentAddress.Text);
           
            }
            else
            {
                UpdateCmd.Parameters.AddWithValue("@Same_As_Cur_Add",RdNo.Checked);
                //cmd.Parameters.AddWithValue("@Permanent_Address", TxtPermanentAddress.Text);
          
            }
                  UpdateCmd.Parameters.AddWithValue("@PoolCampusCollegeID", DDLCollegeName.Text);
            UpdateCmd.Parameters.AddWithValue("@Permenant_Address", TxtPermanentAddress.Text);
            UpdateCmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);
            UpdateCmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);
            conn.Open();
            UpdateCmd.ExecuteNonQuery();
            TxtFirstName.Text = "";
            TxtLastName.Text = "";
            TxtGender.Text = "";
            TxtMiddleName.Text = "";
            TxtPermanentAddress.Text = "";
            TxtPhone.Text = "";
            TxtPresentAddress.Text = "";
            //TxtUpdatedBy.Text = "";
            //TxtUpdatedDate.Text = "";
        }

        protected void DDLStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLStudentId.SelectedIndex != -1)
            {
                FetchProductData();
            }
        }

        protected void Rdyes_CheckedChanged(object sender, EventArgs e)
        {
        if(Rdyes.Checked==true)
             {
               TxtPermanentAddress.Text=  TxtPresentAddress.Text;
                 //UpdateCmd.Parameters.AddWithValue("@Same_As_Cur_Add",);
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