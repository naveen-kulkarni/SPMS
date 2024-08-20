using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project
{
    public partial class Subject : System.Web.UI.Page
    {
        DBConnection obj = new DBConnection();
        string query = "";

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
                loadGridview();
                selectadddcourse();
                selectadddbranch();
                gvSubject.Visible = false;

            }
        }

        public void selectadddcourse()
        {
            DDLCourseId.Items.Add(new ListItem("@--Select Course--@", ""));
            DDLCourseId.AppendDataBoundItems = true;

            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Course_Master where Is_Active= 1", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLCourseId.DataSource = dt;
            DDLCourseId.DataSource = dt;
            DDLCourseId.DataTextField = "CourseName";
            DDLCourseId.DataValueField = "CourseId";
            DDLCourseId.DataBind();

        }

        public void selectadddbranch()
        {
            DDLBranchName.Items.Add(new ListItem("@--Select Branch--@", ""));
            DDLBranchName.AppendDataBoundItems = true;

            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Course_Master where Is_Active= 1", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLBranchName.DataSource = dt;
            DDLBranchName.DataTextField = "BranchName";
            DDLBranchName.DataValueField = "BranchName";
            DDLBranchName.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SPMSConnectionString1"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert_Subject_Master", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SubjectName", txtSubjectName.Text);
            cmd.Parameters.AddWithValue("CourseId", DDLCourseId.Text);
            cmd.Parameters.AddWithValue("BranchName", DDLBranchName.Text);
            cmd.Parameters.AddWithValue("Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("Updated_Date", DateTime.Now.Date.ToShortDateString());
            cmd.Parameters.AddWithValue("Updated_By", Txt_updby.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            string alet = "<script language=javascript>" + "alert('Added Successfully');" + "</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", alet);
            return;
        }

        public void DeleteSubject(int SubjectId, string UserID)
        {
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open(); //Open the database connection
                query = "update Subject_Master set Is_Active = 0, Updated_By = '" + UserID + "'" +
                                " where SubjectId = " + SubjectId;
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();  //close the database connection
            }
        }



        protected void lnkbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtnDelete = (LinkButton)sender;
                GridViewRow gvRow = lnkbtnDelete.NamingContainer as GridViewRow;
                int SubjectId = int.Parse(((HiddenField)gvRow.FindControl("hdnSubjectID")).Value.ToString());
                string UserID = "1";
                DeleteSubject(SubjectId, UserID);
                loadGridview();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {



            if (DDLCourseId.Text == "")
            {
                string alert = "<script language=javascript>" + "alert('Course Name is required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                return;
            }
            int SubjectId = int.Parse(hdnSubjectId.Value.ToString());
            string SubjectName = txtSubjectName.Text;
            string CourseId = DDLCourseId.Text;
            string BranchName = DDLBranchName.Text;
            string Description = txtDescription.Text;
            UpdateSubject(SubjectId);
            resetFields();
            loadGridview();
        }
        public void UpdateSubject(int SubjectId)
        {


            
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Subject_Master set SubjectName=@SubjectName, CourseId=@CourseId, BranchName=@BranchName, Description=@Description, Is_Active=1,Updated_Date=@Updated_Date, Updated_By=@Updated_By where SubjectId=@SubjectId", conn);
            UpdateCmd.CommandType = CommandType.Text;
            UpdateCmd.Parameters.AddWithValue("@SubjectId", SubjectId);
            UpdateCmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
            UpdateCmd.Parameters.AddWithValue("@CourseId", DDLCourseId.Text);
            UpdateCmd.Parameters.AddWithValue("@BranchName", DDLBranchName.Text);
            UpdateCmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            UpdateCmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now.Date.ToShortDateString());
            UpdateCmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);
            conn.Open();
            UpdateCmd.ExecuteNonQuery();
            string aler = "<script language=javascript>" + "alert('Updated Successfully');" + "</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = UpdateCmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Subject_Master");
            conn.Close();
            return;


        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtnEdit = (LinkButton)sender;
                GridViewRow gvRow = lnkbtnEdit.NamingContainer as GridViewRow;
                int SubjectId = int.Parse(((HiddenField)gvRow.FindControl("hdnSubjectId")).Value.ToString());
                string SubjectName = ((Label)gvRow.FindControl("lblSubjectName")).Text.ToString();
                string CourseId = ((Label)gvRow.FindControl("lblCourseId")).Text.ToString();
                string BranchName = ((Label)gvRow.FindControl("lblBranchName")).Text.ToString();
                string Description = ((Label)gvRow.FindControl("lblDescription")).Text.ToString();
                txtSubjectName.Text = SubjectName;
                txtDescription.Text = Description;
                DDLCourseId.Text = CourseId;
                DDLBranchName.Text = BranchName;
                hdnSubjectId.Value = SubjectId.ToString();
                ViewState["SubjectId"] = SubjectId.ToString();
                ViewState["SubjectName"] = SubjectName;
                ViewState["CourseId"] = CourseId;
                ViewState["BranchName"] = BranchName;
                ViewState["Description"] = Description;
                btnAdd.Visible = false;
                btnEdit.Visible = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void resetFields()
        {
            txtSubjectName.Text = "";
            txtDescription.Text = "";
            DDLBranchName.Text = "";
            DDLCourseId.Text = "";
            btnAdd.Visible = true;
            btnEdit.Visible = false;
        }

        protected void btnaddreset_Click(object sender, EventArgs e)
        {
            {
                txtSubjectName.Text = "";
                txtDescription.Text = "";
                DDLBranchName.Text = "";
                DDLCourseId.Text = "";
            }
        }

        public DataSet getSubject()
        {
            DataSet dsSubject = new DataSet();
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open();
                query = "select * from Subject_Master where Is_Active = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dsSubject);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dsSubject;
        }


        public void loadGridview()
        {
            DataSet dsSubject = getSubject();
            gvSubject.DataSource = dsSubject;
            gvSubject.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (btnAdd.Visible == true)
                resetFields();
            if (btnEdit.Visible == true)
                resetEditFields();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            resetFields();
        }
        private void resetEditFields()
        {
            DDLBranchName.Text = (string)ViewState["BranchName"];
            txtSubjectName.Text = (string)ViewState["SubjectName"];
            txtDescription.Text = (string)ViewState["Description"];
            DDLCourseId.Text = (string)ViewState["CourseId"];
            hdnSubjectId.Value = (string)ViewState["SubjectId"];
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            gvSubject.Visible = true;
            loadGridview();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }

    }
}
