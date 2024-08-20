using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace Project
{
    public partial class Wrt_Test_Result : System.Web.UI.Page
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
            loaddepart();
        }
        public void loaddepart()
        {
            if (!IsPostBack)
            {
                DDLDataSource();
                FillDropDownList();
            }
        }
        private void FillDropDownList()
        {
            DropDownList1.Items.Add(new ListItem("@--Select Files to be Download--@", ""));
            DropDownList1.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            //string querystring = "select * from filetoupload";
            SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Filetoupload", conn);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds, "Filetoupload");
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "DocumentName";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();

        }
        private void DDLDataSource()
        {
            Drp_dwn_Company.Items.Add(new ListItem("@--Select Company which are to be Scheduled--@", ""));
            Drp_dwn_Company.AppendDataBoundItems = true;
            DropDown_companyName.Items.Add(new ListItem("@--Select Company which are to be Scheduled--@", ""));
            DropDown_companyName.AppendDataBoundItems = true;
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Company_Master where Is_Active=1";
            SqlCommand comm = new SqlCommand(queryString, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            conn.Open();
            int a = comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            Drp_dwn_Company.DataSource = dt;
            Drp_dwn_Company.DataTextField = "CompanyName";
            Drp_dwn_Company.DataValueField = "CompanyId";
            Drp_dwn_Company.DataBind();
            DropDown_companyName.DataSource = dt;
            DropDown_companyName.DataTextField = "CompanyName";
            DropDown_companyName.DataValueField = "CompanyId";
            DropDown_companyName.DataBind();
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT * FROM Student_Config WHERE USN=@USN and Is_Active=1";

            SqlCommand comm = new SqlCommand(queryString, conn);
            comm.Parameters.AddWithValue("USN", SqlDbType.VarChar).Value = Text_USN.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                Txt_fname.Text = dt.Rows[0]["First_Name"].ToString();
                Txt_mname.Text = dt.Rows[0]["Middle_Name"].ToString();
                Txt_lname.Text = dt.Rows[0]["Last_Name"].ToString();
                Txt_cntc.Text = dt.Rows[0]["Phone"].ToString();
                Txt_mail.Text = dt.Rows[0]["Email"].ToString();
                Text_Dept.Text = dt.Rows[0]["DepartmentId"].ToString();
            }
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "saved successfully";
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
           
           
            SqlCommand Updatecmd = new SqlCommand("SAVE_INSERT_WRT_TST_RESULT", conn);
            Updatecmd.Connection = conn;
            Updatecmd.CommandType = CommandType.StoredProcedure;
            
           // Updatecmd.CommandText = "insert into Wrt_Tst_Result(USN,CompanyId,apptitude,technical_round1,technical_round2,technical_round3,Is_Active,Updated_Date,Updated_By)Values(@USN,@CompanyId,@apptitude,@technical_round1,@technical_round2,@technical_round3,@Is_Active,@Updated_Date,@Updated_By)";
            Updatecmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Text_USN.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@CompanyId", SqlDbType.Int).Value = Drp_dwn_Company.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@apptitude", ChecK_apt.Checked);
            Updatecmd.Parameters.AddWithValue("@technical_round1", SqlDbType.Bit).Value = Check_techRnd1.Checked;
            Updatecmd.Parameters.AddWithValue("@technical_round2", SqlDbType.Bit).Value = Check_techRnd2.Checked;
            Updatecmd.Parameters.AddWithValue("@technical_round3", SqlDbType.Bit).Value = Check_techRnd3.Checked;
            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now;
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();

            Updatecmd.Connection = conn;

            try
            {
                conn.Open();
                Updatecmd.ExecuteNonQuery();
                Response.Redirect("Enter Written Test Result.aspx");
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Btn_Upload_Click(object sender, EventArgs e)
        {


            try
            {
                if (FileUpload1.HasFile)
                {
                    //calculate the size of uploading file
                    int fileSize = FileUpload1.PostedFile.ContentLength;
                    //create an array of byte with file size
                    byte[] fileBytes = new byte[fileSize];
                    FileUpload1.PostedFile.InputStream.Read(fileBytes, 0, fileSize);
                    //create sqlconnection to the database
                    string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                    SqlConnection conn = new SqlConnection(connString);
                    //create a command object for inserting data into database
                    SqlCommand sqlcom = new SqlCommand("insert into Filetoupload(DocumentName,Document,CompanyId,Updated_Date,Updated_By,Is_Active)values(@DocumentName,@Document,@CompanyId,@Updated_Date,@Updated_By,@Is_Active)", conn);
                    //add parameters with values
                    sqlcom.Parameters.AddWithValue("@DocumentName", Path.GetFileName(FileUpload1.PostedFile.FileName));
                    sqlcom.Parameters.AddWithValue("@Document", fileBytes);
                    // sqlcom.Parameters.AddWithValue("@CompanyId", DropDown_companyName.SelectedItem.Value);
                    sqlcom.Parameters.AddWithValue("@CompanyId", SqlDbType.Int).Value = DropDown_companyName.Text.Trim();
                    sqlcom.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now;
                    sqlcom.Parameters.AddWithValue("@Updated_By", SqlDbType.DateTime).Value = Txt_updby.Text.Trim();
                    sqlcom.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;
                    //Open connection
                    conn.Open();
                    //Execute Insert command
                    int retValue = sqlcom.ExecuteNonQuery();
                    //dispose memory of used objects
                    conn.Close();
                    sqlcom.Dispose();
                    conn.Dispose();
                    fileBytes = null;
                    FillDropDownList();
                    //Response.Write("file uploaded successfully");
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "file uploaded sucessfully";


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void BtnDownload_Click(object sender, EventArgs e)
        {

            try
            {
                string strFileName = string.Empty;
                //create a new Sql connection to the database
                string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand sqlcom = new SqlCommand("select * from Filetoupload where Id= '" + DropDownList1.SelectedItem.Value + "'", conn);
                conn.Open();
                //read data into datareader
                SqlDataReader sqlDr = sqlcom.ExecuteReader();
                while (sqlDr.Read())
                {
                    strFileName = sqlDr["DocumentName"].ToString();
                    //read binary data into bytes array
                    byte[] fileBytes = (byte[])sqlDr["Document"];
                    //create Filestream object from for saving file
                    FileStream oFileStream = new FileStream(Server.MapPath("Documents") + @"\" + strFileName, FileMode.Create);
                    //savefile
                    oFileStream.Write(fileBytes, 0, fileBytes.Length);
                    //dispose the memory of used objects
                    oFileStream.Close();
                    oFileStream.Dispose();
                    fileBytes = null;
                }
                //close reader and connection
                sqlDr.Close();
                conn.Close();
                //dispose memory
                sqlDr.Dispose();
                conn.Dispose();
                sqlcom.Dispose();
                if (strFileName != string.Empty)
                {
                    Response.Redirect(@"Documents/" + strFileName);
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = @"Documents/" + strFileName;
                }
                Process.Start(Server.MapPath(@"\" + strFileName));
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }

        protected void DropDown_companyName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Btn_del_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);

            string queryString = "Update Wrt_Tst_Result set Is_Active=0 where USN= @USN";
            SqlCommand Delcmd = new SqlCommand(queryString, conn);
            Delcmd.CommandType = CommandType.Text;
            Delcmd.Parameters.AddWithValue("@USN", SqlDbType.Int).Value = Text_USN.Text.Trim();

            conn.Open();
            Delcmd.ExecuteNonQuery();
            
            Drp_dwn_Company.Text = "";
            Txt_updby.Text = "";

            try
            {

                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Record Deleted successfully";
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "could not be deleted";
            }
            finally
            {

                conn.Close();
            }
        }

        protected void Txt_updby_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
                