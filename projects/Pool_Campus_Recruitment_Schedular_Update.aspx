<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_Recruitment_Schedular_Update.aspx.cs" Inherits="Final_Report_SMPS.Pool_Campus_Recruitment_Schedular_Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 4px;
        }
    </style>
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

  <asp:Label ID="Label2" runat="server" Text="COMPANY SCHEDULAR" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
 <table> 
    
       <tr> <td>
            <asp:Label ID="LblCollName" runat="server" Text="Company Name" CssClass="lablewidth"></asp:Label>  
        </td>
        <td class="style1">
            <asp:DropDownList ID="DDLCompanyName" runat="server" 
                onselectedindexchanged="DDLCompanyName_SelectedIndexChanged" 
                AutoPostBack="True" CssClass="dropdownbox">
            </asp:DropDownList>
             
         </td></tr>
            <tr>
<td>
    <asp:Label ID="LblTestDate" runat="server" Text="Test Date" CssClass="lablewidth"></asp:Label>
     
               
</td>
<td>
    <asp:TextBox ID="TxtTestDate" runat="server" CssClass="Textwidth"></asp:TextBox>
    <asp:RequiredFieldValidator ID="TestDateValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Test Date" ControlToValidate="TxtTestDate" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="LblTestStatus" runat="server" Text="Test Status" CssClass="lablewidth"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TxtTestStatus" runat="server" CssClass="Textwidth"></asp:TextBox>
    <asp:RequiredFieldValidator ID="TestStatusValidator" runat="server" Text="**" 
                ErrorMessage="plz enter a Test Status" ControlToValidate="TxtTestStatus" 
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
</td>
</tr>

        
  <tr>   
 <td>   
    <asp:Label ID="LblErrorMsg" runat="server" CssClass="lablewidth"> </asp:Label>
</td>
</tr>
      
</table>
    <table>
<tr>
<td>
         <asp:Button ID="BtnUpdate" runat="server"   Text="Update" 
        ValidationGroup="ud" onclick="BtnUpdate_Click"  CssClass="buttonsimg"/>
      <asp:Button ID="BtnBack" runat="server" onclick="BtnBack_Click" Text="Back" 
        ValidationGroup="bk" CssClass="buttonsimg" />
    <asp:Button ID="BtnHome" runat="server" onclick="BtnHome_Click" Text="Home" 
        ValidationGroup="hm" CssClass="buttonsimg" />
    <br />
    <asp:GridView ID="GrdStudent_Det" runat="server" CssClass="grdvew">
    </asp:GridView>
    
    </td>
</tr>
</table>
<asp:ValidationSummary ID="vsControl" runat="server" ShowMessageBox="true" 
        DisplayMode="BulletList" HeaderText="Plz Correct These Errors" 
        ForeColor="Red" />
</asp:Content>
