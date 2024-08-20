<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Super_Admin_Form.aspx.cs" Inherits="Project.Super_Admin_Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
           <td align="right">
                <asp:Button ID="Button1" runat="server" Text="LogOut" onclick="Button1_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td>     
        </tr>
     </table>

<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>           
            
        <td>
<div class="clear hideSkiplink">
        <asp:Menu ID="NavigationMenu" CssClass="submenutype" runat="server" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal" >
            <Items>
                <asp:MenuItem Text="Master Data">
                <asp:MenuItem NavigateUrl="~/AddDepartment.aspx" Text="Add Department"/>
                <asp:MenuItem NavigateUrl="~/HolidayConfigure.aspx" Text="Add Holiday"/>
                    <asp:MenuItem NavigateUrl="~/AddCourse.aspx" Text="Add Course"/>
                    <asp:MenuItem NavigateUrl="~/Subject.aspx" Text="Add Subject"/>
                    </asp:MenuItem>

                <asp:MenuItem Text="Student Profile"> 
                <asp:MenuItem NavigateUrl="~/Student_Registration_Form.aspx" Text="Add Student"/>               
                </asp:MenuItem>
                <asp:MenuItem Text="Company Profile">
                <asp:MenuItem NavigateUrl="~/companyprofile.aspx" Text="Company Details"/>
                <asp:MenuItem NavigateUrl="~/Company_Eligibility_Criteria.aspx" Text="Selection Criteria"/>
                <asp:MenuItem NavigateUrl="~/company_Recruitment_Process.aspx" Text="Recruitment Plan Details"/>
                <asp:MenuItem NavigateUrl="~/CompanyChart.aspx" Text="History"/>                
                </asp:MenuItem>               

                <asp:MenuItem Text="Placement Department">
                <asp:MenuItem NavigateUrl="~/Test_Schedule.aspx" Text="Shedule Written Test"/>
                <asp:MenuItem NavigateUrl="~/Enter Written Test Result.aspx" Text="Entry For Written Test"/>
                <asp:MenuItem NavigateUrl="~/Nxt_Round_Intimation.aspx" Text="Next Round Intimation"/>
                <asp:MenuItem NavigateUrl="~/Scd_gd_round.aspx" Text="Schedule GD Round"/>
                <asp:MenuItem NavigateUrl="~/Ent_gd_rnd_Result.aspx" Text="Enter GD Round Result"/>
                <asp:MenuItem NavigateUrl="~/Schd_Fnl_HR_rnd.aspx" Text="Schedule Final HR Round"/>
                <asp:MenuItem NavigateUrl="~/Ent_Fnl_Seltd_Std.aspx" Text="Enter Final Selected Students"/>
                </asp:MenuItem>
                <asp:MenuItem Text="Pool Campus"> 
                <asp:MenuItem NavigateUrl="~/Pool_Campus_College_Master.aspx" Text="Others College Details"/>               
                <asp:MenuItem NavigateUrl="~/Pool_Campus_Eligible_Student.aspx" Text="Others College Student Details"/>               
                </asp:MenuItem>
            </Items>
        </asp:Menu>
 </div>
 </td>

        </tr>
     </table>
 <fieldset><legend>Super Admin Loged In</legend>
  <center >
     <table>
       <tr>
         <td>
             <asp:Button ID="btnclgmaster" BorderStyle="None" CssClass="buttonsimg" Font-Size ="Large" 
                 Font-Underline="true" runat="server" text = "College Master" 
                 onclick="btnclgmaster_Click"/>
         </td>
         <td>
            <asp:Button ID="btnrole" BorderStyle="None" CssClass="buttonsimg" Font-Size ="Large" 
             Font-Underline="true" runat="server" text = "Role Master" 
                 onclick="btnrole_Click"/>
         </td>
        <td>
             <asp:Button ID="btnuser" BorderStyle="None" CssClass="buttonsimg" Font-Size ="Large" 
             Font-Underline="true" runat="server" text = "User Master" 
                 onclick="btnuser_Click"/>
        </td>        
       </tr>
    </table>
   


    <asp:Panel ID="Panel1" runat="server" Visible="False">
    <fieldset><legend >College Master</legend>
    <table cellpadding="3px" cellspacing="3px">
        <tr>
            <td align="right">
                <asp:Label ID="Lbl_clgname" runat="server" Text="College Name :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align ="left" >
                <asp:TextBox ID="Txt_ClgName" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
            <td valign="top" rowspan="7">
                <asp:GridView ID="Grd_College" runat="server">
                </asp:GridView>
            </td>
            
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_lgn" runat="server" Text="College Login ID :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align ="left" >
                <asp:TextBox ID="txt_lgn" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_pwd" runat="server" Text="College Password :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align ="left" >
                <asp:TextBox ID="txt_pwd" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_lgntype" runat="server" Text="Login Type :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align ="left" >
                <asp:DropDownList ID="dl_lgntype" cssclass="dropdownbox" runat="server">
                    <asp:ListItem>Admin</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td align="right">
                <asp:Label ID="Lbl_Clg_Address" runat="server" Text="College Address :" CssClass="lablewidth"></asp:Label>
            </td>
        <td align ="left">
             <asp:TextBox ID="Txt_Clg_Address" runat="server" CssClass="commonTxtbox" 
                 TextMode="MultiLine"></asp:TextBox>
        </td>
     </tr>
        <tr>
            <td align="right">
               <asp:Label ID="Lbl_Phone" runat="server" Text="Contact Number :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align ="left">
                <asp:TextBox ID="Txt_Phone" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
        </tr>
        
           <tr>
        <td align="right">
             <asp:Label ID="Lbl_Website" runat="server" Text="College Website :" CssClass="lablewidth"></asp:Label>
        </td>
        <td align ="left">
             <asp:TextBox ID="Txt__Website" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
     </tr>

     <tr>
        <td align="right">
             <asp:Label ID="Lbl_Description" runat="server" Text="College Description :" CssClass="lablewidth"></asp:Label>
        </td>
        <td align ="left">
             <asp:TextBox ID="Txt_Description" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
     </tr>
    
    
    <tr>

        <td colspan="2">
            <asp:Button ID="Btn_Add" runat="server" CssClass="buttonsimg"  onclick="Btn_Add_Click" 
                 Text="Add College" />
        
            <asp:Button ID="Btn_Delete" runat="server" CssClass="buttonsimg" onclick="Btn_Delete_Click" 
                Text="Delete College" />
       
            <asp:Button ID="Btn_Search" runat="server" CssClass="buttonsimg" onclick="Btn_Search_Click" 
                Text="Search College" />
        
        <asp:Button ID="Btn_View" runat="server" CssClass="buttonsimg" 
                Text="View ALL" onclick="Btn_View_Click" />
        </td>
        </tr>
  </table>
  </fieldset>
 </asp:Panel>





         <asp:Panel ID="Panel2" runat="server" Visible="False">
         <fieldset >
     <legend >Role Master</legend>
     <table cellpadding="3px" cellspacing="3px">
        <tr>
            <td align="right">
                <asp:Label ID="Lbl_role" runat="server" Text="Role Name :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align ="left">
                <asp:TextBox ID="Txt_role" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
            <td valign="top" rowspan="7">
                <asp:GridView ID="Grd_Role" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
               <asp:Label ID="Lbl_role_Description" runat="server" Text="Role Description :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align ="left">
                <asp:TextBox ID="Txt_role_Description" runat="server" CssClass="commonTxtbox" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
       
    
     <tr>
        <td colspan="2">
             <asp:Button ID="Btn_Add_Role" runat="server" CssClass="buttonsimg" Text="Add Role" 
                 onclick="Btn_Add_Role_Click"  />
      
             <asp:Button ID="Btn_Delete_Role" runat="server" CssClass="buttonsimg" 
                 Text="Delete Role" onclick="Btn_Delete_Role_Click" />
       
             <asp:Button ID="Btn_Search_Role" runat="server" CssClass="buttonsimg" 
                 Text="Search Role" onclick="Btn_Search_Role_Click" />
        
        <asp:Button ID="Btn_role_View" runat="server" CssClass="buttonsimg" 
                Text="View ALL" onclick="Btn_role_View_Click" />
        </td>
    </tr>
  </table>
      </fieldset>
         </asp:Panel>



         
         <asp:Panel ID="Panel3" runat="server" Visible="False">
         <fieldset >
     <legend >User Master</legend>
     
     <table cellpadding="3px" cellspacing="3px">
     <tr>
     <td colspan="4">
         <asp:Label ID="lblErrMsg" runat="server" Text="Label"></asp:Label>
     </td>
     </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Lbl_User_Name" runat="server" Text="User Name :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="Txt_User_Name" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
             <td valign="top" rowspan="7">
                <asp:GridView ID="Grd_User" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
               <asp:Label ID="Lbl_User_Password" runat="server" Text="User Password :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="Txt_User_Password" runat="server" CssClass="commonTxtbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Lbl_User_role_ID" runat="server" Text="Role Name :" CssClass="lablewidth"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="Dd_Role" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Lbl_USer_College_ID" runat="server" Text="College Name :" CssClass="lablewidth"></asp:Label>
            </td>
        <td align="left">
             <asp:DropDownList ID="Dd_CollegId" runat="server">
             </asp:DropDownList>
        </td>
     </tr>
     <tr>
        <td align="right">
             <asp:Label ID="Lbl_User_Description" runat="server" Text="Description :" CssClass="lablewidth"></asp:Label>
        </td>
        <td align="left">
             <asp:TextBox ID="Txt__User_Description" runat="server" CssClass="tablewidth " TextMode="MultiLine"></asp:TextBox>
        </td>
     </tr>
     
    
      <tr>
        <td colspan="2">
             <asp:Button ID="Btn_Add_User" runat="server" CssClass="buttonsimg" Text="Add User" 
                 onclick="Btn_Add_User_Click" />
             <asp:Button ID="Btn_Delete_User" runat="server" CssClass="buttonsimg" 
                 Text="Delete User" onclick="Btn_Delete_User_Click" />
             <asp:Button ID="Btn_search_User" runat="server" CssClass="buttonsimg" 
                 Text="Search User" onclick="Btn_search_User_Click" />
        <asp:Button ID="Btn_user_view" runat="server" CssClass="buttonsimg" 
                Text="View ALL" onclick="Btn_user_view_Click" />
        </td>
    </tr>
  </table>
      </fieldset>
         </asp:Panel>


     
       
     
     </center>
    
     </fieldset>
</asp:Content>
