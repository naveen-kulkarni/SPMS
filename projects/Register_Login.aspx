<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register_Login.aspx.cs" Inherits="Project.Register_Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<fieldset><legend>Register</legend>
<legend>Teacher Registration Form </legend>
<table cellpadding="3px" cellspacing="3px">
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_LoginType" runat="server" Text="Login Type :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDown_Login_Type" runat="server">
            <asp:ListItem>Professors</asp:ListItem>
            <asp:ListItem>Super Admin</asp:ListItem>            
            </asp:DropDownList>
        </td>
    </tr> 
<tr>
        <td align="right">
            <asp:Label ID="Lbl_User" runat="server" Text="User Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_User" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right">
            <asp:Label ID="Lbl_Pwd" runat="server" Text="Password :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_Pwd" TextMode="Password" runat="server" CssClass="commonTxtbox"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_clgname" runat="server" Text="College Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="Lbl_branch" runat="server" Text="Branch Name :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_mail" runat="server" Text="E-mail :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_mail" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Lbl_phone" runat="server" Text="Contact No :" CssClass="lablewidth"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Txt_phone" runat="server" CssClass="commonTxtbox"></asp:TextBox>&nbsp;
        </td>
    </tr>
    <tr>
    <td align ="right" >
        <asp:Button ID="Button1" runat="server" Text="Save" CssClass="buttonsimg" onclick="Button1_Click" />
    </td>
    </tr>
</table>

</fieldset></asp:Content>
