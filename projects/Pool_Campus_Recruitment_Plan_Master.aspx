<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pool_Campus_Recruitment_Plan_Master.aspx.cs" Inherits="Final_Report_SMPS.Pool_Campus_Recruitment_Plan_Master" %>
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
<asp:Label ID="Label2" runat="server" Text="COMPANY MASTER" 
        Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Black"></asp:Label>
 <table>
 
<tr>
<td>
    <asp:Label ID="LblCmpName" runat="server" Text="Company Name" CssClass="lablewidth"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="DDLCmpName" runat="server" CssClass="dropdownbox">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="LblTestType" runat="server" Text="Test Type" CssClass="lablewidth"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="DDLTestType" runat="server" CssClass="dropdownbox">
    </asp:DropDownList>
</td>
</tr>
  
</table>
 <table>
<tr>
<td>
    <asp:Button ID="BtnAdd" runat="server" Text="Add" onclick="BtnAdd_Click" CssClass="buttonsimg"/>
    
    
    <asp:Button ID="BtnShowAll" runat="server"  
        Text="ShowAll" ValidationGroup="sa" onclick="BtnShowAll_Click" CssClass="buttonsimg" />
       <asp:Button ID="BtnBack" runat="server"  Text="Back" 
                ValidationGroup="bk" onclick="BtnBack_Click" CssClass="buttonsimg" />
    
    <asp:Button ID="BtnHome" runat="server"   Text="Home" 
            ValidationGroup="hm" onclick="BtnHome_Click"  CssClass="buttonsimg"/>
    </td>  </tr>
       <tr>
     <td>
         <asp:GridView ID="GrdCompany_Master" runat="server" CssClass="grdvew">
         </asp:GridView>
     </td>
     </tr>
    

</table>
<asp:ValidationSummary ID="vscontrol" runat="server" ShowMessageBox="true" 
        DisplayMode="BulletList" HeaderText="Plz Correct These Errors" 
        ForeColor="Red"/>
     
</asp:Content>
