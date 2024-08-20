using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project
{
    public partial class Send_Mail : System.Web.UI.Page
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
            DropDownList2.Items.Add(new ListItem("@--Select Department--@", ""));
            DropDownList2.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT * from Department_Master";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "Dept_Name";
                DropDownList2.DataValueField = "DepartmentId";
                DropDownList2.DataBind();
            }
        }

        private void DDLDataSource()
        {
            DropDownList3.Items.Add(new ListItem("@--Select Company--@", ""));
            DropDownList3.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {

                string queryString = "SELECT * from Company_Master cmp,Recruitment_Plan_Schedular r where r.CompanyId=cmp.CompanyId";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "CompanyName";
                DropDownList3.DataValueField = "CompanyId";
                DropDownList3.DataBind();
            }
        }

        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT * FROM Company_Master c ,Company_Placement_Criteria cp, Recruitment_Plan_Schedular r where r.CompanyId=cp.CompanyId";
                SqlCommand comm = new SqlCommand(queryString, conn);
                //SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("CompanyId", DropDownList3.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    TextBox1.Text = dt.Rows[0]["CutOffTenth"].ToString();
                    TextBox2.Text = dt.Rows[0]["CutOffTwelth"].ToString();
                    TextBox3.Text = dt.Rows[0]["diploma"].ToString();
                    TextBox4.Text = dt.Rows[0]["CutOffDegree"].ToString();
                    TextBox5.Text = dt.Rows[0]["post_graduation"].ToString();
                    //TextBox6.Text = dt.Rows[0]["course_offring"].ToString();
                    TextBox7.Text = dt.Rows[0]["BackLogAllowedFlag"].ToString();
                }

            }
        }

       

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Common objCommon = new Common();
            objCommon.SendMail(txtToMail.Text, txtSubject.Text, txtMailContent.Text, "FromMail", "FromPassword");

            lblStatus.Visible = true;
            lblStatus.Text = "Mail Sent Succcessfully";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            
         
            

            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "select sc.Email from Student_Config sc,Company_Placement_Criteria cp,SSLC s,PUC pu,UG u,Student_Acadamics_Details scd,Diploma d,Department_Master dm,Recruitment_Plan_Schedular r where (s.Percentage>=cp.CutOffTenth and s.USN=sc.USN and pu.PUC_Percentage>=cp.CutOffTwelth and pu.USN=sc.USN and u.UG_Percentage>=cp.CutOffDegree and u.USN=sc.USN and scd.PG_Percentage>=cp.post_graduation and scd.USN=sc.USN or(s.Percentage>=cp.CutOffTenth and s.USN=sc.USN and pu.PUC_Percentage>=cp.CutOffTwelth and pu.USN=sc.USN and d.Diploma_Percentage=cp.diploma and d.USN=sc.USN and u.UG_Percentage>=cp.CutOffDegree and u.USN=sc.USN and scd.PG_Percentage>=cp.post_graduation and scd.USN=sc.USN) or(s.Percentage>=cp.CutOffTenth and s.USN=sc.USN and d.Diploma_Percentage=cp.diploma and d.USN=sc.USN and u.UG_Percentage>=cp.CutOffDegree and u.USN=sc.USN and scd.PG_Percentage>=cp.post_graduation and scd.USN=sc.USN)or(s.Percentage>=cp.CutOffTenth and s.USN=sc.USN and pu.PUC_Percentage>=cp.CutOffTwelth and pu.USN=sc.USN and d.Diploma_Percentage>=cp.diploma and d.USN=sc.USN and u.UG_Percentage>=cp.CutOffDegree and u.USN=sc.USN and scd.PG_Percentage>=cp.post_graduation and scd.USN=sc.USN)and sc.DepartmentId=@DepartmentId and r.CompanyId=@CompanyId)"; 
                SqlCommand comm = new SqlCommand(queryString, conn);
                //SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("DepartmentId", DropDownList2.SelectedItem.Value);
                comm.Parameters.AddWithValue("CompanyId", DropDownList3.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 1; i <= 500; i++)
                    {
                        
                       txtToMail.Text  = dt.Rows[0]["Email"].ToString();
                    }
                        
                    
                }
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedIndex != -1)
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
    
            
     