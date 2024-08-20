using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;

namespace Project
{
    public class Common
    {

        #region "User defined Methods"

        System.Diagnostics.StackTrace trace;

        #endregion

        #region"SendMail"

        public void SendMail(string pstrToMail, string pstrSubject, string pstrMailBody, string pstrFromMail, string pstrFromPassword)
        {
            try
            {
                MailMessage objMailMessage = new MailMessage();
                MailAddress objMail_toaddress = new MailAddress(pstrToMail.ToString());

                MailAddress objMail_fromaddress = new MailAddress(ConfigurationManager.AppSettings[pstrFromMail].ToString());
                objMailMessage.To.Add(objMail_toaddress);
                objMailMessage.From = objMail_fromaddress;
                objMailMessage.Subject = pstrSubject.ToString();

                // CC and BCC optional
                MailAddress objMail_CC1 = new MailAddress(ConfigurationManager.AppSettings[pstrFromMail].ToString());
                objMailMessage.CC.Add(objMail_CC1);


                objMailMessage.Body = pstrMailBody.ToString();
                objMailMessage.Priority = MailPriority.Normal;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.BodyEncoding = System.Text.Encoding.Default;


                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Port = 587;
                mSmtpClient.Host = ConfigurationManager.AppSettings["SmtpServerName"].ToString();
                System.Net.NetworkCredential nc = new NetworkCredential(ConfigurationManager.AppSettings[pstrFromMail].ToString(), ConfigurationManager.AppSettings[pstrFromPassword].ToString());
                mSmtpClient.Credentials = nc;
                mSmtpClient.EnableSsl = true;


                mSmtpClient.Send(objMailMessage);
            }
            catch (SmtpException )
            {
                trace = new System.Diagnostics.StackTrace(true);

            }
        }
        #endregion #endregion
    }
}


        
