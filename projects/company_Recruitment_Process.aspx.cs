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
    public partial class compnay_Recruitment_Process : System.Web.UI.Page
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
                DDLDataSourcefetch();
            }
        }

        private void DDLDataSourcefetch()
        {
            DropDownList1.Items.Add(new ListItem("@--Select Company--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                string queryString = "SELECT * FROM recruitment r,Company_Master c where c.CompanyId=r.CompanyId";
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

        private void DDLDataSource()
        {

            DropDownList2.Items.Add(new ListItem("@--Select Company--@", ""));
            DropDownList2.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                string queryString = "SELECT * FROM Company_Master where Is_Active=1";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "CompanyName";
                DropDownList2.DataValueField = "CompanyId";
                DropDownList2.DataBind();
            }
        }

        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT * FROM recruitment WHERE CompanyId=@CompanyId";
                SqlCommand comm = new SqlCommand(queryString, conn);
                //SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("CompanyId", SqlDbType.Int).Value = DropDownList1.Text.Trim();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null)
                {
                    DropDownList2.SelectedValue = dt.Rows[0]["CompanyId"].ToString();
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

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedIndex == 0)
            {
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("insert into recruitment(CompanyId,apptitude,group_discussion,technical_round1,technical_round2,technical_round3,telephone_interview1,telephone_interview2,hr_round1,hr_round2)values(@CompanyId,@apptitude,@group_discussion,@technical_round1,@technical_round2,@technical_round3,@telephone_interview1,@telephone_interview2,@hr_round1,@hr_round2)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CompanyId", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@apptitude", CheckBox1.Checked);
                cmd.Parameters.AddWithValue("@group_discussion", CheckBox2.Checked);
                cmd.Parameters.AddWithValue("@technical_round1", CheckBox3.Checked);
                cmd.Parameters.AddWithValue("@technical_round2", CheckBox4.Checked);
                cmd.Parameters.AddWithValue("@technical_round3", CheckBox5.Checked);
                cmd.Parameters.AddWithValue("@telephone_interview1", CheckBox6.Checked);
                cmd.Parameters.AddWithValue("@telephone_interview2", CheckBox7.Checked);
                cmd.Parameters.AddWithValue("@hr_round1", CheckBox8.Checked);
                cmd.Parameters.AddWithValue("@hr_round2", CheckBox9.Checked);

                conn.Open();
                cmd.ExecuteNonQuery();
               



            }
            else
            {
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand Updatecmd = new SqlCommand("update recruitment set apptitude=@apptitude,group_discussion=@group_discussion,technical_round1=@technical_round1,technical_round2=@technical_round2,technical_round3=@technical_round3,telephone_interview1=@telephone_interview1,telephone_interview2=@telephone_interview2,hr_round1=@hr_round1,hr_round2=@hr_round2 where CompanyId=@CompanyId", conn);
                Updatecmd.CommandType = CommandType.Text;
                Updatecmd.Parameters.AddWithValue("@CompanyId", DropDownList2.SelectedItem.Value);
                Updatecmd.Parameters.AddWithValue("@apptitude", CheckBox1.Checked);
                Updatecmd.Parameters.AddWithValue("@group_discussion", CheckBox2.Checked);
                Updatecmd.Parameters.AddWithValue("@technical_round1", CheckBox3.Checked);
                Updatecmd.Parameters.AddWithValue("@technical_round2", CheckBox4.Checked);
                Updatecmd.Parameters.AddWithValue("@technical_round3", CheckBox5.Checked);
                Updatecmd.Parameters.AddWithValue("@telephone_interview1", CheckBox6.Checked);
                Updatecmd.Parameters.AddWithValue("@telephone_interview2", CheckBox7.Checked);
                Updatecmd.Parameters.AddWithValue("@hr_round1", CheckBox8.Checked);
                Updatecmd.Parameters.AddWithValue("@hr_round2", CheckBox9.Checked);




                Updatecmd.Connection = conn;
                conn.Open();
                int a = Updatecmd.ExecuteNonQuery();

                DropDownList2.Text = "";
                CheckBox1.Checked = false;
                CheckBox2.Checked = false;
                CheckBox3.Checked = false;
                CheckBox4.Checked = false;
                CheckBox5.Checked = false;
                CheckBox6.Checked = false;
                CheckBox7.Checked = false;
                CheckBox8.Checked = false;
                CheckBox9.Checked = false;


                 try
                  {

                      if (a == 1)
                      {
                          lblErrMsg.Visible = true;
                          lblErrMsg.Text = "saved successfully";
                         
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
            Response.Redirect("Company_Eligibility_Criteria.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Text = "";
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            CheckBox3.Checked = false;
            CheckBox4.Checked = false;
            CheckBox5.Checked = false;
            CheckBox6.Checked = false;
            CheckBox7.Checked = false;
            CheckBox8.Checked = false;
            CheckBox9.Checked = false;

           
                FetchProductData();
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}

