<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test_Schedule.aspx.cs" Inherits="Final_Crystal_Reports.Test_Schedule" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <table>
    
   <td>
   <asp:DropDownList ID="DDLCmpSelCriteria" runat="server" AutoPostBack="True" onselectedindexchanged="DDLCmpSelCriteria_SelectedIndexChanged1" 
         >
        <asp:ListItem>select</asp:ListItem>
        <asp:ListItem>Company Name</asp:ListItem>
        <asp:ListItem>Department</asp:ListItem>
        <asp:ListItem>date</asp:ListItem>
    </asp:DropDownList>
 
 
    <asp:DropDownList ID="DDLCmpName" runat="server" 
          
        Visible="False">
    </asp:DropDownList>
    
    
    <asp:DropDownList ID="DDLDeptName" runat="server" 
         Visible="False">
    </asp:DropDownList>
 </td>
    
    <td>
    <asp:Button ID="Show" runat="server" Text="Show" onclick="Show_Click" />
        <asp:Button ID="BtnShowDept" runat="server" Text="Show" 
            onclick="BtnShowDept_Click" />
    </td>
    <tr>
    <td>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </td>
    </tr>
    </table>
    <asp:Button ID="BtnHome" runat="server" onclick="BtnHome_Click" Text="Home" />
    </asp:Content>