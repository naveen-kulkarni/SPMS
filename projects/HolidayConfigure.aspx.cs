using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace Project
{
    public partial class HolidayConfigure : System.Web.UI.Page
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
            if (!IsPostBack)
                constructYearDropdown();
            if (ddlYear.SelectedItem.Text != "Select")
            {
                constructGridView(Int32.Parse(ddlYear.SelectedValue));
            }
            //else if ((string)Session["SelectedYear"] != null)
            //{
            //    constructGridView(Int32.Parse((string)Session["SelectedYear"]));
            //}



        }

        //To construct Years dropdown
        private void constructYearDropdown()
        {
            int currentYear = Int32.Parse(System.DateTime.Now.Year.ToString());
            DataTable dtYears = new DataTable();
            dtYears.Columns.Add("Year");

            dtYears.Rows.Add("Select");

            for (int i = currentYear - 1; i < (currentYear + 2); i++)
            {
                DataRow dr = dtYears.NewRow();
                dr["Year"] = i.ToString();
                dtYears.Rows.Add(dr);
            }

            ddlYear.DataSource = dtYears.DefaultView;
            ddlYear.DataTextField = dtYears.Columns["Year"].ToString();
            ddlYear.DataValueField = dtYears.Columns["Year"].ToString();
            ddlYear.DataBind();

            if ((string)Session["SelectedYear"] != null)
                ddlYear.SelectedValue = (string)Session["SelectedYear"];

        }


        //To get the Holiday List
        private DataSet getHolidayList(string selectedYear)
        {
            DataSet dsHolidayList = new DataSet();
            DBConnection obj = new DBConnection();
            try
            {
                SqlConnection dbConn = obj.GetDBConnection();
                dbConn.Open();
                string query = "";
                query = "select * from Holiday_Master where Is_Active = 1 and Datename(yyyy,HolidayDate) = '" + selectedYear + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, dbConn);
                adapter.Fill(dsHolidayList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dsHolidayList;
        }

        //Delete selected Holiday
        private void deleteHoliday(int HolidayId)
        {

            DBConnection obj = new DBConnection();
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                conn.Open(); //Open the database connection
                string query = "update Holiday_Master set Is_Active = 0, Updated_By = 1" +
                        " where HolidayId = " + HolidayId;
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



        //To construct Holiday list GridView
        private void constructHolidaylist(int selectedYear)
        {
            grdHolidayList.Visible = false;
            lblHolidayListHeading.Visible = false;
            DataSet dsHolidayList = new DataSet();
            dsHolidayList = getHolidayList(selectedYear.ToString());
            if (dsHolidayList.Tables[0].Rows.Count > 0)
            {
                grdHolidayList.DataSource = dsHolidayList;
                grdHolidayList.DataBind();
                grdHolidayList.Visible = true;
                lblHolidayListHeading.Visible = true;
            }
        }

        //To construct the Gridview..
        private void constructGridView(int selectedYear)
        {

            string dayOfWeek = "";
            string dates = string.Empty;

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };
            DataTable dtCalendar = new DataTable();
            for (int i = 100; i < 143; i++)
                dtCalendar.Columns.Add(i.ToString());


            for (int i = 0; i < months.Length; i++)
            {
                DataRow dr = dtCalendar.NewRow();
                dr["100"] = months[i];

                DateTime dt = new DateTime(selectedYear, i + 1, 1);
                dayOfWeek = dt.DayOfWeek.ToString();
                int startDate = GetStartDate(dayOfWeek);
                int columnValue = 0;
                int totalDaysCount = System.DateTime.DaysInMonth(selectedYear, i + 1);
                for (int loopStartingDate = startDate; loopStartingDate <= totalDaysCount + (startDate - 1); loopStartingDate++)
                {
                    columnValue++;
                    //dr[loopStartingDate] = columnValue.ToString() + "/" + (i + 1).ToString() + "/" + selectedYear.ToString();
                    DateTime dtDate = new DateTime(selectedYear, (i + 1), columnValue);
                    //dr[loopStartingDate] = columnValue.ToString() + "/" + (i + 1).ToString() + "/" + selectedYear.ToString();
                    dr[loopStartingDate] = dtDate;
                    //dr[loopStartingDate] = columnValue.ToString() + "/" + (i + 1).ToString() + "/" + selectedYear.ToString();
                    //string test = columnValue.ToString() + "/" + (i + 1).ToString() + "/" + selectedYear.ToString();
                    //dr[loopStartingDate] = Convert.ToDateTime(test);

                }



                dtCalendar.Rows.Add(dr);
            }

            grdHolidayCalendar.DataSource = dtCalendar.DefaultView;
            grdHolidayCalendar.DataBind();

            constructHolidaylist(selectedYear);
            tblColors.Visible = true;

        }


        //To get the 1st of the each month.
        private int GetStartDate(string dayOfWeek)
        {
            int startDate = 0;
            switch (dayOfWeek)
            {
                case "Sunday":
                    startDate = 1;
                    break;
                case "Monday":
                    startDate = 2;
                    break;
                case "Tuesday":
                    startDate = 3;
                    break;
                case "Wednesday":
                    startDate = 4;
                    break;
                case "Thursday":
                    startDate = 5;
                    break;
                case "Friday":
                    startDate = 6;
                    break;
                case "Saturday":
                    startDate = 7;
                    break;
            }
            return startDate;
        }

        protected void grdHolidayCalendar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string selectedYear = ddlYear.SelectedItem.Value.ToString();
            DataSet dsHolidayList = new DataSet();
            dsHolidayList = getHolidayList(selectedYear);


            //To name the Week days like Su,Mo and etc
            if (e.Row.Cells.Count > 0)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "100")
                    {
                        e.Row.Cells[i].Text = "Month";
                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#0E7EC7");
                        e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else if (e.Row.Cells[i].Text == "101" || e.Row.Cells[i].Text == "108" || e.Row.Cells[i].Text == "115" || e.Row.Cells[i].Text == "122" || e.Row.Cells[i].Text == "129" || e.Row.Cells[i].Text == "136")
                    {
                        e.Row.Cells[i].Text = "Su";
                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#0E7EC7");
                        e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else if (e.Row.Cells[i].Text == "102" || e.Row.Cells[i].Text == "109" || e.Row.Cells[i].Text == "116" || e.Row.Cells[i].Text == "123" || e.Row.Cells[i].Text == "130" || e.Row.Cells[i].Text == "137")
                    {
                        e.Row.Cells[i].Text = "Mo";
                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#0E7EC7");
                        e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else if (e.Row.Cells[i].Text == "103" || e.Row.Cells[i].Text == "110" || e.Row.Cells[i].Text == "117" || e.Row.Cells[i].Text == "124" || e.Row.Cells[i].Text == "131" || e.Row.Cells[i].Text == "138")
                    {
                        e.Row.Cells[i].Text = "Tu";
                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#0E7EC7");
                        e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else if (e.Row.Cells[i].Text == "104" || e.Row.Cells[i].Text == "111" || e.Row.Cells[i].Text == "118" || e.Row.Cells[i].Text == "125" || e.Row.Cells[i].Text == "132" || e.Row.Cells[i].Text == "139")
                    {
                        e.Row.Cells[i].Text = "We";
                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#0E7EC7");
                        e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else if (e.Row.Cells[i].Text == "105" || e.Row.Cells[i].Text == "112" || e.Row.Cells[i].Text == "119" || e.Row.Cells[i].Text == "126" || e.Row.Cells[i].Text == "133" || e.Row.Cells[i].Text == "140")
                    {
                        e.Row.Cells[i].Text = "Th";
                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#0E7EC7");
                        e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else if (e.Row.Cells[i].Text == "106" || e.Row.Cells[i].Text == "113" || e.Row.Cells[i].Text == "120" || e.Row.Cells[i].Text == "127" || e.Row.Cells[i].Text == "134" || e.Row.Cells[i].Text == "141")
                    {
                        e.Row.Cells[i].Text = "Fr";
                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#0E7EC7");
                        e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else if (e.Row.Cells[i].Text == "107" || e.Row.Cells[i].Text == "114" || e.Row.Cells[i].Text == "121" || e.Row.Cells[i].Text == "128" || e.Row.Cells[i].Text == "135" || e.Row.Cells[i].Text == "142")
                    {
                        e.Row.Cells[i].Text = "Sa";
                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#0E7EC7");
                        e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else
                    {
                        if (i != 0 && e.Row.Cells[i].Text.Replace("&nbsp;", "").Trim() != "")
                        {
                            string AllDate = DateTime.Parse(e.Row.Cells[i].Text).ToString("MM-dd-yyyy");
                            DateTime dtAllDate = DateTime.Parse(AllDate);
                            //DateTime dtAllDate = Convert.ToDateTime(e.Row.Cells[i].Text);
                            if (dtAllDate.DayOfWeek.ToString().Equals("Sunday"))
                                e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#FFE67E");


                            LinkButton lnkbtnAddDate = new LinkButton();
                            LinkButton lnkbtnEditDate = new LinkButton();

                            string[] initialDate = e.Row.Cells[i].Text.Split(' ');
                            string[] splittedValue = initialDate[0].Split('/');

                            lnkbtnAddDate.Text = splittedValue[1].ToString();
                            lnkbtnAddDate.Attributes.Add("onClick", "openPopupForAdd('" + splittedValue[1].ToString() + "','" + splittedValue[0].ToString() + "','" + splittedValue[2].ToString() + "');");
                            //lnkbtnAddDate.Attributes.Add("onClick", "test('" + splittedValue[0].ToString() + "');");

                            e.Row.Cells[i].Controls.Add(lnkbtnAddDate);


                            if (dsHolidayList.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < dsHolidayList.Tables[0].Rows.Count; j++)
                                {
                                    string strHoliday = DateTime.Parse(dsHolidayList.Tables[0].Rows[j]["HolidayDate"].ToString()).ToString("MM-dd-yyyy");
                                    DateTime dtHoliday = DateTime.Parse(strHoliday);// Convert.ToDateTime(dsHolidayList.Tables[0].Rows[j]["HolidayDate"].ToString());
                                    if (dtHoliday.ToShortDateString().Equals(dtAllDate.ToShortDateString()))
                                    {
                                        lnkbtnEditDate.Text = splittedValue[1].ToString();
                                        lnkbtnEditDate.ToolTip = dsHolidayList.Tables[0].Rows[j]["Holiday_Name"].ToString();
                                        e.Row.Cells[i].Controls.Remove(lnkbtnAddDate);
                                        e.Row.Cells[i].Controls.Add(lnkbtnEditDate);
                                        e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#6CE26C");
                                        lnkbtnEditDate.Attributes.Add("onclick", "openPopupForEdit('" + dsHolidayList.Tables[0].Rows[j]["HolidayId"].ToString() + "');return false;");
                                    }

                                }
                            }
                        }
                        else if (i == 0)
                        {
                            e.Row.Cells[i].BackColor = ColorTranslator.FromHtml("#9CAAC1");
                            e.Row.Cells[i].ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                        }

                    }

                }
            }

            //To name the Week days like Su,Mo and etc
        }
        protected void grdHolidayList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblHolidayDate = (Label)(e.Row.FindControl("lblHolidayDate"));
                DateTime dtHolidayDate = Convert.ToDateTime(lblHolidayDate.Text.ToString());
                (e.Row.FindControl("lblHolidayDate") as Label).Text = dtHolidayDate.ToShortDateString();

            }



        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlYear.SelectedItem.Value.Equals("Select"))
            {
                int selectedYear = Int32.Parse(ddlYear.SelectedItem.Value.ToString());
                constructGridView(selectedYear);
                Session["SelectedYear"] = ddlYear.SelectedValue.ToString();
            }

        }

        protected void lnkbtnDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtnDelete = (LinkButton)sender;
            int HolidayId = Int32.Parse(lnkbtnDelete.CommandArgument.ToString());
            deleteHoliday(HolidayId);
            if (!ddlYear.SelectedItem.Value.Equals("Select"))
            {
                int selectedYear = Int32.Parse(ddlYear.SelectedItem.Value.ToString());
                constructGridView(selectedYear);
                Session["SelectedYear"] = ddlYear.SelectedValue.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }


    }
}
