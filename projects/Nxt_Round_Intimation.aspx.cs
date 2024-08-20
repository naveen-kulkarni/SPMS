using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace Project
{
    public partial class Nxt_Round_Intimation : System.Web.UI.Page
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
                DDLDataSource(); FillDropDownList();
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
        protected void calbutton_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            string queryString = "SELECT sc.First_Name,sc.Middle_Name,sc.Last_Name,sc.Phone,sc.Email,sc.DepartmentId, cm.CompanyName FROM Wrt_Tst_Result wr,Company_Master cm, Student_Config sc WHERE wr.USN=@USN and cm.CompanyId=wr.CompanyId";

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
                Drp_dwn_Company.SelectedItem.Text = dt.Rows[0]["CompanyName"].ToString();
            }

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Data as been Fetched";
            }
            catch (Exception)
            {
                lblErrMsg.Visible = true;
                lblErrMsg.Text = "Their is no Data in the List";
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

            //string queryString = "insert into Next_Round_Intimation(USN,CompanyId,Test_Date,Test_Time,Test_Place,Test_Type,Description,Is_Active,Updated_Date,Updated_By)values(@USN,@Wrt_Tst_Result_Id,@CompanyId,@Test_Date,@Test_Time,@Test_Place,@Test_Type,@Description,@Is_Active,@Updated_Date,@Updated_By)";
            //SqlCommand Updatecmd = new SqlCommand(queryString, conn);

            SqlCommand Updatecmd = new SqlCommand("Save_Next_Round_Intimation", conn);
                Updatecmd.CommandType = CommandType.StoredProcedure;
            //Updatecmd.CommandType = CommandType.Text;
            
            
            Updatecmd.Parameters.AddWithValue("@Test_Date", SqlDbType.Date).Value = TextDate.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Test_Time", SqlDbType.Time).Value = Texttime.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Test_Place", SqlDbType.VarChar).Value = TextBox3.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Test_Type", SqlDbType.VarChar).Value = Txt_Status.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Txt_Desc.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@Is_Active", SqlDbType.Int).Value = 1;            
            Updatecmd.Parameters.AddWithValue("@Updated_Date", SqlDbType.DateTime).Value = DateTime.Now;
            Updatecmd.Parameters.AddWithValue("@Updated_By", SqlDbType.VarChar).Value = Txt_updby.Text.Trim();
            Updatecmd.Parameters.AddWithValue("@CompanyId", SqlDbType.Int).Value = Drp_dwn_Company.SelectedItem.Value;
            Updatecmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Text_USN.Text.Trim();
            Updatecmd.Connection = conn;
           
            TextDate.Text = "";
            Texttime.Text = "";
            TextBox3.Text = "";
            Txt_Desc.Text = "";
            
            Txt_Status.Text = "";

            Txt_updby.Text = "";



             try
             {
                 conn.Open();
                 Updatecmd.ExecuteNonQuery();
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

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            TextDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Texttime.Text = Calendar1.SelectedDate.ToShortTimeString();
            Calendar1.Visible = false;
        }

        protected void Drp_dwn_Company_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    //Response.Redirect(@"Documents/" + strFileName);
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

        protected void Button2_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }

        protected void Btn_del_Click(object sender, EventArgs e)
        {
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);

            string queryString = "Update Next_Round_Intimation set Is_Active=0 where USN= @USN";
            SqlCommand Delcmd = new SqlCommand(queryString, conn);
            Delcmd.CommandType = CommandType.Text;
            Delcmd.Parameters.AddWithValue("@USN", SqlDbType.Int).Value = Text_USN.Text.Trim();

            conn.Open();
            Delcmd.ExecuteNonQuery();
            TextDate.Text = "";
            Texttime.Text = "";
            TextBox3.Text = "";
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
    }
}