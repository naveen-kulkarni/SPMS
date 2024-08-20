using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;

namespace Final_Crystal_Reports
{
    public partial class Test_Schedule : System.Web.UI.Page
    {
        private string DEPT_ID;
        private string Cmp_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BtnShowDept.Visible = false;
            this.Show.Visible = false;
            if (!IsPostBack)
            {
                demo(DEPT_ID);
                Cmp_Name(Cmp_ID);
            }
        }
         public void demo(String DEPT_ID)
        {
            DataSet dsEmp = new DataSet();
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetDBConnection();
            con.Open();
            String query = "select distinct department from test_schedule";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            adap.Fill(dsEmp);
            DDLDeptName.DataSource = dsEmp;
            DDLDeptName.DataTextField = "DEPARTMENT";
            //DropDownList2.DataValueField="EMPID";
            DDLDeptName.DataBind();
            // DropDownList2.Visible = true;

        }

        public void Cmp_Name(String Cmp_ID)
        {
            DataSet dsEmp = new DataSet();
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetDBConnection();
            con.Open();
            String query = "select companyname from test_schedule";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            adap.Fill(dsEmp);
            DDLCmpName.DataSource = dsEmp;
            DDLCmpName.DataTextField = "CompanyName";
            //DropDownList2.DataValueField="EMPID";
            DDLCmpName.DataBind();
            //DropDownList2.Visible = true;

        }

         



        public DataSet getAllOrders()
        {
            //Connection string replace 'databaseservername' with your db server name
            string sqlCon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=STUDENT_MANAGEMENT;Data Source=SYS2\\SQLEXPRESS";
            //string sqlCon = ConfigurationManager.AppSettings["conStr1"].ToString();
            SqlConnection Con = new SqlConnection(sqlCon);
            SqlCommand cmd = new SqlCommand();
            DataSet ds = null;
            SqlDataAdapter adapter;
            try
            {
                Con.Open();
                cmd.CommandText = "select * from test_schedule where COMPANYNAME='" + DDLCmpName.Text + "'";
                cmd.CommandType = CommandType.Text;
                // cmd.Parameters.Add(new SqlParameter("@Customer_Name", DDLCmpName.Text));
                //cmd.Parameters.Add(new SqlParameter("@Password", bUser.Password));
                cmd.Connection = Con;
                ds = new DataSet();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Test_Schedule");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                if (Con.State != ConnectionState.Closed)
                    Con.Close();
            }
            return ds;
        }



        public DataSet getAllOrdersDept()
        {
            //Connection string replace 'databaseservername' with your db server name
            string sqlCon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=STUDENT_MANAGEMENT;Data Source=SYS2\\SQLEXPRESS";
            //string sqlCon = ConfigurationManager.AppSettings["conStr1"].ToString();
            SqlConnection Con = new SqlConnection(sqlCon);
            SqlCommand cmd = new SqlCommand();
            DataSet ds = null;
            SqlDataAdapter adapter;
            try
            {
                Con.Open();
                cmd.CommandText = "select * from test_schedule where Department='" + DDLDeptName.Text + "'";
                cmd.CommandType = CommandType.Text;
                // cmd.Parameters.Add(new SqlParameter("@Customer_Name", DDLCmpName.Text));
                //cmd.Parameters.Add(new SqlParameter("@Password", bUser.Password));
                cmd.Connection = Con;
                ds = new DataSet();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Test_Schedule");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                if (Con.State != ConnectionState.Closed)
                    Con.Close();
            }
            return ds;
        }


       
 
                 
        
         
        

        protected void Show_Click(object sender, EventArgs e)
        {
             ReportDocument rptDoc = new ReportDocument();
            DataSet2 ds = new DataSet2();
            DataTable dt = new DataTable();
            dt.TableName = "Crystal Report ";
            dt = getAllOrders().Tables[0];
            ds.Tables[0].Merge(dt);
            rptDoc.Load(Server.MapPath("CrystalReport2.rpt"));
            rptDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rptDoc;
        }

        protected void BtnShowDept_Click(object sender, EventArgs e)
        {
         ReportDocument rptDoc = new ReportDocument();
            DataSet2 ds = new DataSet2();
            DataTable dt = new DataTable();
            dt.TableName = "Crystal Report ";
            dt = getAllOrdersDept().Tables[0];
            ds.Tables[0].Merge(dt);
            rptDoc.Load(Server.MapPath("CrystalReport2.rpt"));
            rptDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rptDoc;
        }

        protected void DDLCmpSelCriteria_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (DDLCmpSelCriteria.Text == "Department")
            {
                this.BtnShowDept.Visible = true;
                this.DDLDeptName.Visible = true;
                this.BtnShowDept.Visible = true;
                this.DDLCmpName.Visible = false;
                // this.DDLYearWise.Visible = false;
                String Dept_ID = DDLCmpSelCriteria.SelectedItem.Value.ToString();
                demo(Dept_ID);
            }
            else if (DDLCmpSelCriteria.Text == "Company Name")
            {
                this.DDLCmpName.Visible = true;
                this.Show.Visible = true;
                this.Show.Visible = true;
                this.DDLDeptName.Visible = false;
                //this.DDLYearWise.Visible = false;
                String Cmp_ID = DDLCmpSelCriteria.SelectedItem.Value.ToString();
                Cmp_Name(Cmp_ID);

            }
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        

        

    }
}
   
