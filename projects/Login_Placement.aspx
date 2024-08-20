<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login_Placement.aspx.cs" Inherits="Project.Login_Placement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset><legend>Login</legend>
    
            
            
<table cellpadding="3px" cellspacing="3px">
 <tr>
        <td colspan="3" align="center">
            <asp:Label ID="Lbl_msg" runat="server" Text="Label" Visible="False" CssClass="ReportMsg"></asp:Label>
        </td>
        
    </tr>
   <tr>
        <td align="right">
            <asp:Label ID="Lbl_User" runat="server" Text="Login Type :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDown_Login_Id" runat="server">
            <asp:ListItem>Super Admin</asp:ListItem>
            <asp:ListItem>Admin</asp:ListItem>
            <asp:ListItem>Professors</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
        
    <tr>
        
        <td align="right">
            <asp:Label ID="Lbl_User_name" runat="server" Text="User Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Name_TextBox" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>        
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_pwd" runat="server" Text="Password :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox_pwd" TextMode="Password" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
        
    </tr>
    <tr>
        
        <td  colspan="2">
            
            <asp:Button ID="Button_Login" runat="server" Text="Login" CssClass="buttonsimg" 
                onclick="Button_Login_Click"/>
        
           
             <asp:Button ID="Button1" runat="server" Text="change Password" CssClass="buttonsimg"  
                onclick="Button1_Click"/>
            
        </td>
    </tr>
    
     
</table><p>Click Here to
<a href="Student_Registration_Form.aspx"><asp:Label ID="Lbl_Register" runat="server" Text="student Register"></asp:Label></a></p>
<p>Click Here to
<a href="Register_Login.aspx"><asp:Label ID="Label1" runat="server" Text="Professor Register"></asp:Label></a></p>


</fieldset>
</asp:Content>
