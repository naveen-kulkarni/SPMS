<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Selected_Students.aspx.cs" Inherits="Final_Crystal_Reports.Eligible_Students" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
<table>
 <tr>
   <td>
   <asp:DropDownList ID="DDLCmpSelCriteria" runat="server" 
           onselectedindexchanged="DDLCmpSelCriteria_SelectedIndexChanged" 
           AutoPostBack="True"  >
        <asp:ListItem>select</asp:ListItem>
        <asp:ListItem>Company Name</asp:ListItem>
        <asp:ListItem>Department</asp:ListItem>
        <asp:ListItem>Year</asp:ListItem>
    </asp:DropDownList>
 
 </td>
 
 <td>    <asp:DropDownList ID="DDLCmpWise" runat="server"  
        Visible="False" AutoPostBack="True" 
         onselectedindexchanged="DDLCmpWise_SelectedIndexChanged">
    </asp:DropDownList>
    </td>

    <td>
    <asp:DropDownList ID="DDLDeptWise" runat="server"   
          Visible="False" AutoPostBack="True" >
    </asp:DropDownList>
 </td>
     <td>
    <asp:DropDownList ID="DDLYearWise" runat="server"   
          Visible="False" AutoPostBack="True" >
             
    </asp:DropDownList>
 </td>
    <td>
    <asp:Button ID="BtnHome" runat="server" onclick="BtnHome_Click" Text="Home" />
    <br />
    </td>
  </tr>   
   
   
    </table></fieldset>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </asp:Content>
