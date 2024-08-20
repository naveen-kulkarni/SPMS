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
    public partial class Blog : System.Web.UI.Page
    {
        DBConnection obj = new DBConnection();
        string query = "";
        string BlogListID;
        int BlogListId;
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
            BlogListID = (string)Request.QueryString["BlogListID"];
            BlogListId = Int32.Parse(BlogListID);
            txtreplydate.Text = DateTime.Now.Date.ToShortDateString();
            if (!IsPostBack)
            {
                loadGridview(BlogListId);
                loadControls(BlogListID);
            }
        }
        public void loadGridview(int BlogListId)
        {
            DataSet dsComment = new DataSet();
            dsComment = getComment(BlogListId);
            GVComment.DataSource = dsComment;
            GVComment.DataBind();
        }
        public DataSet getComment(int BlogListId)
        {
            DataSet dsComments = new DataSet();
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open();
                query = "select * from Blog_Details where Is_Active = 1 and BlogListID = " + BlogListId;
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dsComments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dsComments;
        }
        private DataSet getQueryDetails(int BlogListId)
        {
            DataSet dsQuery = new DataSet();
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open();
                query = "select * from Blog_List where Is_Active = 1 and BlogListID=" + BlogListId;
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dsQuery);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dsQuery;
        }
        private void loadControls(string BlogListID)
        {
            int intBlogListId = Int32.Parse(BlogListID);
            DataSet dsQueryDetails = getQueryDetails(intBlogListId);
            DataRow dr = dsQueryDetails.Tables[0].Rows[0];
            lbltopic.Text = dr["BlogTopic"].ToString();
            lblcontent.Text = dr["BlogContent"].ToString();
            lblcreatedBy.Text = dr["CreatedBy"].ToString();
            lblcreatedDate.Text = dr["CreatedDate"].ToString();
        }

        protected void BtnReply_Click(object sender, EventArgs e)
        {
            if (txtReply.Text == "")
            {
                string alert = "<script language=javascript>" + "alert('Comment is required');" + "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                return;
            }
            int BlogListID = BlogListId;
            string Reply = txtReply.Text;
            string ReplyBy = txtreplyby.Text;
            string ReplyDate = txtreplydate.Text;
            string updatedby = ReplyBy;
            string updateddate = ReplyDate;
            ReplyQuery(BlogListID, Reply, ReplyBy, ReplyDate, updateddate, updatedby);
            resetFields();
        }
        public void resetFields()
        {
            txtReply.Text = "";
            txtreplyby.Text = "";
            txtreplydate.Text = "";
        }
        public void ReplyQuery(int BlogListID, string Reply, string ReplyBy, string ReplyDate, string UpdatedDate, string UpdatedBy)
        {
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open(); //Open the database connection
                query = "insert into Blog_Details (BlogListID, Postings, Postedby, Posteddate, Updated_Date, Updated_By)" +
                "values ('" + BlogListID + "','" + Reply + "','" + ReplyBy + "','" + ReplyDate + "','" + UpdatedDate + "','" + UpdatedBy + "')";
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
                Response.Redirect("Blog.aspx?BlogListID=" + BlogListID);
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