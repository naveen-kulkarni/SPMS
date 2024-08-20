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
    public partial class AddCourse : System.Web.UI.Page
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
                gvCourse.Visible = false;
                loadGridview();
                selectadddepartment();

            }
        }
        public void selectadddepartment()
        {


            DDLdeptid.Items.Add(new ListItem("Select Department", ""));
            DDLdeptid.AppendDataBoundItems = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Department_Master where Is_Active= 1", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            DDLdeptid.DataSource = dt;
            DDLdeptid.DataTextField = "Dept_Name";
            DDLdeptid.DataValueField = "DepartmentId";
            DDLdeptid.DataBind();
        }

        public void UpdateCourse(int CourseId)
        {
           
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Course_Master set  CourseName=@CourseName, BranchName=@BranchName, DepartmentId=@DepartmentId, Description=@Description, Full_Time=@Full_Time, Part_Time=@Part_Time, Correspondance=@Correspondance, Is_Active=1,Updated_Date=@Updated_Date, Updated_By=@Updated_By where CourseId=@CourseId", conn);
            UpdateCmd.CommandType = CommandType.Text;
            UpdateCmd.Parameters.AddWithValue("@CourseId", CourseId);
            UpdateCmd.Parameters.AddWithValue("@CourseName", txtcourseName.Text);
            UpdateCmd.Parameters.AddWithValue("@BranchName", txtBranchName.Text);
            UpdateCmd.Parameters.AddWithValue("@DepartmentId", DDLdeptid.Text);
            UpdateCmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            UpdateCmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now.Date.ToShortDateString());
            UpdateCmd.Parameters.AddWithValue("@Updated_By", Txt_updby);
            /*if (ChckCorrospondance.Checked == true)
             {
             UpdateCmd.Parameters.AddWithValue("@Correspondance", true);
             }
             if (ChckFullTime.Checked == true)
             {
             UpdateCmd.Parameters.AddWithValue("@Full_Time", true);
             }
             if (ChckPartTime.Checked == true)
             {
             UpdateCmd.Parameters.AddWithValue("@Part_Time", true);
             }*/

            UpdateCmd.Parameters.AddWithValue("@Correspondance", ChckCorrospondance.Checked == true ? true : false);
            UpdateCmd.Parameters.AddWithValue("@Full_Time", ChckFullTime.Checked == true ? true : false);
            UpdateCmd.Parameters.AddWithValue("@Part_Time", ChckPartTime.Checked == true ? true : false);

            conn.Open();
            UpdateCmd.ExecuteNonQuery();
            string aler = "<script language=javascript>" + "alert('Updated Successfully');" + "</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = UpdateCmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Course_Master");
            conn.Close();
            return;

        }

        public void DeleteCourse(int CourseId, string UserID)
        {
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open(); //Open the database connection
                query = "update Course_Master set Is_Active = 0, Updated_By = '" + UserID + "'" +
                                " where CourseId = " + CourseId;
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
                int CourseId = int.Parse(((HiddenField)gvRow.FindControl("hdnCourseID")).Value.ToString());
                string UserID = "1";
                DeleteCourse(CourseId, UserID);
                loadGridview();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataSet getCourse()
        {
            DataSet dsdepts = new DataSet();
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open();
                query = "select * from Course_Master where Is_Active = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dsdepts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dsdepts;
        }

        public void loadGridview()
        {
            DataSet dsCourse = getCourse();
            gvCourse.DataSource = dsCourse;
            gvCourse.DataBind();
        }

        protected void btnaddreset_Click(object sender, EventArgs e)
        {
            {
                txtBranchName.Text = "";
                txtcourseName.Text = "";
                txtDescription.Text = "";
                ChckFullTime.Checked = false;
                ChckPartTime.Checked = false;
                ChckCorrospondance.Checked = false;

            }
        }

        public void resetFields()
        {
            txtBranchName.Text = "";
            txtcourseName.Text = "";
            txtDescription.Text = "";
            DDLdeptid.Text = "";
            ChckFullTime.Checked = false;
            ChckPartTime.Checked = false;
            ChckCorrospondance.Checked = false;
            btnAdd.Visible = true;
            btnEdit.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtcourseName.Text == "" || DDLdeptid.Text == "")
            {

                string alert = "<script language=javascript>" + "alert('course Name, branch name and Department ID is required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                return;

            }
            else if (txtBranchName.Text == "")
            {

                string alet = "<script language=javascript>" + "alert('If no specific branch name, Please enter your Course as Branch name');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alet);
                return;

            }
            else if (ChckFullTime.Checked == false && ChckPartTime.Checked == false && ChckCorrospondance.Checked == false)
            {
                string aler = "<script language=javascript>" + "alert('Which Type of course you want to offer');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
                return;
            }

            else
            {
                
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SPMSConnectionString1"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insert_Course_Master", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CourseName", txtcourseName.Text);
                cmd.Parameters.AddWithValue("BranchName", txtBranchName.Text);
                cmd.Parameters.AddWithValue("DepartmentId", DDLdeptid.Text);

                cmd.Parameters.AddWithValue("Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("Updated_Date", DateTime.Now.Date.ToShortDateString());
                cmd.Parameters.AddWithValue("Updated_By",Txt_updby.Text);

                cmd.Parameters.AddWithValue("@Correspondance", ChckCorrospondance.Checked == true ? true : false);
                cmd.Parameters.AddWithValue("@Full_Time", ChckFullTime.Checked == true ? true : false);
                cmd.Parameters.AddWithValue("@Part_Time", ChckPartTime.Checked == true ? true : false);

                conn.Open();
                cmd.ExecuteNonQuery();
                string aler = "<script language=javascript>" + "alert('Added Successfully');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
                return;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtcourseName.Text == "")
            {
                string alert = "<script language=javascript>" + "alert('Course Name is required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                return;
            }
            int CourseId = int.Parse(hdnCourseId.Value.ToString());
            string CourseName = txtcourseName.Text;
            string BranchName = txtBranchName.Text;
            string DeptId = DDLdeptid.Text;
            string Description = txtDescription.Text;
            UpdateCourse(CourseId);
            resetFields();
            loadGridview();
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtnEdit = (LinkButton)sender;
                GridViewRow gvRow = lnkbtnEdit.NamingContainer as GridViewRow;
                int CourseId = int.Parse(((HiddenField)gvRow.FindControl("hdnCourseId")).Value.ToString());

                txtcourseName.Text = ((Label)gvRow.FindControl("lblCourseName")).Text.ToString();
                txtBranchName.Text = ((Label)gvRow.FindControl("lblBranchName")).Text.ToString();
                DDLdeptid.Items.Add(((Label)gvRow.FindControl("lblDepartmentID")).Text.ToString());
                DDLdeptid.SelectedValue = "62";
                ChckCorrospondance.Checked = Convert.ToBoolean(((Label)gvRow.FindControl("lblCorrospondance")).Text);

                ChckFullTime.Checked = Convert.ToBoolean(((Label)gvRow.FindControl("lblFullTime")).Text);

                ChckPartTime.Checked = Convert.ToBoolean(((Label)gvRow.FindControl("lblPartTime")).Text);

                txtDescription.Text = ((Label)gvRow.FindControl("lblDescription")).Text.ToString();
                hdnCourseId.Value = CourseId.ToString();
                ViewState["CourseId"] = CourseId.ToString();
                //ViewState["CourseName"] = CourseName;
                //ViewState["BranchName"] = BranchName;
                //ViewState["DeptId"] = DeptId;
                // ViewState["Description"] = Description;
                btnAdd.Visible = false;
                btnEdit.Visible = true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            txtBranchName.Text = (string)ViewState["BranchName"];
            txtcourseName.Text = (string)ViewState["CourseName"];
            txtDescription.Text = (string)ViewState["Description"];
            hdnCourseId.Value = (string)ViewState["CourseId"];
            DDLdeptid.Text = (string)ViewState["DepartmentId"];
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            gvCourse.Visible = true;
            loadGridview();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }

    }
}