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
    public partial class companyprofile : System.Web.UI.Page
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
                string queryString = "SELECT * FROM Company_Master where Is_Active=1";
                SqlCommand comm = new SqlCommand(queryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "CompanyName";
                DropDownList1.DataValueField = "CompanyName";
                DropDownList1.DataBind();
            }
        }

        private void FetchProductData()
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                

                string query = "SELECT * FROM Company_Master where Is_Active=1";
                
                SqlCommand comm = new SqlCommand(query, conn);
                //SqlCommand comm = new SqlCommand("company_Selects", conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("CompanyName", DropDownList1.SelectedItem.Value);
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
                    //FileUpload1.Text = dt.Rows[0]["Upload"].ToString();
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
            TextBox11.Text = "";
            if (DropDownList1.SelectedIndex != -1)
            {
                FetchProductData();
            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {

                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("insert into Company_Master(CompanyName,Description,Updated_Date,Updated_By,managing_director,company_ceo,company_services,isocertification_no,address,companywebsites,skills,ctc,bond,Upload)values(@CompanyName,@Description,@Updated_Date,@Updated_By,@managing_director,@company_ceo,@company_services,@isocertification_no,@address,@companywebsites,@skills,@ctc,@bond,@Upload)", conn);
                cmd.Parameters.AddWithValue("@CompanyName", SqlDbType.VarChar).Value = TextBox1.Text.Trim();
                cmd.Parameters.AddWithValue("@managing_director", SqlDbType.VarChar).Value = TextBox2.Text.Trim();
                cmd.Parameters.AddWithValue("@company_ceo", SqlDbType.VarChar).Value = TextBox3.Text.Trim();
                cmd.Parameters.AddWithValue("@company_services", SqlDbType.VarChar).Value = TextBox4.Text.Trim();
                cmd.Parameters.AddWithValue("@isocertification_no", SqlDbType.VarChar).Value = TextBox5.Text.Trim();
                cmd.Parameters.AddWithValue("@address", SqlDbType.VarChar).Value = TextBox6.Text.Trim();
                cmd.Parameters.AddWithValue("@companywebsites", SqlDbType.VarChar).Value = TextBox7.Text.Trim();
                cmd.Parameters.AddWithValue("@skills", SqlDbType.VarChar).Value = TextBox8.Text.Trim();
                cmd.Parameters.AddWithValue("@ctc", SqlDbType.VarChar).Value = TextBox9.Text.Trim();
                cmd.Parameters.AddWithValue("@bond", SqlDbType.VarChar).Value = TextBox10.Text.Trim();
                cmd.Parameters.AddWithValue("@Description", TextBox11.Text);
                cmd.Parameters.AddWithValue("@Upload", FileUpload1.FileName.ToString().Trim());
                cmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.VarChar).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
               
                conn.Open();
                cmd.ExecuteNonQuery();



                string savePath = @"G:\Project\Project\Resources";

                // Before attempting to perform operations
                // on the file, verify that the FileUpload 
                // control contains a file.
                if (FileUpload1.HasFile)
                {
                    // Get the name of the file to upload.
                    String fileName = FileUpload1.FileName;

                    // Append the name of the file to upload to the path.
                    savePath += fileName;


                    // Call the SaveAs method to save the 
                    // uploaded file to the specified path.
                    // This example does not perform all
                    // the necessary error checking.               
                    // If a file with the same name
                    // already exists in the specified path,  
                    // the uploaded file overwrites it.
                    FileUpload1.SaveAs(savePath);

                    // Notify the user of the name of the file
                    // was saved under.
                    UploadStatusLabel.Text = "Your file was saved as " + fileName;
                }
                else
                {
                    // Notify the user that a file was not uploaded.
                    UploadStatusLabel.Text = "You did not specify a file to upload.";
                }


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
                TextBox11.Text = "";

            }
            else
            {
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand Updatecmd = new SqlCommand("update Company_Master set Is_Active=1,managing_director=@managing_director,company_ceo=@company_ceo,company_services=@company_services,isocertification_no=@isocertification_no,address=@address,companywebsites=@companywebsites,skills=@skills,ctc=@ctc,bond=@bond,Description=@Description,Upload=@Upload where CompanyName=@CompanyName", conn);
                Updatecmd.CommandType = CommandType.Text;
                Updatecmd.Parameters.AddWithValue("@CompanyName", TextBox1.Text);
                Updatecmd.Parameters.AddWithValue("@managing_director", TextBox2.Text);
                Updatecmd.Parameters.AddWithValue("@company_ceo", TextBox3.Text);
                Updatecmd.Parameters.AddWithValue("@company_services", TextBox4.Text);
                Updatecmd.Parameters.AddWithValue("@isocertification_no", TextBox5.Text);
                Updatecmd.Parameters.AddWithValue("@address", TextBox6.Text);
                Updatecmd.Parameters.AddWithValue("@companywebsites", TextBox7.Text);
                Updatecmd.Parameters.AddWithValue("@skills", TextBox8.Text);
                Updatecmd.Parameters.AddWithValue("@ctc", TextBox9.Text);
                Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
                Updatecmd.Parameters.AddWithValue("@bond", TextBox10.Text);
                Updatecmd.Parameters.AddWithValue("@Description", TextBox11.Text);
                Updatecmd.Parameters.AddWithValue("@Upload", FileUpload1.FileName.ToString());



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
                TextBox11.Text = "";

                try
                {

                    if (a >= 1)
                    {
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = "saved successfully";
                        Response.Redirect("Company_Eligibility_Criteria.aspx");
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

            /* lblErrMsg.Visible = true;
             lblErrMsg.Text = DropDownList1.Text;
             */

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("update Company_Master set Is_Active = 0 where CompanyName = '" + DropDownList1.Text + "' ", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("change.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}



