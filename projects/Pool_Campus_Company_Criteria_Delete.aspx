<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_Company_Criteria_Delete.aspx.cs" Inherits="Final_Report_SMPS.Pool_Campus_Company_Criteria_Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
             <td align="right">
                <asp:Button ID="Button2" runat="server" Text="LogOut" onclick="Button2_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" ReadOnly="true" CssClass="commonTxtbox" BorderStyle="None" ></asp:TextBox>            
            </td> 
        </tr>
     </table>
   <asp:Label ID="Label2" runat="server" Text="COLLEGE COMPANY CRITERIA" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
    <table>
    <tr>
    <td>
        <asp:Label ID="LblCompanyName" runat="server" Text="Select Company Name" CssClass="lablewidth"></asp:Label>
    <asp:DropDownList ID="DDLCompanyName" runat="server" CssClass="dropdownbox">
    </asp:DropDownList>
    <asp:Button ID="BtnDelete" runat="server"  Text="Delete" 
              onclick="BtnDelete_Click" CssClass="buttonsimg" />
    <asp:Button ID="BtnBack" runat="server" onclick="BtnBack_Click" Text="Back"  CssClass="buttonsimg"/>
    
    </td></tr>
     
      
    <asp:GridView ID="GrdStudent_Det" runat="server" CssClass="grdvew">
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" CssClass="lablewidth"></asp:Label>
    
    </table>
</asp:Content>
