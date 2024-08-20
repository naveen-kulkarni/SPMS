using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;


namespace Final_Crystal_Reports
{
    public partial class Company_List : System.Web.UI.Page
    {
        private string DEPT_ID;
        private string Year_ID;
        private string Cmp_ID;


        protected void Page_Load(object sender, EventArgs e)
        {

            this.BtnHome.Visible = false;
            this.Button1.Visible = false;
            this.DDLCmpWise.Visible = false;
            this.DDLDeptWise.Visible = false;
            this.DDLYearWise.Visible = false;

            //InitializeComponent();




            //if (!IsPostBack)
            //{

            //    Dept(DEPT_ID);
            //    Year_Wise(Year_ID);
            //    Cmp_Name(Cmp_ID);

            //}
        }


        public void Dept(String DEPT_ID)
        {
            DDLDeptWise.Items.Add(new ListItem("@--Select Department Name--@", ""));
            DDLDeptWise.AppendDataBoundItems = true;
            DataSet dsEmp = new DataSet();
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetDBConnection();
            con.Open();
            String query = "select distinct department from company_detail";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            adap.Fill(dsEmp);
            DDLDeptWise.DataSource = dsEmp;
            DDLDeptWise.DataTextField = "DEPARTMENT";
            //DropDownList2.DataValueField="EMPID";
            DDLDeptWise.DataBind();
            // DropDownList2.Visible = true;

        }

        public void Cmp_Name(String Cmp_ID)
        {

            DDLCmpWise.Items.Add(new ListItem("@--Select Company Name--@", ""));
            DDLCmpWise.AppendDataBoundItems = true;
            DataSet dsEmp = new DataSet();
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetDBConnection();
            con.Open();
            String query = "select distinct companyname from company_detail";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            adap.Fill(dsEmp);
            DDLCmpWise.DataSource = dsEmp;
            DDLCmpWise.DataTextField = "CompanyName";
            //DropDownList2.DataValueField="EMPID";
            DDLCmpWise.DataBind();
            //DropDownList2.Visible = true;

        }

        public void Year_Wise(String Year_ID)
        {
            DDLYearWise.Items.Add(new ListItem("@--Select Academic Year--@", ""));
            DDLYearWise.AppendDataBoundItems = true;
            DataSet dsEmp = new DataSet();
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetDBConnection();
            con.Open();
            String query = "select distinct Year1 from company_detail";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            adap.Fill(dsEmp);
            DDLYearWise.DataSource = dsEmp;
            DDLYearWise.DataTextField = "Year1";
            //DropDownList2.DataValueField="EMPID";
            DDLYearWise.DataBind();
            //DropDownList2.Visible = true;

        }



        public DataSet getAllOrdersCmp()
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
                cmd.CommandText = "select * from COMPANY_DETAIL where COMPANYNAME='" + DDLCmpWise.Text + "'";
                cmd.CommandType = CommandType.Text;
                // cmd.Parameters.Add(new SqlParameter("@Customer_Name", DDLCmpName.Text));
                //cmd.Parameters.Add(new SqlParameter("@Password", bUser.Password));
                cmd.Connection = Con;
                ds = new DataSet();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Company_Detail");
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
                cmd.CommandText = "select * from COMPANY_DETAIL where Department='" + DDLDeptWise.Text + "'";
                cmd.CommandType = CommandType.Text;
                // cmd.Parameters.Add(new SqlParameter("@Customer_Name", DDLCmpName.Text));
                //cmd.Parameters.Add(new SqlParameter("@Password", bUser.Password));
                cmd.Connection = Con;
                ds = new DataSet();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Company_Detail");
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


        public DataSet getAllOrdersYear()
        {
            string sqlCon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=STUDENT_MANAGEMENT;Data Source=SYS2\\SQLEXPRESS";
            SqlConnection Con = new SqlConnection(sqlCon);
            SqlCommand cmd = new SqlCommand();
            DataSet ds = null;
            SqlDataAdapter adapter;
            try
            {
                Con.Open();
                cmd.CommandText = "select * from COMPANY_DETAIL where Year1='" + DDLYearWise.Text + "'";
                cmd.CommandType = CommandType.Text;
                // cmd.Parameters.Add(new SqlParameter("@Customer_Name", DDLCmpName.Text));
                cmd.Connection = Con;
                ds = new DataSet();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "Company_Detail");
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



        protected void DDLCmpSelCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLCmpSelCriteria.Text == "Department")
            {
                this.DDLDeptWise.Visible = true;
                this.DDLCmpWise.Visible = false;
                this.DDLYearWise.Visible = false;
                String Dept_ID = DDLCmpSelCriteria.SelectedItem.Value.ToString();
                Dept(Dept_ID);
            }
            else if (DDLCmpSelCriteria.Text == "Company Name")
            {
                this.DDLCmpWise.Visible = true;
                this.DDLDeptWise.Visible = false;
                this.DDLYearWise.Visible = false;
                String Cmp_ID = DDLCmpSelCriteria.SelectedItem.Value.ToString();
                Cmp_Name(Cmp_ID);

            }
            else if (DDLCmpSelCriteria.Text == "Year")
            {
                this.DDLYearWise.Visible = true;
                this.DDLDeptWise.Visible = false;
                this.DDLCmpWise.Visible = false;
                String Year_ID = DDLCmpSelCriteria.SelectedItem.Value.ToString();
                Year_Wise(Year_ID);

            }
        }






        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }

        protected void DDLDeptWise_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DDLDeptWise.Visible = true;
            this.Button1.Visible = true;
            ReportDocument rptDoc = new ReportDocument();
            DataSet1 ds = new DataSet1();
            DataTable dt = new DataTable();
            dt.TableName = "Crystal Report ";
            dt = getAllOrdersDept().Tables[0];
            ds.Tables[0].Merge(dt);
            rptDoc.Load(Server.MapPath("CrystalReport1.rpt"));
            rptDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rptDoc;
        }

        protected void DDLYearWise_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new ReportDocument();
            DataSet1 ds = new DataSet1();
            DataTable dt = new DataTable();
            dt.TableName = "Crystal Report";
            dt = getAllOrdersYear().Tables[0];
            ds.Tables[0].Merge(dt);
            rptDoc.Load(Server.MapPath("CrystalReport1.rpt"));
            rptDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rptDoc;
        }

        protected void DDLCmpWise_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new ReportDocument();
            DataSet1 ds = new DataSet1();
            DataTable dt = new DataTable();
            dt.TableName = "Crystal Report ";
            dt = getAllOrdersCmp().Tables[0];
            ds.Tables[0].Merge(dt);
            rptDoc.Load(Server.MapPath("CrystalReport1.rpt"));
            rptDoc.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rptDoc;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            //DataSet1 ds = new DataSet1();
           // rd.SetDataSource(ds);
             

            ExportOptions ex = new ExportOptions();
            DiskFileDestinationOptions destinationURL = new DiskFileDestinationOptions();
            ExcelFormatOptions formatOptionEXCEL = new ExcelFormatOptions();
            destinationURL.DiskFileName = "..//report.xls";
            ex.ExportDestinationType = ExportDestinationType.DiskFile;
            ex.ExportFormatType = ExportFormatType.Excel;
            ex.ExportDestinationOptions = destinationURL;
            ex.ExportFormatOptions = formatOptionEXCEL;
                        rd.Export(ex);

             

        }


    }



}


    

    
