using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using System.Data;
using System.Data.SqlClient;

namespace Final_Report_SMPS
{
    public partial class Other_College_Detail : System.Web.UI.Page
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
           
            //TxtUpdatedDate.Text = DateTime.Now.Date.ToShortDateString();
            //this.TxtUpdatedDate.Visible = false;
            //this.LblUpdatedDate.Visible = false;
            this.BtnBack.Visible = false;



             //BtnAdd.Attributes.Add("onclick", "javascript:alert('Hi,Succesfully added');");
            //Delete.Attributes.Add("onclick", "javascript:alert('Hi, Succesfully Updateds');");
            //TxtUpdatedDate.Text = DateTime.Now.ToString();
            //TxtUpdatedDate.Text = DateTime.Now.Date.ToShortDateString();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {



            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("INSERT INTO Pool_Campus_College_Master(CollegeName,CollegeAddress,ContactNumber,WebSite,Description,Updated_Date,Updated_By) VALUES(@CollegeName,@CollegeAddress,@ContactNumber,@WebSite,@Description,@Updated_Date,@Updated_By)", conn);
            cmd.CommandType = CommandType.Text;
            
            cmd.Parameters.AddWithValue("@CollegeName", TxtCollName.Text);
            cmd.Parameters.AddWithValue("@CollegeAddress", TxtCollAddress.Text);
            cmd.Parameters.AddWithValue("@ContactNumber", TxtContactNo.Text);
            cmd.Parameters.AddWithValue("@WebSite", TxtWebSite.Text);
            cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
            cmd.Parameters.AddWithValue("@Updated_Date",SqlDbType.DateTime).Value=DateTime.Now.Date.ToShortDateString();

            cmd.Parameters.AddWithValue("@Updated_By", Txt_updby.Text);
            
            conn.Open();
            cmd.ExecuteNonQuery();
            
            TxtCollAddress.Text = "";
            TxtCollName.Text = "";
            TxtContactNo.Text = "";
            TxtWebSite.Text = "";
            TxtDescription.Text = "";
            //TxtUpdatedDate.Text = "";
            //TxtUpdatedBy.Text = "";
           // Response.Redirect("Other_College_Detail.aspx");
            
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Pool_Campus_College_Master_Update.aspx");
        }

        protected void BtnShowAll_Click(object sender, EventArgs e)
        {
            this.TxtCollName.Visible = false;
            this.TxtCollAddress.Visible = false;
            this.TxtContactNo.Visible = false;
            this.TxtWebSite.Visible = false;
            this.TxtDescription.Visible = false;
            this.BtnDelete.Visible = false;
           // this.DDLCompanyName.Visible = false;
            this.BtnAdd.Visible = false;
            this.BtnShowAll.Visible = false;
            this.LblCollegeAddress.Visible = false;
            this.LblCollegeName.Visible = false;
            this.LblContactNo.Visible = false;
            this.LblWebSite.Visible = false;
            this.LblDescription.Visible = false;
            //this.LblCompName.Visible = false;
            this.BtnEdit.Visible = false;
             this.BtnBack.Visible = true;
            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Pool_Campus_College_Master where Is_Active=1 ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Pool_Campus_College_Master");
            //grdsched.DataSourceID = null;
            GrdStudent_Det.DataSource = ds;
            GrdStudent_Det.DataBind();
            conn.Close();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_College_Master.aspx");
            this.BtnBack.Visible = true;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_College_Master_Delete.aspx");
             
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");

        }

    }
}

        