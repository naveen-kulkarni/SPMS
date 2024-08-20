<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Of_Company.aspx.cs" Inherits="Project.For_Place_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table cellpadding="1px" cellspacing="1px" width="100%" >
        <tr>
            
            <td align="right">
                <asp:Button ID="Button3" runat="server" Text="LogOut" onclick="Button3_Click"/>
            <asp:TextBox ID="Txt_updby" runat="server" CssClass="commonTxtbox" 
                    BorderStyle="None" ReadOnly="True" ></asp:TextBox>            
            </td> 
        </tr>
     </table>
<table>
<tr>
<td>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Company Details" CssClass="buttonsimg" />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="List Of Companys" CssClass="buttonsimg" />


</td></tr></table>
<table class="style3">
    <tr>
        <td align="center">
            <asp:Label ID="Label1" runat="server" Text="List Of Companys" CssClass="lableheader"></asp:Label>
        </td>
        
      
    </tr>
    <tr>
        <td valign="top">   
            <asp:GridView ID="Grid" runat="server" CellPadding="3" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="Groove" 
            BorderWidth="2px" Height="145px" CssClass="style1">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
         </td>
      </tr>
</table>


</asp:Content>
