<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company_List.aspx.cs" Inherits="Final_Crystal_Reports.Company_List" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
    <asp:Label ID="Label2" runat="server" Text="COMPANY DETAILS" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
    <table>
    <tr>
   <td>
   <asp:DropDownList ID="DDLCmpSelCriteria" runat="server" 
           onselectedindexchanged="DDLCmpSelCriteria_SelectedIndexChanged" 
           AutoPostBack="True"  CssClass="dropdownbox">
        <asp:ListItem>select</asp:ListItem>
        <asp:ListItem>Company Name</asp:ListItem>
        <asp:ListItem>Department</asp:ListItem>
        <asp:ListItem>Year</asp:ListItem>
    </asp:DropDownList>
 
    <asp:DropDownList ID="DDLDeptWise" runat="server"   
          Visible="False" AutoPostBack="True" 
           onselectedindexchanged="DDLDeptWise_SelectedIndexChanged" CssClass="dropdownbox">
    </asp:DropDownList>
       <asp:DropDownList ID="DDLCmpWise" runat="server" AutoPostBack="True" 
           onselectedindexchanged="DDLCmpWise_SelectedIndexChanged" CssClass="dropdownbox">
       </asp:DropDownList>
       <asp:DropDownList ID="DDLYearWise" runat="server" AutoPostBack="True" 
           onselectedindexchanged="DDLYearWise_SelectedIndexChanged" CssClass="dropdownbox">
       </asp:DropDownList>
       <asp:Button ID="BtnHome" runat="server" onclick="BtnHome_Click" Text="Home" CssClass="buttonsimg" />
 
       <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
           Text="Export To Excel" CssClass="buttonsimg" />
 
 </td>
 
  
     
     
    
  </tr>  </table>
  </fieldset> 
  
   
      <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
   
    </asp:Content>