using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Report_SMPS
{
    public partial class Home_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Student_Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Students_Detail.aspx");
        }

        protected void College_Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Other_College_Detail.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Schedule_Pool_Campus_Test.aspx");
        }

        protected void BtnPCCM_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_College_Master.aspx");
        }

        protected void BtnPCCC_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Company_Config.aspx");
        }

        protected void BtnPCCPC_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Company_Placement_Criteria.aspx");
        }

        protected void BtnPCES_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Eligible_Student.aspx");
        }

        protected void BtnPCRMPM_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Plan_Master.aspx");
        }

        protected void BtnPCRS_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Schedular.aspx");
        }

        protected void BtnPCRTR_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pool_Campus_Recruitment_Test_Result.aspx");
        }
    }
}