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
    public partial class AddBlog : System.Web.UI.Page
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
            
            PanelPost.Visible = false;
            PanelShow.Visible = false;
            DeleteBlog.Visible = false;
            updateblog.Visible = false;
            txtupdateddate.Text = DateTime.Now.Date.ToShortDateString();
            txtcreateddate.Text = DateTime.Now.Date.ToShortDateString();
            txtupdateddate.Enabled = false;
            txtcreateddate.Enabled = false;

            if (!IsPostBack)
            {
                loadGridview();

            }
        }

        public void FetchblogData()
        {
            if (!IsPostBack)
            {
                string connString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connString);
                string queryString = "select * from Blog_List where BlogTopic=@BlogTopic";
                SqlCommand comm = new SqlCommand(queryString, conn);
                comm.Parameters.AddWithValue("@BlogTopic", Ddlupdatetopic.SelectedItem.Value);
                conn.Open();
                comm.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {

                    txtupdatecontent.Text = dt.Rows[0]["BlogContent"].ToString();
                    //txtupdatecreatedby.Text = dt.Rows[0]["CreatedBy"].ToString();
                    //txtupdatecreateddate.Text = dt.Rows[0]["CreatedDate"].ToString();
                    txtupdateddate.Text = dt.Rows[0]["Updated_Date"].ToString();
                }

            }
        }


        public void updatettopic()
        {


            Ddlupdatetopic.Items.Add(new ListItem("@--Select Topic--@", ""));
            Ddlupdatetopic.AppendDataBoundItems = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select BlogTopic from Blog_List where Is_Active= 1", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            Ddlupdatetopic.DataSource = dt;
            Ddlupdatetopic.DataTextField = "BlogTopic";
            Ddlupdatetopic.DataValueField = "BlogTopic";
            Ddlupdatetopic.DataBind();

        }
        public void selecttopic()
        {


            Ddldelete.Items.Add(new ListItem("@--Select Topic--@", ""));
            Ddldelete.AppendDataBoundItems = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select BlogTopic from Blog_List where Is_Active= 1", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            Ddldelete.DataSource = dt;
            Ddldelete.DataTextField = "BlogTopic";
            Ddldelete.DataValueField = "BlogTopic";
            Ddldelete.DataBind();

        }

        public void loadGridview()
        {
            DataSet dsBlog = getList();
            gvBlog.DataSource = dsBlog;
            gvBlog.DataBind();
        }
        public DataSet getList()
        {
            DataSet dslist = new DataSet();
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open();
                query = "select * from Blog_List where Is_Active = 1";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dslist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dslist;
        }
        public void CreateBlog(string topic, string content, string createdby, string createddate, string updatedby, string updateddate)
        {
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open();
                query = "insert into Blog_List (BlogTopic, BlogContent, CreatedBy, CreatedDate ,Updated_Date, Updated_By )" +
                   "values ('" + topic + "','" + content + "','" + createdby + "','" + createddate + "','" + updateddate + "','" + updatedby + "')";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                string alert = "<script language=javascript>" + "alert('added successfully');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                PanelPost.Visible = true;
                return;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void resetFields()
        {
            txttopic.Text = "";
            txtcontent.Text = "";
            txtcreatedby.Text = "";
            txtcreateddate.Text = "";
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            if (txttopic.Text == "")
            {
                string alert = "<script language=javascript>" + "alert('Topic is required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                PanelPost.Visible = true;
                return;
            }
            if (txtcontent.Text == "")
            {
                string alert = "<script language=javascript>" + "alert('Blog Content required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                return;
            }
            string Topic = txttopic.Text;
            string Content = txtcontent.Text;
            string CreatedBy = txtcreatedby.Text;
            string CreatedDate = txtcreateddate.Text;
            string UpdatedBy = CreatedBy;
            string UpdatedDate = CreatedDate;
            CreateBlog(Topic, Content, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate);
            resetFields();
            loadGridview();
            PanelPost.Visible = true;
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            PanelPost.Visible = true;
            PanelShow.Visible = false;
            DeleteBlog.Visible = false;
            BtnQueries.Visible = false;
            btndelete.Visible = false;
            btnedit.Visible = false;
            updateblog.Visible = false;
        }
        protected void gvBlog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkbtnBlogList = (LinkButton)(e.Row.FindControl("lnkbtnBlogList"));
                string BlogListID = lnkbtnBlogList.CommandArgument.ToString();
                lnkbtnBlogList.Attributes.Add("onclick", "openDetails('" + BlogListID + "')");


            }
        }
        protected void BtnQueries_Click(object sender, EventArgs e)
        {
            PanelPost.Visible = false;
            PanelShow.Visible = true;
            DeleteBlog.Visible = false;
            updateblog.Visible = false;
            btndelete.Visible = false;
            btnedit.Visible = false;
            BtnAdd.Visible = false;
            BtnQueries.Visible = true;

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (Ddldelete.Text == "")
            {

                string alert = "<script language=javascript>" + "alert('Please select the Topic to delete');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                DeleteBlog.Visible = true;
                return;
            }
            else
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SPMSConnectionString1"].ConnectionString);
                SqlCommand cmd = new SqlCommand("update Blog_List set Is_Active = 0 where BlogTopic = '" + Ddldelete.Text + "' ", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();

                string aler = "<script language=javascript>" + "alert('Deleted Successfully');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
                DeleteBlog.Visible = true;
                return;

            }
        }

        protected void btndelete_Click1(object sender, EventArgs e)
        {
            selecttopic();

            PanelPost.Visible = false;
            PanelShow.Visible = false;
            DeleteBlog.Visible = true;
            updateblog.Visible = false;
            btnedit.Visible = false;
            BtnAdd.Visible = false;
            btndelete.Visible = true;
        }



        protected void btnaddback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBlog.aspx");
        }

        protected void btnshowback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBlog.aspx");
        }

        protected void btndeleteback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBlog.aspx");
        }

        protected void btnupdatevback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBlog.aspx");
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            updateblog.Visible = true;
            btnaddback.Visible = false;
            BtnQueries.Visible = false;
            btndelete.Visible = false;
            PanelPost.Visible = false;
            PanelShow.Visible = false;
            DeleteBlog.Visible = false;
            BtnAdd.Visible = false;
            updatettopic();
            //FetchblogData();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBlog.aspx");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (Ddlupdatetopic.Text == "")
            {

                string alert = "<script language=javascript>" + "alert('Please select the Blog Topic to Update');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                updateblog.Visible = true;
                return;
            }


            
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand UpdateCmd = new SqlCommand("update Blog_List set  BlogTopic=@BlogTopic, BlogContent=@BlogContent, CreatedBy=@CreatedBy, CreatedDate=@CreatedDate, Is_Active=1, Updated_Date=@Updated_Date, Updated_By=@Updated_By where BlogTopic=@BlogTopic", conn);
            UpdateCmd.CommandType = CommandType.Text;
            UpdateCmd.Parameters.AddWithValue("@BlogTopic", Ddlupdatetopic.Text);
            UpdateCmd.Parameters.AddWithValue("@BlogContent", txtupdatecontent.Text);
            UpdateCmd.Parameters.AddWithValue("@CreatedBy", Txt_updby.Text);
            UpdateCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.Date.ToShortDateString());
            UpdateCmd.Parameters.AddWithValue("@Updated_Date", txtupdateddate.Text);
            UpdateCmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);


            conn.Open();
            UpdateCmd.ExecuteNonQuery();
            string aler = "<script language=javascript>" + "alert('Updated Successfully');" + "</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", aler);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = UpdateCmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Blog_List");
            conn.Close();
            updateblog.Visible = true;
            return;

        }

        protected void Ddlupdatetopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddlupdatetopic.SelectedIndex != -1)
            {

                updateblog.Visible = true;
                FetchblogData();




            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }

    }
}