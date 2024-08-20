using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Final_Report_SMPS
{
    public partial class Other_College_Delete : System.Web.UI.Page
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
           
            BtnDelete.Attributes.Add("onclick", "javascript:alert('Deleted successfully');");
            //TxtUpdatedDate.Text = DateTime.Now.Date.ToShortDateString();
            if (!IsPostBack)
            {
                DDLCollegeName.Items.Add(new ListItem("@--Select College Name--@", ""));
                DDLCollegeName.AppendDataBoundItems = true;

                string connstr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connstr);
                string query = "select * from Pool_Campus_College_Master where Is_Active=1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DDLCollegeName.DataSource = ds;
                DDLCollegeName.DataTextField = "CollegeName";
                DDLCollegeName.DataValueField = "PoolCampusCollegeID";
                DDLCollegeName.DataBind();

            }

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
         //   if (DropDownList1.Text != "")
           // {

            string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                          SqlCommand cmd = new SqlCommand("update  Pool_Campus_College_Master set Is_Active=0 where PoolCampusCollegeId = '" + DDLCollegeName.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Pool_Campus_College_Master");
                GrdStudent_Det.DataSourceID = null;
                //Response.Redirect("Other_College_Detail.aspx");
                //grdsched.DataSource = ds;
                GrdStudent_Det.DataBind();
                conn.Close();
                //Label1.Visible = true;
                //Label1.Text = "You deleted successfully";
           // }
            //else
            //{
             //   Label1.Visible = true;
              //  Label1.Text = "Please enter the department that u want to delete";
            //}
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_College_Master.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");

        }

        

        
    }
}