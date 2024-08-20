using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Final_Crystal_Reports
{
    public partial class Eligible_Students : System.Web.UI.Page
    {
        private string DEPT_ID;
        private string Year_ID;
        private string Cmp_ID;


        protected void Page_Load(object sender, EventArgs e)
        {



            //ReportDocument rptDoc = new ReportDocument();
            //DataSet1 ds = new DataSet1();
            //DataTable dt = new DataTable();
            //dt.TableName = "Crystal Report Example";
            //dt = getAllOrders().Tables[0];
            //ds.Tables[0].Merge(dt);
            //rptDoc.Load(Server.MapPath("CrystalReport1.rpt"));
            //rptDoc.SetDataSource(ds);
            //CrystalReportViewer1.ReportSource = rptDoc;







            //if (!IsPostBack)
            //  {

            //demo(DEPT_ID);
            //Year_Wise(Year_ID);
            //        Cmp_Name(Cmp_ID);

            //      }
        }


        //public void demo(String DEPT_ID)
        //{
        //    DataSet dsEmp = new DataSet();
        //    DBConnection db = new DBConnection();
        //    SqlConnection con = db.GetDBConnection();
        //    con.Open();
        //    String query = "select distinct department from company_detail";
        //    SqlDataAdapter adap = new SqlDataAdapter(query, con);
        //    adap.Fill(dsEmp);
        //    DDLDeptWise.DataSource = dsEmp;
        //    DDLDeptWise.DataTextField = "DEPARTMENT";
        //    //DropDownList2.DataValueField="EMPID";
        //    DDLDeptWise.DataBind();
        //    // DropDownList2.Visible = true;

        //}

        public void Cmp_Name(String Cmp_ID)
        {
            DDLCmpWise.Items.Add(new ListItem("@--Select College Name--@", ""));
            DDLCmpWise.AppendDataBoundItems = true;
            DataSet dsEmp = new DataSet();
            DBConnection db = new DBConnection();
            SqlConnection con = db.GetDBConnection();
            con.Open();
            String query = "select * from Pool_Campus_College_Master";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            adap.Fill(dsEmp);
            DDLCmpWise.DataSource = dsEmp;
            DDLCmpWise.DataTextField = "CollegeName";
            DDLCmpWise.DataValueField = "PoolCampusCollegeId";
            DDLCmpWise.DataBind();
            //DropDownList2.Visible = true;

        }

        //public void Year_Wise(String Year_ID)
        //{
        //    DataSet dsEmp = new DataSet();
        //    DBConnection db = new DBConnection();
        //    SqlConnection con = db.GetDBConnection();
        //    con.Open();
        //    String query = "select distinct Year1 from company_detail";
        //    SqlDataAdapter adap = new SqlDataAdapter(query, con);
        //    adap.Fill(dsEmp);
        //    DDLYearWise.DataSource = dsEmp;
        //    DDLYearWise.DataTextField = "Year1";
        //    //DropDownList2.DataValueField="EMPID";
        //    DDLYearWise.DataBind();
        //    //DropDownList2.Visible = true;

        //}



        //public DataSet3 getAllOrders()
        //{
        //    //Connection string replace 'databaseservername' with your db server name
        //    string sqlCon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=spms;Data Source=SYS2\\SQLEXPRESS";
        //    //string sqlCon = ConfigurationManager.AppSettings["conStr1"].ToString();
        //    SqlConnection Con = new SqlConnection(sqlCon);
        //    SqlCommand cmd = new SqlCommand();
        //    DataSet ds = null;
        //    DataSet3 ds3 = new DataSet3();
        //    SqlDataAdapter adapter;
        //    try
        //    {
        //        Con.Open();
        //        // cmd.CommandText = "select m.collegename,m.collegeaddress,s.course,s.Date_Of_Birth from Pool_Campus_College_Master m left join Pool_Campus_Eligible_Students s on m.PoolCampusCollegeId=s.PoolCampusCollegeId where m.CollegeName='" + DDLCmpWise.Text + "'";
        //        cmd.CommandText = "select m.collegename as 'CollegeName',m.collegeaddress as 'CollegeAddress',s.First_Name as 'First_Name', s.Department as 'Department' from Pool_Campus_College_Master m inner join Pool_Campus_Eligible_Students s on m.PoolCampusCollegeId=s.PoolCampusCollegeId  where m.CollegeName='" + DDLCmpWise.Text + "'";
        //        cmd.CommandType = CommandType.Text;
        //        // cmd.Parameters.Add(new SqlParameter("@Customer_Name", DDLCmpName.Text));
        //        //cmd.Parameters.Add(new SqlParameter("@Password", bUser.Password));
        //        cmd.Connection = Con;
        //        ds = new DataSet();
        //        adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(ds);
        //        ds3.Report.Merge(ds.Tables[0]);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //        if (Con.State != ConnectionState.Closed)
        //            Con.Close();
        //    }
        //    return ds3;
        //}



        //public DataSet getAllOrdersDept()
        //{
        //    //Connection string replace 'databaseservername' with your db server name
        //    string sqlCon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=STUDENT_MANAGEMENT;Data Source=SYS2\\SQLEXPRESS";
        //    //string sqlCon = ConfigurationManager.AppSettings["conStr1"].ToString();
        //    SqlConnection Con = new SqlConnection(sqlCon);
        //    SqlCommand cmd = new SqlCommand();
        //    DataSet ds = null;
        //    SqlDataAdapter adapter;
        //    try
        //    {
        //        Con.Open();
        //        cmd.CommandText = "select studentname,STUDENTCOURSE,year1 from COMPANY_DETAIL c,STUDENT_PROFILE s,FINAL_RESULT f where c.COMPANYNAME=f.COMPANYNAME and s.STUDENTUSN=f.STUDENTUSN and s.STUDENTDEPT='" + DDLDeptWise.Text + "'";
        //        cmd.CommandType = CommandType.Text;
        //        // cmd.Parameters.Add(new SqlParameter("@Customer_Name", DDLCmpName.Text));
        //        //cmd.Parameters.Add(new SqlParameter("@Password", bUser.Password));
        //        cmd.Connection = Con;
        //        ds = new DataSet();
        //        adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(ds, "FINAL_RESULT");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //        if (Con.State != ConnectionState.Closed)
        //            Con.Close();
        //    }
        //    return ds;
        //}


        //public DataSet getAllOrdersYear()
        //{
        //    string sqlCon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=STUDENT_MANAGEMENT;Data Source=SYS2\\SQLEXPRESS";
        //    SqlConnection Con = new SqlConnection(sqlCon);
        //    SqlCommand cmd = new SqlCommand();
        //    DataSet ds = null;
        //    SqlDataAdapter adapter;
        //    try
        //    {
        //        Con.Open();
        //        cmd.CommandText = "select studentname,STUDENTCOURSE,year1 from COMPANY_DETAIL c,STUDENT_PROFILE s,FINAL_RESULT f where c.COMPANYNAME=f.COMPANYNAME and s.STUDENTUSN=f.STUDENTUSN and c.YEAR1='" + DDLYearWise.Text + "'";
        //        cmd.CommandType = CommandType.Text;
        //        // cmd.Parameters.Add(new SqlParameter("@Customer_Name", DDLCmpName.Text));
        //        cmd.Connection = Con;
        //        ds = new DataSet();
        //        adapter = new SqlDataAdapter(cmd);
        //        adapter.Fill(ds, "FINAL_RESULT");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //        if (Con.State != ConnectionState.Closed)
        //            Con.Close();
        //    }
        //    return ds;
        //}



        protected void DDLCmpSelCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DDLCmpSelCriteria.Text == "Department")
            //{
            //    this.DDLDeptWise.Visible = true;

            //    this.DDLCmpWise.Visible = false;
            //    this.DDLYearWise.Visible = false;
            //    String Dept_ID = DDLCmpSelCriteria.SelectedItem.Value.ToString();
            //    demo(Dept_ID);
            //}
            //else 
            if (DDLCmpSelCriteria.Text == "Company Name")
            {
                this.DDLCmpWise.Visible = true;

                this.DDLDeptWise.Visible = false;
                this.DDLYearWise.Visible = false;
                String Cmp_ID = DDLCmpSelCriteria.SelectedItem.Value.ToString();
                Cmp_Name(Cmp_ID);

            }
            //else if (DDLCmpSelCriteria.Text == "Year")
            //{
            //    this.DDLYearWise.Visible = true;

            //    this.DDLDeptWise.Visible = false;
            //    this.DDLCmpWise.Visible = false;
            //    String Year_ID = DDLCmpSelCriteria.SelectedItem.Value.ToString();
            //    Cmp_Name(Year_ID);

            //}
        }






        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }





        protected void DDLCmpWise_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ReportDocument rptDoc = new ReportDocument();
            //DataSet3 ds = new DataSet3();
            //ds = getAllOrders();
            //DataTable dt = new DataTable();
            //dt.TableName = "Crystal Report ";
            //dt = getAllOrders().Tables["Report"];
            //ds.Tables[0].Merge(dt);
            //rptDoc.Load(Server.MapPath("CrystalReport3.rpt"));
            //rptDoc.SetDataSource(ds);
            //CrystalReportViewer1.ReportSource = rptDoc;


            string con1 = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=spms;Data Source=SYS2\\SQLEXPRESS";
            SqlConnection connection = new SqlConnection(con1);
            SqlCommand command = new SqlCommand(" select m.collegename as 'CollegeName',m.collegeaddress as 'CollegeAddress',s.First_Name as 'First_Name', s.Department as 'Department' from Pool_Campus_College_Master m inner join Pool_Campus_Eligible_Students s on m.PoolCampusCollegeId=s.PoolCampusCollegeId  where m.CollegeName='" + DDLCmpWise.Text + "'");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet3 dataset = new DataSet3();
            adapter.Fill(dataset, "Report");
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Server.MapPath("CrystalReport3.rpt"));
            reportDocument.SetDataSource(dataset);
            CrystalReportViewer1.ReportSource = reportDocument;
        }

        //protected void DDLDeptWise_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ReportDocument rptDoc = new ReportDocument();
        //    DataSet3 ds = new DataSet3();
        //    DataTable dt = new DataTable();
        //    dt.TableName = "Crystal Report ";
        //    dt = getAllOrdersDept().Tables[0];
        //    ds.Tables[0].Merge(dt);
        //    rptDoc.Load(Server.MapPath("CrystalReport3.rpt"));
        //    rptDoc.SetDataSource(ds);
        //    CrystalReportViewer1.ReportSource = rptDoc;
        //}

        //protected void DDLYearWise_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ReportDocument rptDoc = new ReportDocument();
        //    DataSet3 ds = new DataSet3();
        //    DataTable dt = new DataTable();
        //    dt.TableName = "Crystal Report";
        //    dt = getAllOrdersYear().Tables[0];
        //    ds.Tables[0].Merge(dt);
        //    rptDoc.Load(Server.MapPath("CrystalReport3.rpt"));
        //    rptDoc.SetDataSource(ds);
        //    CrystalReportViewer1.ReportSource = rptDoc;
        //}




    }
}