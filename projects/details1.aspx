<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="details1.aspx.cs" Inherits="Project.details1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="Panel1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
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
    <asp:Label ID="Label1" runat="server" Text="COMPANY HIRED IN PREVIOUS YEARS" CssClass="lableheader"></asp:Label>    
    </td>
  </tr>
</table>



<table>
<tr>

<td valign="top">
    <asp:Label ID="Label2" runat="server" Text="Company Name :" CssClass="lablewidth"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    </td>
    
      <td valign="top">
        <asp:Label ID="Label3" runat="server" Text="Branch :" CssClass="lablewidth"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
    </td>
    
       <td valign="top">
    
        <asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" CssClass="buttonsimg" />
    
    </td>
            
        
   </tr>
   </table>

   <table width="95%">
   <tr>
      <td align="right">    
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="List Of Companys" CssClass="buttonsimg" />
    
    </td>
    </tr>
</table>
    <asp:Label ID="lbl_Err" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Panel>
</asp:Content>

