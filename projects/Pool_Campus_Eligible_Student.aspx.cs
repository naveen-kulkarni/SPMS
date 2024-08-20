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
    public partial class Pool_Campus_Eligible_Student : System.Web.UI.Page
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
            this.BtnBack.Visible = false;
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

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Eligible_Student_Update.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Eligible_Student_Delete.aspx");   
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Eligible_Student.aspx");   
       
     
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");   
       
     
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("INSERT INTO Pool_Campus_Eligible_Students(StudentId,Last_Name,Middle_Name,First_Name,Gender,phone,Email,Department,PoolCampusCollegeId,Course,Date_Of_Birth,Present_Address,Same_As_Cur_Add,Permenant_Address,Updated_Date,Updated_By) VALUES( @StudentId,@Last_Name,@Middle_Name,@First_Name,@Gender,@phone,@Email,@Department,@PoolCampusCollegeId,@Course,@Date_Of_Birth,@Present_Address,@Same_As_Cur_Add,@Permenant_Address,@Updated_Date,@Updated_By)", conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@StudentId", TxtStudentId.Text);
            
           
            cmd.Parameters.AddWithValue("@Last_Name", TxtLastName.Text);
            cmd.Parameters.AddWithValue("@Middle_Name", TxtMiddleName.Text);
            cmd.Parameters.AddWithValue("@First_Name", TxtFirstName.Text);
            
            if (m.Checked == true)
            {
                cmd.Parameters.AddWithValue("@Gender", m.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Gender", f.Text);
            }
            cmd.Parameters.AddWithValue("@Phone", TxtPhone.Text);
            cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
            cmd.Parameters.AddWithValue("@Department", TxtDept.Text);

            cmd.Parameters.AddWithValue("@PoolCampusCollegeId", DDLCollegeName.Text);

            cmd.Parameters.AddWithValue("@Course", TxtCourse.Text);
            cmd.Parameters.AddWithValue("@Date_Of_Birth", TxtDOB.Text);

            cmd.Parameters.AddWithValue("@Present_Address", TxtPresentAddress.Text);

            if (Rdyes.Checked == true)
            {

                
               cmd.Parameters.AddWithValue("@Same_As_Cur_Add", Rdyes.Checked);
                //this.TxtPermanentAddress.Visible = false;
                //cmd.Parameters.AddWithValue("@Permanent_Address", TxtPresentAddress.Text);
           
            }
            else
            {
                cmd.Parameters.AddWithValue("@Same_As_Cur_Add",RdNo.Checked);
                //cmd.Parameters.AddWithValue("@Permanent_Address", TxtPermanentAddress.Text);
          
            }
            cmd.Parameters.AddWithValue("@Permenant_Address", TxtPermanentAddress.Text);
            cmd.Parameters.AddWithValue("@Updated_Date",DateTime.Now);

            cmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            TxtFirstName.Text = "";
            TxtMiddleName.Text = "";
            TxtLastName.Text = "";
            TxtPermanentAddress.Text = "";
            TxtPhone.Text = "";
            TxtPresentAddress.Text = "";
            //TxtUpdatedBy.Text = "";
            //TxtUpdatedDate.Text = "";
            TxtStudentId.Text = "";
            //TxtUpdatedDate.Text = "";
            //TxtUpdatedBy.Text = "";
            TxtDept.Text = "";
            TxtCourse.Text = "";
            TxtDOB.Text = "";
            TxtEmail.Text = "";
        }

        protected void Rdyes_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdyes.Checked == true)
            {
                TxtPermanentAddress.Text = TxtPresentAddress.Text;
            }
            else if (RdNo.Checked == true)
            {
                TxtPermanentAddress.Text = "";
            }

        }

        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select s.First_Name,s.Middle_Name,s.Last_Name,p.collegename,s.Course,s.Department,s.Email,s.Phone,s.Gender,s.Present_Address,s.Permenant_Address,s.Updated_Date,s.Updated_By from Pool_Campus_Eligible_Students s,Pool_Campus_College_Master p where s.PoolCampusCollegeId=p.PoolCampusCollegeId and  s.Is_Active=1 ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_Eligible_Students");
            //grdsched.DataSourceID = null;
            GrdStudent_det.DataSource = ds;
            GrdStudent_det.DataBind();
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");

        }
    }
}