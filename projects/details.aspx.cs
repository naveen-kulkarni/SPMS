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
    public partial class details : System.Web.UI.Page
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
        }

         private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT cm.CompanyName,cm.Description,cm.managing_director,cm.company_ceo,cm.company_services,cm.isocertification_no,cm.address,cm.companywebsites,cm.skills,cm.ctc,cm.bond,c.CompanyCollegeId,c.CutOffType,c.CutOffTenth,c.CutOffTwelth,c.CutOffDegree,c.GapInYearsAllowedFlag,c.BackLogAllowedFlag,c.Description,c.diploma,c.post_graduation,c.course_offring,r.apptitude,r.group_discussion,r.technical_round1,r.technical_round2,r.technical_round3,r.telephone_interview1,r.telephone_interview2,r.hr_round1,r.hr_round2 from Company_Master cm,Company_Placement_Criteria c, recruitment r where  cm.CompanyId=c.CompanyId or cm.CompanyId=r.CompanyId and cm.Is_Active=1 AND cm.CompanyName=@CompanyName";
                SqlCommand comm = new SqlCommand(queryString, conn);
                //SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("CompanyName", SqlDbType.VarChar).Value = TextBox21.Text.Trim();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    TextBox1.Text = dt.Rows[0]["CompanyName"].ToString();
                    TextBox2.Text = dt.Rows[0]["managing_director"].ToString();
                    TextBox3.Text = dt.Rows[0]["company_ceo"].ToString();
                    TextBox4.Text = dt.Rows[0]["company_services"].ToString();
                    TextBox5.Text = dt.Rows[0]["isocertification_no"].ToString();
                    TextBox6.Text = dt.Rows[0]["address"].ToString();
                    TextBox7.Text = dt.Rows[0]["companywebsites"].ToString();
                    TextBox8.Text = dt.Rows[0]["skills"].ToString();
                    TextBox9.Text = dt.Rows[0]["ctc"].ToString();
                    TextBox10.Text = dt.Rows[0]["bond"].ToString();
                    TextBox11.Text = dt.Rows[0]["Description"].ToString();
                    TextBox12.Text = dt.Rows[0]["CutOffTenth"].ToString();
                    TextBox13.Text = dt.Rows[0]["CutOffTwelth"].ToString();
                    TextBox14.Text = dt.Rows[0]["diploma"].ToString();
                    TextBox15.Text = dt.Rows[0]["CutOffDegree"].ToString();
                    TextBox16.Text = dt.Rows[0]["post_graduation"].ToString();
                    TextBox17.Text = dt.Rows[0]["GapInYearsAllowedFlag"].ToString();
                    TextBox18.Text = dt.Rows[0]["BackLogAllowedFlag"].ToString();
                    TextBox19.Text = dt.Rows[0]["course_offring"].ToString();
                    TextBox20.Text = dt.Rows[0]["Description"].ToString();
                    CheckBox1.Checked = (bool)dt.Rows[0]["apptitude"];
                    CheckBox2.Checked = (bool)dt.Rows[0]["group_discussion"];
                    CheckBox3.Checked = (bool)dt.Rows[0]["technical_round1"];
                    CheckBox4.Checked = (bool)dt.Rows[0]["technical_round2"];
                    CheckBox5.Checked = (bool)dt.Rows[0]["technical_round3"];
                    CheckBox6.Checked = (bool)dt.Rows[0]["telephone_interview1"];
                    CheckBox7.Checked = (bool)dt.Rows[0]["telephone_interview2"];
                    CheckBox8.Checked = (bool)dt.Rows[0]["hr_round1"];
                    CheckBox9.Checked = (bool)dt.Rows[0]["hr_round2"];

                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("feedback.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("details1.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            FetchProductData();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}
