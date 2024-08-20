<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="change_Pwd_Placement.aspx.cs" Inherits="Project.change_Pwd_Place_ement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<fieldset><legend>Change Password</legend>
<table cellpadding="3px" cellspacing="3px">
    <tr>
        <td>
            <asp:Label ID="lblErrMsg" runat="server" CssClass="ReportMsg" Text="Label"></asp:Label>
        </td>
    
    </tr>
    <tr>
        
        <td align="right">
            <asp:Label ID="Lbl_User" runat="server" Text="Login Type :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDown_Login_Id" runat="server">
            <asp:ListItem>Super Admin</asp:ListItem>
            <asp:ListItem>College Admin</asp:ListItem>
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
            <asp:Label ID="Lbl_Old_pwd" runat="server" Text="Old Password :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="old_pwd_TextBox" TextMode="Password" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_pwd" runat="server" Text="New Password :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox_new_pwd" TextMode="Password" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_conf_pwd" runat="server" Text="Confirm Password :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox_conf_pwd" TextMode="Password" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
     
    <tr>
        <td align="right" colspan="2">
            <asp:Button ID="Button_Login" runat="server" Text="OK" 
                onclick="Button_Login_Click"/>
        </td>
        
    </tr>
</table>



</fieldset>

</asp:Content>
