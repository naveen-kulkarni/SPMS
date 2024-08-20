using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



namespace Project
{
    public partial class change_Pwd_Place_ement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button_Login_Click(object sender, EventArgs e)
        {
            if (TextBox_new_pwd.Text == TextBox_conf_pwd.Text)
            {
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand Updatecmd = new SqlCommand("update Student_Config set Password=@Password1 where USN=@USN  and Password=@Password and LoginType=@LoginType", conn);
                Updatecmd.CommandType = CommandType.Text;
                Updatecmd.Parameters.AddWithValue("@LoginType", SqlDbType.VarChar).Value = DropDown_Login_Id.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@USN", SqlDbType.VarChar).Value = Name_TextBox.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = old_pwd_TextBox.Text.Trim();
                //Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = TextBox_new_pwd.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@Password1", SqlDbType.VarChar).Value = TextBox_conf_pwd.Text.Trim();
                Updatecmd.Connection = conn;
                conn.Open();
                int a = Updatecmd.ExecuteNonQuery();

                Name_TextBox.Text = "";
                old_pwd_TextBox.Text = "";
                TextBox_new_pwd.Text = "";
                TextBox_conf_pwd.Text = "";

                try
                {

                    if (a == 1)
                    {
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = "saved successfully";
                    }
                    else
                    {
                        lblErrMsg.Text = "could not be saved";
                    }
                }
                catch (Exception)
                {
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "connection could not opened";
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (TextBox_new_pwd.Text == TextBox_conf_pwd.Text)
            {
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand Updatecmd = new SqlCommand("update Register_Table set Password=@Password1 where User_Name=@User_Name  and Password=@Password and LoginType=@LoginType", conn);
                Updatecmd.CommandType = CommandType.Text;
                Updatecmd.Parameters.AddWithValue("@LoginType", SqlDbType.VarChar).Value = DropDown_Login_Id.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@User_Name", SqlDbType.VarChar).Value = Name_TextBox.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = old_pwd_TextBox.Text.Trim();
                //Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = TextBox_new_pwd.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@Password1", SqlDbType.VarChar).Value = TextBox_conf_pwd.Text.Trim();
                Updatecmd.Connection = conn;
                conn.Open();
                int a = Updatecmd.ExecuteNonQuery();

                Name_TextBox.Text = "";
                old_pwd_TextBox.Text = "";
                TextBox_new_pwd.Text = "";
                TextBox_conf_pwd.Text = "";

                try
                {

                    if (a == 1)
                    {
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = "saved successfully";
                    }
                    else
                    {
                        lblErrMsg.Text = "could not be saved";
                    }
                }
                catch (Exception)
                {
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "connection could not opened";
                }
                finally
                {
                    conn.Close();
                }
            }

            else if (TextBox_new_pwd.Text == TextBox_conf_pwd.Text)
            {
                string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SPMS;Data Source=SHREEMONI-PC\\SQLEXPRESS";
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand Updatecmd = new SqlCommand("update College_Master set Password=@Password1 where Login_ID=@Login_ID  and Password=@Password and Login_Type=@Login_Type", conn);
                Updatecmd.CommandType = CommandType.Text;
                Updatecmd.Parameters.AddWithValue("@LoginType", SqlDbType.VarChar).Value = DropDown_Login_Id.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@Login_ID", SqlDbType.VarChar).Value = Name_TextBox.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = old_pwd_TextBox.Text.Trim();
                //Updatecmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = TextBox_new_pwd.Text.Trim();
                Updatecmd.Parameters.AddWithValue("@Password1", SqlDbType.VarChar).Value = TextBox_conf_pwd.Text.Trim();
                Updatecmd.Connection = conn;
                conn.Open();
                int a = Updatecmd.ExecuteNonQuery();

                Name_TextBox.Text = "";
                old_pwd_TextBox.Text = "";
                TextBox_new_pwd.Text = "";
                TextBox_conf_pwd.Text = "";

                try
                {

                    if (a == 1)
                    {
                        lblErrMsg.Visible = true;
                        lblErrMsg.Text = "saved successfully";
                    }
                    else
                    {
                        lblErrMsg.Text = "could not be saved";
                    }
                }
                catch (Exception)
                {
                    lblErrMsg.Visible = true;
                    lblErrMsg.Text = "connection could not opened";
                }
                finally
                {
                    conn.Close();
                }
            }

           
            else
            {
                lblErrMsg.Text = "mismatch new password and confirm password";
            }
        }

        protected void DropDown_Login_Id_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}

        