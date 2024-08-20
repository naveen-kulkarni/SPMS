using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Project
{
    public partial class AddHolidayPopup : System.Web.UI.Page
    {
        DBConnection obj = new DBConnection();
        Calendar calenderObj = new Calendar();
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
            string HolidayDate = (string)Request.QueryString["HolidayDate"];
            lblDate.Text = HolidayDate;
        }

        private void AddHoliday(string HolidayName, string HolidayDate, string Description)
        {
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                DateTime dtHolidayDate = new DateTime();
                dtHolidayDate = Convert.ToDateTime(HolidayDate);
                conn.Open(); //Open the database connection
                query = "insert into Holiday_Master(Holiday_Name, HolidayDate, Description, Updated_By)" +
                                " values('" + HolidayName + "','" + dtHolidayDate.ToString("MM-dd-yyyy") + "','" + Description + "','1')";
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string HolidayName = txtHolidayName.Text;
            string HolidayDate = lblDate.Text;
            string Description = txtDescription.Text;
            AddHoliday(HolidayName, HolidayDate, Description);

            //btnAdd.Attributes.Add("onBlur", "proceed();");
            Response.Write("<script language=javascript>opener.location.reload(true); self.close();</script>");



        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login_Placement.aspx");
        }
    }
}