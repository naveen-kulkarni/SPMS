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
    public partial class For_Hod_Teacher : System.Web.UI.Page
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
       
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedIndex != -1)
            {
                FetchProductData();
            }
        }

        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "select sc.Email from Student_Config sc,Company_Placement_Criteria cp,SSLC s,PUC pu,UG u,Student_Acadamics_Details scd,Diploma d,Department_Master dm,Recruitment_Plan_Schedular r where (s.Percentage>=cp.CutOffTenth and s.USN=sc.USN and pu.PUC_Percentage>=cp.CutOffTwelth and pu.USN=sc.USN and u.UG_Percentage>=cp.CutOffDegree and u.USN=sc.USN and scd.PG_Percentage>=cp.post_graduation and scd.USN=sc.USN or(s.Percentage>=cp.CutOffTenth and s.USN=sc.USN and pu.PUC_Percentage>=cp.CutOffTwelth and pu.USN=sc.USN and d.Diploma_Percentage=cp.diploma and d.USN=sc.USN and u.UG_Percentage>=cp.CutOffDegree and u.USN=sc.USN and scd.PG_Percentage>=cp.post_graduation and scd.USN=sc.USN) or(s.Percentage>=cp.CutOffTenth and s.USN=sc.USN and d.Diploma_Percentage=cp.diploma and d.USN=sc.USN and u.UG_Percentage>=cp.CutOffDegree and u.USN=sc.USN and scd.PG_Percentage>=cp.post_graduation and scd.USN=sc.USN)or(s.Percentage>=cp.CutOffTenth and s.USN=sc.USN and pu.PUC_Percentage>=cp.CutOffTwelth and pu.USN=sc.USN and d.Diploma_Percentage>=cp.diploma and d.USN=sc.USN and u.UG_Percentage>=cp.CutOffDegree and u.USN=sc.USN and scd.PG_Percentage>=cp.post_graduation and scd.USN=sc.USN)and sc.DepartmentId=dm.DepartmentId and dm.DepartmentId=@DepartmentId";
                SqlCommand comm = new SqlCommand(queryString, conn);
                //SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("DepartmentId", DropDownList2.SelectedItem.Text.ToString());
                
               // comm.Parameters.AddWithValue("CompanyId", DropDownList3.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Gridload.DataSource = dt;
                    Gridload.DataBind();
                    //txtToMail.Text = dt.Rows[0]["Email"].ToString();
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }

       
    }
}