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
    public partial class EditHolidayPopup : System.Web.UI.Page
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
            int HolidayId = Int32.Parse(Request.QueryString["HolidayId"].ToString());
            if (!IsPostBack)
                showHolidayDetails(HolidayId);


        }

        //To show the Holiday Details for passed HolidayId
        private void showHolidayDetails(int HolidayId)
        {
            DataSet dsSelectedHolidayDetails = new DataSet();
            dsSelectedHolidayDetails = getSelectedHolidayDetails(HolidayId);
            DataRow dr = dsSelectedHolidayDetails.Tables[0].Rows[0];

            DateTime dtHolidayDate = Convert.ToDateTime(dr["HolidayDate"].ToString());
            lblDate.Text = dtHolidayDate.ToShortDateString();
            txtHolidayName.Text = dr["Holiday_Name"].ToString();
            txtDescription.Text = dr["Description"].ToString();
            hdnHolidayId.Value = dr["HolidayId"].ToString();


        }

        //Select Holiday Details for passed HolidayId
        private DataSet getSelectedHolidayDetails(int HolidayId)
        {
            DataSet dsSelectedHolidayDetails = new DataSet();
            DBConnection obj = new DBConnection();
            try
            {
                SqlConnection dbConn = obj.GetDBConnection();
                dbConn.Open();
                string query = "";
                query = "select * from Holiday_Master where Is_Active = 1 and HolidayId  = " + HolidayId;
                SqlDataAdapter adapter = new SqlDataAdapter(query, dbConn);
                adapter.Fill(dsSelectedHolidayDetails);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dsSelectedHolidayDetails;
        }

        //To update the the changed Holiday details for passed HolidayId
        private void UpdateHoliday(int HolidayId, string HolidayName, string HolidayDate, string Description)
        {
            SqlConnection conn = obj.GetDBConnection();
            try
            {
                DateTime dtHolidayDate = new DateTime();
                dtHolidayDate = Convert.ToDateTime(HolidayDate);
                conn.Open(); //Open the database connection
                query = "update Holiday_Master set Holiday_Name = '" + HolidayName + "', Description = '" + Description + "', Updated_By = 1" +
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string HolidayName = txtHolidayName.Text;
            string HolidayDate = lblDate.Text;
            string Description = txtDescription.Text;
            int HolidayId = Int32.Parse(hdnHolidayId.Value.ToString());
            UpdateHoliday(HolidayId, HolidayName, HolidayDate, Description);

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