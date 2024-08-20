
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
    public partial class Company_Eligibility_Criteria : System.Web.UI.Page
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
            }
        }

        private void DDLDataSource()
        {
            DropDownList1.Items.Add(new ListItem("@--Select Company--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                string queryString = "SELECT * FROM Company_Placement_Criteria,Company_Master";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "CompanyName";
                DropDownList1.DataValueField = "CompanyId";
                DropDownList1.DataBind();
            }
        }

        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT * FROM Company_Placement_Criteria WHERE CompanyId=@CompanyId";
                SqlCommand comm = new SqlCommand(queryString, conn);
                //SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("CompanyId", DropDownList1.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null)
                {
                    TextBox1.Text = dt.Rows[0]["CompanyId"].ToString();
                    TextBox2.Text = dt.Rows[0]["CutOffTenth"].ToString();
                    TextBox3.Text = dt.Rows[0]["CutOffTwelth"].ToString();
                    TextBox4.Text = dt.Rows[0]["diploma"].ToString();
                    TextBox5.Text = dt.Rows[0]["CutOffDegree"].ToString();
                    TextBox6.Text = dt.Rows[0]["post_graduation"].ToString();
                    TextBox7.Text = dt.Rows[0]["GapInYearsAllowedFlag"].ToString();
                    TextBox8.Text = dt.Rows[0]["BackLogAllowedFlag"].ToString();
                    TextBox9.Text = dt.Rows[0]["course_offring"].ToString();
                    TextBox10.Text = dt.Rows[0]["Description"].ToString();
                   
                    TextBox13.Text = dt.Rows[0]["Is_Active"].ToString();
                    TextBox14.Text = dt.Rows[0]["CompanyCollegeId"].ToString();
                    TextBox15.Text = dt.Rows[0]["CutOffType"].ToString();


                }

            }
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";

            if (DropDownList1.SelectedIndex != -1)
            {
                FetchProductData();
            }
        }






        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("insert into Company_Placement_Criteria(CompanyName,CutOffTenth,CutOffTwelth,diploma,CutOffDegree,post_graduation,Description,GapInYearsAllowedFlag,course_offring,BackLogAllowedFlag,Updated_Date,Updated_By,Is_Active,CompanyCollegeId,CutOffType)values(@CompanyName,@CutOffTenth,@CutOffTwelth,@diploma,@CutOffDegree,@post_graduation,@Description,@GapInYearsAllowedFlag,@course_offring,@BackLogAllowedFlag,@Updated_Date,@Updated_By,@Is_Active,@CompanyCollegeId,@CutOffType)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompanyName", TextBox1.Text);
                cmd.Parameters.AddWithValue("@CutOffTenth", TextBox2.Text);
                cmd.Parameters.AddWithValue("@CutOffTwelth", TextBox3.Text);
                cmd.Parameters.AddWithValue("@diploma", TextBox4.Text);
                cmd.Parameters.AddWithValue("@CutOffDegree", TextBox5.Text);
                cmd.Parameters.AddWithValue("@post_graduation", TextBox6.Text);
                cmd.Parameters.AddWithValue("@GapInYearsAllowedFlag", TextBox7.Text);
                cmd.Parameters.AddWithValue("@BackLogAllowedFlag", TextBox8.Text);
                cmd.Parameters.AddWithValue("@course_offring", TextBox9.Text);
                cmd.Parameters.AddWithValue("@Description", TextBox10.Text);
                cmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);
                cmd.Parameters.AddWithValue("@Is_Active",SqlDbType.Int).Value=1;
                cmd.Parameters.AddWithValue("@CompanyCollegeId", TextBox14.Text);
                cmd.Parameters.AddWithValue("@CutOffType", TextBox15.Text);


                conn.Open();
                cmd.ExecuteNonQuery();
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";



            }
            else
            {
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand Updatecmd = new SqlCommand("update Company_Placement_Criteria set set Is_Active=1,CutOffTenth=@CutOffTenth,CutOffTwelth=@CutOffTwelth,diploma=@diploma,CutOffDegree=@CutOffDegree,post_graduation=@post_graduation,Description=@Description,GapInYearsAllowedFlag=@GapInYearsAllowedFlag,course_offring=@course_offring,BackLogAllowedFlag=@BackLogAllowedFlag,Updated_Date=@Updated_Date,Updated_By=@Updated_By,CompanyCollegeId=@CompanyCollegeId,CutOffType=@CutOffType where CompanyName=@CompanyName", conn);
                Updatecmd.CommandType = CommandType.Text;
                Updatecmd.Parameters.AddWithValue("@CompanyName", TextBox1.Text);
                Updatecmd.Parameters.AddWithValue("@CutOffTenth", TextBox2.Text);
                Updatecmd.Parameters.AddWithValue("@CutOffTwelth", TextBox3.Text);
                Updatecmd.Parameters.AddWithValue("@diploma", TextBox4.Text);
                Updatecmd.Parameters.AddWithValue("@CutOffDegree", TextBox5.Text);
                Updatecmd.Parameters.AddWithValue("@post_graduation", TextBox6.Text);
                Updatecmd.Parameters.AddWithValue("@GapInYearsAllowedFlag", TextBox7.Text);
                Updatecmd.Parameters.AddWithValue("@BackLogAllowedFlag", TextBox8.Text);
                Updatecmd.Parameters.AddWithValue("@course_offring", TextBox9.Text);
                Updatecmd.Parameters.AddWithValue("@Description", TextBox10.Text);
                Updatecmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);
                Updatecmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);
                
                Updatecmd.Parameters.AddWithValue("@CompanyCollegeId", TextBox14.Text);
                Updatecmd.Parameters.AddWithValue("@CutOffType", TextBox15.Text);




                Updatecmd.Connection = conn;
                conn.Open();
                int a = Updatecmd.ExecuteNonQuery();

                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";


                try
                {

                    if (a >= 1)
                    {
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = "saved successfully";
                        DropDownList1.SelectedIndex = 0;
                    }
                    else
                    {
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = "could not be saved";
                    }
                }
                catch (Exception)
                {
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "connection could not opened";
                }
                finally
                {
                    conn.Close();
                }

            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("chart.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("recruitment.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("change.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchProductData();
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}

