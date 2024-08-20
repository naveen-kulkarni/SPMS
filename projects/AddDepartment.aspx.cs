using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Project
{
    public partial class AddDepartment : System.Web.UI.Page
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
            gvDept.Visible = false;
            if (!IsPostBack)
            {
                loadGridview();

            }
        }

        public void UpdateDept(int DeptId)
        {
            
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Department_Master set  Dept_Name=@Dept_Name, Degree=@Degree, Description=@Description, Is_Active=1,Updated_Date=@Updated_Date, Updated_By=@Updated_By where DepartmentId = @DepartmentId", conn);
            UpdateCmd.CommandType = CommandType.Text;
            UpdateCmd.Parameters.AddWithValue("@DepartmentId", DeptId);
            UpdateCmd.Parameters.AddWithValue("@Dept_Name", txtDeptName.Text);
            UpdateCmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            UpdateCmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now.Date.ToShortDateString());
            UpdateCmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);

            if (RdPG.Checked == true)
            {
                UpdateCmd.Parameters.AddWithValue("@Degree", RdPG.Text);
            }
            if (RdUG.Checked == true)
            {
                UpdateCmd.Parameters.AddWithValue("@Degree", RdUG.Text);
            }

            conn.Open();
            UpdateCmd.ExecuteNonQuery();
            string aler = "<script language=javascript>" + "alert('Updated Successfully');" + "</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = UpdateCmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Department_Master");
            conn.Close();
            return;

        }

        public void DeleteDept(int DeptId, string UserID)
        {
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open(); //Open the database connection
                query = "update Department_Master set Is_Active = 0, Updated_By = '" + UserID + "'" +
                                " where DepartmentId = " + DeptId;
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                string alert = "<script language=javascript>" + "alert('Deleted successfully');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                return;
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
                int DeptId = int.Parse(((HiddenField)gvRow.FindControl("hdnDeptID")).Value.ToString());
                string UserID = "1";
                DeleteDept(DeptId, UserID);
                loadGridview();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtDeptName.Text == "")
            {
                string alert = "<script language=javascript>" + "alert('Department Name is required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                return;
            }
            int DeptId = int.Parse(hdnDeptId.Value.ToString());
            string DeptName = txtDeptName.Text;
            string Description = txtDescription.Text;
            UpdateDept(DeptId);
            resetFields();
            loadGridview();
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkbtnEdit = (LinkButton)sender;
                GridViewRow gvRow = lnkbtnEdit.NamingContainer as GridViewRow;
                int StateId = int.Parse(((HiddenField)gvRow.FindControl("hdnDeptID")).Value.ToString());
                string StateName = ((Label)gvRow.FindControl("lblDeptName")).Text.ToString();
                string Description = ((Label)gvRow.FindControl("lblDescription")).Text.ToString();
                txtDeptName.Text = StateName;
                txtDescription.Text = Description;
                hdnDeptId.Value = StateId.ToString();
                ViewState["DepartmentId"] = StateId.ToString();
                ViewState["Dept_Name"] = StateName;
                ViewState["Description"] = Description;
                btnAdd.Visible = false;
                btnEdit.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataSet getDepts()
        {
            DataSet dsdepts = new DataSet();
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open();
                query = "select * from Department_Master where Is_Active = 1";
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
            DataSet dsDept = getDepts();
            gvDept.DataSource = dsDept;
            gvDept.DataBind();
        }


        protected void btnaddreset_Click(object sender, EventArgs e)
        {
            {
                txtDeptName.Text = "";
                txtDescription.Text = "";
                RdUG.Checked = false;
                RdPG.Checked = false;
            }
        }

        public void resetFields()
        {
            txtDeptName.Text = "";
            txtDescription.Text = "";
            RdPG.Checked = false;
            RdUG.Checked = false;
            btnAdd.Visible = true;
            btnEdit.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDeptName.Text == "")
            {
                string alert = "<script language=javascript>" + "alert('Department Name is required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                txtDeptName.Focus();
                return;
            }
            else
            {
                
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SPMSConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insert_Department_Master", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Dept_Name", txtDeptName.Text);
                cmd.Parameters.AddWithValue("Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("Updated_Date", DateTime.Now.Date.ToShortDateString());
                cmd.Parameters.AddWithValue("Updated_By", Txt_updby.Text);

                if (RdUG.Checked == true)
                {
                    cmd.Parameters.AddWithValue("Degree", RdUG.Text);
                }
                else if (RdPG.Checked == true)
                {
                    cmd.Parameters.AddWithValue("Degree", RdPG.Text);
                }
                else if (RdUG.Checked == false && RdPG.Checked == false)
                {
                    string alert = "<script language=javascript>" + "alert('Degree type is required');" + "</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                    return;
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                string aler = "<script language=javascript>" + "alert(' Added Successfully');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
                resetFields();
                return;
            }
        }

        private void resetEditFields()
        {
            txtDeptName.Text = (string)ViewState["Dept_Name"];
            txtDescription.Text = (string)ViewState["Description"];
            hdnDeptId.Value = (string)ViewState["DepartmentId"];
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (btnAdd.Visible == true)
                resetFields();
            if (btnEdit.Visible == true)
                resetEditFields();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            gvDept.Visible = true;
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